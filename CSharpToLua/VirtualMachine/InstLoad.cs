using CSharpToLua.API;

namespace CSharpToLua.VirtualMachine;

public static class InstLoad
{
    /// <summary>
    /// 实现LOADNIL指令
    /// 功能：将一组连续寄存器设为nil
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// </summary>
    public static void LoadNil(Instruction i, ILuaVm vm)
    {
        // 提取ABC操作数
        var (a, b, _) = i.ABC();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;

        // 压入nil值到栈顶
        vm.PushNil();
        
        // 循环填充寄存器
        for (int reg = a; reg <= a + b; reg++)
        {
            vm.Copy(-1, reg); // 将栈顶的nil复制到目标寄存器
        }
        
        // 弹出临时nil值
        vm.Pop(1);
    }

    /// <summary>
    /// 实现LOADBOOL指令
    /// 功能：将布尔值加载到寄存器，并根据条件跳过下一条指令
    /// </summary>
    public static void LoadBool(Instruction i, ILuaVm vm)
    {
        // 提取ABC操作数
        var (a, b, c) = i.ABC();
        
        // 调整寄存器索引
        a += 1;
        
        // 将布尔值压入栈顶并替换到目标寄存器
        vm.PushBoolean(b != 0);
        vm.Replace(a);
        
        // 处理跳转条件
        if (c != 0)
        {
            vm.AddPC(1); // 跳过下一条指令
        }
    }

    /// <summary>
    /// 实现LOADK指令
    /// 功能：将常量表中的值加载到寄存器
    /// </summary>
    public static void LoadK(Instruction i, ILuaVm vm)
    {
        // 提取ABx操作数
        var (a, bx) = i.ABx();
        
        // 调整寄存器索引
        a += 1;
        
        // 获取常量并存入寄存器
        vm.GetConst(bx);
        vm.Replace(a);
    }

    /// <summary>
    /// 实现LOADKX指令
    /// 功能：使用额外指令参数加载常量到寄存器
    /// </summary>
    public static void LoadKx(Instruction i, ILuaVm vm)
    {
        // 提取ABx操作数（Bx字段未使用）
        var (a, _) = i.ABx();
        
        // 调整寄存器索引
        a += 1;
        
        // 获取下一条指令的Ax值作为常量索引
        uint nextCode = vm.Fetch();
        var nextInstr = new Instruction(nextCode);
        int ax = nextInstr.Ax();
        
        // 获取常量并存入寄存器
        vm.GetConst(ax);
        vm.Replace(a);
    }
}
