using CSharpToLua.API;
using System;

namespace CSharpToLua.VirtualMachine;

/// <summary>
/// Lua虚拟机指令解码结构
/// </summary>
public readonly struct Instruction
{
    private const int MAXARG_Bx = 262143; // (1 << 18) - 1
    private const int MAXARG_sBx = 131071; // (1 << 17) - 1

    private readonly uint _value;

    public Instruction(uint value) => _value = value;

    /// <summary>
    /// 提取操作码（低6位）
    /// </summary>
    public int Opcode() => (int)(_value & 0x3F);

    /// <summary>
    /// 解码ABC模式参数
    /// </summary>
    /// <returns>(a, b, c) 参数元组</returns>
    public (int a, int b, int c) ABC()
    {
        int a = (int)((_value >> 6) & 0xFF);    // 8 bits
        int c = (int)((_value >> 14) & 0x1FF);  // 9 bits
        int b = (int)((_value >> 23) & 0x1FF);  // 9 bits
        return (a, b, c);
    }

    /// <summary>
    /// 解码ABx模式参数
    /// </summary>
    /// <returns>(a, bx) 参数元组</returns>
    public (int a, int bx) ABx()
    {
        int a = (int)((_value >> 6) & 0xFF);    // 8 bits
        int bx = (int)(_value >> 14);           // 18 bits
        return (a, bx);
    }

    /// <summary>
    /// 解码AsBx模式参数（带符号偏移量）
    /// </summary>
    /// <returns>(a, sbx) 参数元组</returns>
    public (int a, int sbx) AsBx()
    {
        var (a, bx) = ABx();
        return (a, bx - MAXARG_sBx);
    }

    /// <summary>
    /// 解码Ax模式参数
    /// </summary>
    public int Ax() => (int)(_value >> 6);  // 26 bits

    /// <summary>
    /// 获取指令的操作码名称
    /// </summary>
    /// <returns>操作码的助记符名称</returns>
    public string OpName()
    {
        return OpCodeInfo.Infos[(OpCode)Opcode()].Name;
    }

    /// <summary>
    /// 获取指令的操作模式
    /// </summary>
    /// <returns>指令使用的编码模式</returns>
    public InstructionMode OpMode()
    {
        return OpCodeInfo.Infos[(OpCode)Opcode()].OpMode;
    }

    /// <summary>
    /// 获取B参数的解析模式
    /// </summary>
    /// <returns>B参数的类型</returns>
    public OpArgType BMode()
    {
        return OpCodeInfo.Infos[(OpCode)Opcode()].ArgBMode;
    }

    /// <summary>
    /// 获取C参数的解析模式
    /// </summary>
    /// <returns>C参数的类型</returns>
    public OpArgType CMode()
    {
        return OpCodeInfo.Infos[(OpCode)Opcode()].ArgCMode;
    }

    /// <summary>
    /// 执行当前指令
    /// </summary>
    /// <param name="vm">Lua虚拟机实例</param>
    public void Execute(ILuaVm vm)
    {
        // 获取操作码对应的元数据
        var opCode = (OpCode)Opcode();
        if (!OpCodeInfo.Infos.TryGetValue(opCode, out var info))
        {
            throw new InvalidOperationException($"未知操作码: {opCode}");
        }

        // 获取指令参数并格式化为日志字符串
        string paramsStr = FormatInstructionParams(opCode, info.OpMode);
        
        Console.WriteLine($"执行指令: {info.Name} {paramsStr}");
        
        // 执行指令对应的操作
        if (info.Action != null)
        {
            Console.WriteLine($"执行前堆栈");
            PrintStack(vm);
            info.Action.Invoke(this, vm);
            Console.WriteLine($"执行后堆栈");
            PrintStack(vm);
        }
        else
        {
            throw new NotImplementedException($"未实现的操作码: {opCode} ({info.Name})");
        }
    }

    /// <summary>
    /// 格式化指令参数为可读字符串
    /// </summary>
    private string FormatInstructionParams(OpCode opCode, InstructionMode mode)
    {
        switch (mode)
        {
            case InstructionMode.IABC:
                var (a, b, c) = ABC();
                return $"A:{a} B:{b} C:{c}";
            
            case InstructionMode.IABx:
                var (aB, bx) = ABx();
                return $"A:{aB} Bx:{bx}";
            
            case InstructionMode.IAsBx:
                var (aS, sBx) = AsBx();
                return $"A:{aS} sBx:{sBx}";
            
            case InstructionMode.IAx:
                return $"Ax:{Ax()}";
            
            default:
                return "未知参数格式";
        }
    }

    /// <summary>
    /// 打印Lua状态机的栈内容
    /// </summary>
    /// <param name="ls">Lua状态机实例</param>
    public static void PrintStack(CSharpToLua.API.ILuaState ls)
    {
        PrintStack(ls,1,ls.GetTop());
    }
    public static void PrintStack(CSharpToLua.API.ILuaState ls,int start,int end)
    {
        for (int i = start; i <= end; i++)
        {
            var t = ls.Type(i);
            switch (t)
            {
                case CSharpToLua.API.LuaType.LUA_TBOOLEAN:
                    Console.Write($"[{ls.ToBoolean(i).ToString().ToLower()}]");
                    break;
                case CSharpToLua.API.LuaType.LUA_TNUMBER:
                    Console.Write($"[{ls.ToNumber(i)}]");
                    break;
                case CSharpToLua.API.LuaType.LUA_TSTRING:
                    Console.Write($"[\"{ls.ToString(i)}\"]");
                    break;
                default:
                    Console.Write($"[{ls.TypeName(t)}]");
                    break;
            }
        }
        Console.WriteLine();
    }
}