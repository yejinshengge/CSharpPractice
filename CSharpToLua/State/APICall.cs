using System;
using BinChunk;
using CSharpToLua.VirtualMachine;

namespace CSharpToLua.State;

public partial class LuaState
{
    /// <summary>
    /// 加载Lua代码块，创建并返回一个Lua函数
    /// </summary>
    /// <param name="chunk">Lua代码字节数组</param>
    /// <param name="chunkName">代码块名称（用于错误消息和调试）</param>
    /// <param name="mode">加载模式（b=二进制, t=文本, bt=两者都尝试）</param>
    /// <returns>0表示成功，非0表示错误代码</returns>
    public int Load(byte[] chunk, string chunkName, string mode)
    {
        // 解析二进制块，生成函数原型
        Prototype proto = BinaryChunkParser.Undump(chunk);
        
        // 创建Lua闭包
        LuaClosure closure = new LuaClosure(proto);
        
        // 将闭包压入栈顶
        stack.Push(closure);
        
        // 返回成功状态码
        return 0;
    }

    /// <summary>
    /// 调用Lua函数
    /// </summary>
    /// <param name="nArgs">参数数量</param>
    /// <param name="nResults">期望的返回值数量</param>
    /// <exception cref="InvalidOperationException">当被调用对象不是函数时抛出</exception>
    public void Call(int nArgs, int nResults)
    {
        // 获取函数对象（从栈顶向下数第nArgs+1个元素）
        var val = stack.Get(-(nArgs + 1));
        
        // 检查是否为Lua闭包
        if (val is LuaClosure closure)
        {
            // 输出调试信息
            Console.WriteLine($"call {closure.Proto.Source}<{closure.Proto.LineDefined}, {closure.Proto.LastLineDefined}>");
            
            // 调用Lua闭包
            CallLuaClosure(nArgs, nResults, closure);
        }
        else
        {
            throw new InvalidOperationException("not function!");
        }
    }

    /// <summary>
    /// 执行Lua闭包
    /// </summary>
    /// <param name="nArgs">参数数量</param>
    /// <param name="nResults">期望的返回值数量</param>
    /// <param name="closure">要执行的闭包</param>
    private void CallLuaClosure(int nArgs, int nResults, LuaClosure closure)
    {
        // 获取函数原型信息
        int nRegs = closure.Proto.MaxStackSize;
        int nParams = closure.Proto.NumParams;
        bool isVararg = closure.Proto.IsVararg == 1;
        
        // 创建新的调用帧
        LuaStack newStack = new LuaStack(nRegs + 20);
        newStack.Closure = closure;
        
        // 处理函数参数
        var funcAndArgs = stack.PopN(nArgs + 1);
        var args = funcAndArgs.Skip(1).ToArray();
        newStack.PushN(args, nParams);
        newStack.Top = nRegs;
        
        // 处理可变参数
        if (nArgs > nParams && isVararg)
        {
            newStack.VarArgs = funcAndArgs.Skip(nParams+1).ToList();
        }
        
        // 压入调用帧
        PushLuaStack(newStack);
        
        // 运行闭包
        RunLuaClosure();
        
        // 弹出调用帧
        PopLuaStack();
        
        // 处理返回值
        if (nResults != 0)
        {
            var results = newStack.PopN(newStack.Top - nRegs);
            stack.Check(results.Length);
            stack.PushN(results, nResults);
        }
    }

    /// <summary>
    /// 运行当前闭包中的指令
    /// </summary>
    private void RunLuaClosure()
    {
        // 基本循环：取指令 -> 执行指令 -> 直到遇到返回指令
        for (;;)
        {
            // 解析并执行指令
            var inst = new Instruction(Fetch());
            inst.Execute(this);
            
            // 若执行完毕或遇到返回指令，退出循环
            if (inst.Opcode() == (int)OpCode.OpReturn)
                break;
        }
    }
}