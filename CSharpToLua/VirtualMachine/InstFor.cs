using CSharpToLua.API;

namespace CSharpToLua.VirtualMachine;

public static class InstFor
{
        /// <summary>
    /// 实现FORPREP指令（循环准备）
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// 功能说明：
    ///   1. 调整循环控制变量：index = index - step
    ///   2. 执行预跳转，为后续循环判断做准备
    /// 操作步骤：
    ///   - 从寄存器a获取初始值
    ///   - 从寄存器a+2获取步长值
    ///   - 计算 index = index - step
    ///   - 更新程序计数器进行预跳转
    /// </summary>
    public static void ForPrep(Instruction i, ILuaVm vm)
    {
        // 提取AsBx操作数
        var (a, sBx) = i.AsBx();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;

        // 计算 index = index - step
        vm.PushValue(a);        // 压入初始值
        vm.PushValue(a + 2);    // 压入步长值
        vm.Arith(ArithOp.LUA_OPSUB); // 执行减法运算
        vm.Replace(a);          // 更新寄存器a的值

        // 执行预跳转
        vm.AddPC(sBx);
    }

    /// <summary>
    /// 实现FORLOOP指令（循环迭代）
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// 功能说明：
    ///   1. 更新循环控制变量：index = index + step
    ///   2. 检查循环条件是否满足
    ///   3. 条件满足时执行跳转并保存当前索引值
    /// </summary>
    public static void ForLoop(Instruction i, ILuaVm vm)
    {
        // 提取AsBx操作数
        var (a, sBx) = i.AsBx();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;

        // 更新索引值：index = index + step
        vm.PushValue(a + 2);    // 压入步长值
        vm.PushValue(a);        // 压入当前索引值
        vm.Arith(ArithOp.LUA_OPADD); // 执行加法运算
        vm.Replace(a);          // 更新寄存器a的值

        // 判断步长方向
        bool isPositiveStep = vm.ToNumber(a + 2) >= 0;

        // 检查循环条件
        bool condition;
        if (isPositiveStep)
        {
            // 正向步长：检查 index <= limit
            condition = vm.Compare(a, a + 1, CompareOp.LUA_OPLE);
        }
        else
        {
            // 负向步长：检查 limit <= index
            condition = vm.Compare(a + 1, a, CompareOp.LUA_OPLE);
        }

        if (condition)
        {
            // 条件满足时执行跳转
            vm.AddPC(sBx);
            // 保存当前索引值到循环变量
            vm.Copy(a, a + 3);
        }
    }

    /// <summary>
    /// 实现TFORLOOP指令：遍历表
    /// </summary>
    /// <param name="i"></param>
    /// <param name="vm"></param>
    public static void TForLoop(Instruction i, ILuaVm vm)
    {
        var (a, sBx) = i.AsBx();
        a+=1;
        // 返回的第一个值不是nil
        if(!vm.IsNil(a+1))
        {
            // 复制键到val
            vm.Copy(a+1,a);
            // 跳转到循环体
            vm.AddPC(sBx);
        }
    }
}

