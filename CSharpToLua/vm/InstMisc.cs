using CSharpToLua.API;
using VirtualMachine;

namespace CSharpToLua.VM;

public static class InstMisc
{
    /// <summary>
    /// 实现MOVE指令
    /// 功能：将寄存器B的值复制到寄存器A
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// </summary>
    public static void Move(Instruction i, ILuaVm vm)
    {
        // 提取ABC操作数（a、b、c）
        var (a, b, _) = i.ABC();

        // 调整索引：Lua寄存器从1开始，指令操作数从0开始
        int toIdx = a + 1;
        int fromIdx = b + 1;

        // 执行复制操作
        vm.Copy(fromIdx, toIdx);
    }

    /// <summary>
    /// 实现JMP指令
    /// 功能：执行无条件跳转
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// </summary>
    public static void Jmp(Instruction i, ILuaVm vm)
    {
        // 提取AsBx操作数
        var (a, sBx) = i.AsBx();

        // 执行跳转（sBx为跳转偏移量）
        vm.AddPC(sBx);

        // 处理a参数（目前未实现相关功能）
        if (a != 0)
        {
            throw new System.NotImplementedException("JMP指令的A参数功能未实现");
        }
    }
}

