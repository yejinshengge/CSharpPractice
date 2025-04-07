using CSharpToLua.API;

namespace CSharpToLua.State;

public partial class LuaState
{
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

    public void PushCSharpFunction(CsharpFunction func)
    {
        stack.Push(new LuaClosure(func));
    }

    public void PushGlobalTable()
    {
        var global = Registry.Get(Consts.LUA_RIDX_GLOBALS);
        stack.Push(global);
    }
}