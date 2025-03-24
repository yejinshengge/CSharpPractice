namespace CSharpToLua.State;

public partial class LuaState
{
    public int PC => pc;

    public void AddPC(int n)
    {
        pc += n;
    }

    public uint Fetch()
    {
        uint code = proto.Code[pc];
        pc++;
        return code;
    }

    public void GetConst(int idx)
    {
        object constant = proto.Constants[idx - 1]; // Lua常量表索引从1开始
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
