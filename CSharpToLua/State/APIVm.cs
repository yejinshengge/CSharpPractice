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

}
