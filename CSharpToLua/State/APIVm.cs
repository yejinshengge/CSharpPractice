namespace CSharpToLua.State;

public partial class LuaState
{
    public int PC => stack.PC;

    public void AddPC(int n)
    {
        stack.PC += n;
    }

    public uint Fetch()
    {
        uint code = stack.Closure.Proto.Code[stack.PC];
        stack.PC++;
        return code;
    }

    public void GetConst(int idx)
    {
        object constant = stack.Closure.Proto.Constants[idx];
        stack.Push(constant);
    }

    public void GetRK(int rk)
    {
        if (rk > 0xFF)
        {
            // 常量表索引（rk & 0xFF 获取实际索引）
            GetConst(rk & 0xFF);
        }
        else
        {
            // 寄存器索引（从1开始）
            PushValue(rk + 1);
        }
    }

    /// <summary>
    /// 获取当前函数的寄存器数量
    /// </summary>
    /// <returns>寄存器数量</returns>
    public int RegisterCount()
    {
        return stack.Closure.Proto.MaxStackSize;
    }

    /// <summary>
    /// 加载指定数量的变长参数到栈顶
    /// </summary>
    /// <param name="n">要加载的变长参数数量，-1表示加载所有</param>
    public void LoadVararg(int n)
    {
        if (n < 0)
        {
            n = stack.VarArgs.Count;
        }
        
        stack.Check(n);
        stack.PushN(stack.VarArgs.ToArray(), n);
    }

    /// <summary>
    /// 加载指定索引的函数原型并创建闭包
    /// </summary>
    /// <param name="idx">函数原型在当前Proto的子函数表中的索引</param>
    public void LoadProto(int idx)
    {
        var proto = stack.Closure.Proto.Protos[idx];
        var closure = new LuaClosure(proto);
        stack.Push(closure);
    }
}
