using CSharpToLua.API;

namespace CSharpToLua.State;

public partial class LuaState
{
    public void PushNil()
    {
        Stack.Push(null);
    }

    public void PushBoolean(bool b)
    {
        Stack.Push(b);
    }

    public void PushInteger(long n)
    {
        Stack.Push(n);
    }

    public void PushNumber(double n)
    {
        Stack.Push(n);
    }

    public void PushString(string s)
    {
        Stack.Push(s);
    }

    public void PushCSharpFunction(CsharpFunction func)
    {
        Stack.Push(new LuaClosure(func,0));
    }

    public void PushGlobalTable()
    {
        var global = Registry.Get(Consts.LUA_RIDX_GLOBALS);
        Stack.Push(global);
    }

    public void PushCSharpClosure(CsharpFunction func,int n)
    {
        var closure = new LuaClosure(func,n);
        for(int i = n;i > 0;i--)
        {
            var val = Stack.Pop();
            closure.Upvalues[n-1] = new Upvalue(val);
        }
        Stack.Push(closure);
    }
}