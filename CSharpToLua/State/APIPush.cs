namespace CSharpToLua.State;

public partial class LuaState
{
    
    #region 压栈操作
    public void PushNil()
    {
        stack.Push(null);
    }

    public void PushBoolean(bool b)
    {
        stack.Push(b);
    }

    public void PushInteger(long n)
    {
        stack.Push(n);
    }

    public void PushNumber(double n)
    {
        stack.Push(n);
    }

    public void PushString(string s)
    {
        stack.Push(s);
    }

    

    #endregion
}