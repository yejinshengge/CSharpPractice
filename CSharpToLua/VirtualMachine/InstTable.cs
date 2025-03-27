using CSharpToLua.API;

namespace CSharpToLua.VirtualMachine;

public static class InstTable
{
    /// <summary>
    /// LFIELDS_PER_FLUSH常量，定义每批次多少个字段
    /// </summary>
    private const int LFIELDS_PER_FLUSH = 50;

    /// <summary>
    /// 实现NEWTABLE指令
    /// 操作：创建新表并存入指定寄存器
    /// </summary>
    /// <param name="i">当前指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void NewTable(Instruction i, ILuaVm vm)
    {
        var (a, b, c) = i.ABC();
        a += 1; // 转换为1-based寄存器索引

        // 解析B和C操作数为Fb参数
        int arraySize = Fpb.Fb2Int(b);
        int hashSize = Fpb.Fb2Int(c);

        // 创建新表并压入栈顶
        vm.CreateTable(arraySize, hashSize);
        
        // 将新表存入指定寄存器
        vm.Replace(a);
    }

    /// <summary>
    /// 实现GETTABLE指令
    /// 操作：从表中获取值并存入寄存器
    /// </summary>
    public static void GetTable(Instruction i, ILuaVm vm)
    {
        var (a, b, c) = i.ABC();
        a += 1; // 转换为1-based寄存器索引
        b += 1;

        // 获取RK(c)作为键
        vm.GetRK(c);
        
        // 获取表值
        vm.GetTable(b);
        
        // 将结果存入寄存器a
        vm.Replace(a);
    }

    /// <summary>
    /// 实现SETTABLE指令
    /// 操作：设置表中的键值对
    /// </summary>
    /// <param name="i">当前指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void SetTable(Instruction i, ILuaVm vm)
    {
        var (a, b, c) = i.ABC();
        a += 1; // 转换为1-based寄存器索引

        // 获取RK(b)作为键
        vm.GetRK(b);
        
        // 获取RK(c)作为值
        vm.GetRK(c);
        
        // 设置表a的键值对
        vm.SetTable(a);
    }

    /// <summary>
    /// 实现SETLIST指令
    /// 操作：将连续寄存器中的多个值设置到表的数组部分
    /// </summary>
    /// <param name="i">当前指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void SetList(Instruction i, ILuaVm vm)
    {
        var (a, b, c) = i.ABC();
        a += 1; // 转换为1-based寄存器索引

        // 确定批次编号c
        // 如果c>0，表示批次序号在指令中
        // 如果c=0，表示批次序号在下一条指令中（扩展格式）
        if (c > 0)
        {
            c = c - 1; // 调整批次序号（从0开始）
        }
        else
        {
            // 从下一条指令获取额外参数作为批次序号
            uint nextCode = vm.Fetch();
            c = new Instruction(nextCode).Ax();
        }
        
        // 检查参数b是否为0
        // b=0表示将所有栈顶元素设置到表中（用于处理函数返回值）
        var bIsZero = b == 0;
        if (bIsZero)
        {
            // 计算实际要设置的元素数量
            // 栈顶的值(-1)表示第一个元素的索引
            b = (int)vm.ToInteger(-1) - a - 1;
            vm.Pop(1); // 弹出索引值
        }

        // 确保栈空间足够
        vm.CheckStack(1);
        
        // 计算起始索引
        // 每批次最多设置LFIELDS_PER_FLUSH个元素（默认50）
        long idx = c * LFIELDS_PER_FLUSH;
        
        // 处理从寄存器读取的值（固定数量情况）
        for (int j = 1; j <= b; j++)
        {
            idx++; // Lua使用1-based索引，所以索引需要加1
            vm.PushValue(a + j); // 将寄存器值压栈
            vm.SetI(a, idx);     // 设置表a的索引idx的值
        }

        // 处理b=0的情况（将所有栈顶元素设置到表中）
        if (bIsZero)
        {
            // 将当前寄存器区域之上的所有值都设置到表中
            // 这通常用于处理函数调用返回的多个值
            for (var j = vm.RegisterCount() + 1; j <= vm.GetTop(); j++)
            {
                idx++;
                vm.PushValue(j);
                vm.SetI(a, idx);
            }

            // 清理栈，恢复到只有寄存器区域
            vm.SetTop(vm.RegisterCount());
        }
    }
}
