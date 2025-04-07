using CSharpToLua.API;

namespace CSharpToLua.State;

public partial class LuaState
{
    public string TypeName(LuaType tp)
    {
        switch (tp)
        {
            case LuaType.LUA_TNONE: return "no value";
            case LuaType.LUA_TNIL: return "nil";
            case LuaType.LUA_TBOOLEAN: return "boolean";
            case LuaType.LUA_TNUMBER: return "number";
            case LuaType.LUA_TSTRING: return "string";
            case LuaType.LUA_TTABLE: return "table";
            case LuaType.LUA_TFUNCTION: return "function";
            case LuaType.LUA_TTHREAD: return "thread";
            default: return "userdata";
        }
    }

    public LuaType Type(int idx)
    {
        if (Stack.IsValid(idx))
        {
            var val = Stack.Get(idx);
            return LuaValue.TypeOf(val);
        }
        return LuaType.LUA_TNONE;
    }

    public bool IsNone(int idx)
    {
        return Type(idx) == LuaType.LUA_TNONE;
    }

    public bool IsNil(int idx)
    {
        return Type(idx) == LuaType.LUA_TNIL;
    }

    public bool IsNoneOrNil(int idx)
    {
        return Type(idx) <= LuaType.LUA_TNIL;
    }

    public bool IsBoolean(int idx)
    {
        return Type(idx) == LuaType.LUA_TBOOLEAN;
    }

    public bool IsString(int idx)
    {
        var t = Type(idx);
        return t == LuaType.LUA_TSTRING || t == LuaType.LUA_TNUMBER;
    }

    public bool IsNumber(int idx)
    {
        var (_, ok) = ToNumberX(idx);
        return ok;
    }

    public bool IsInteger(int idx)
    {
        var val = Stack.Get(idx);
        return val is long;
    }

    public bool ToBoolean(int idx)
    {
        var val = Stack.Get(idx);
        return LuaValue.ToBoolean(val);
    }

    public double ToNumber(int idx)
    {
        var (n, _) = ToNumberX(idx);
        return n;
    }

    public (double, bool) ToNumberX(int idx)
    {
        var val = Stack.Get(idx);
        return LuaValue.ToFloat(val);
    }

    public long ToInteger(int idx)
    {
        var (i, _) = ToIntegerX(idx);
        return i;
    }

    public (long, bool) ToIntegerX(int idx)
    {
        var val = Stack.Get(idx);
        return LuaValue.ToInteger(val);
    }

    public (string, bool) ToStringX(int idx)
    {
        var val = Stack.Get(idx);
        if (val is string s)
        {
            return (s, true);
        }
        else if (val is long l)
        {
            var str = l.ToString();
            Stack.Set(idx, str); // 注意：这里会修改栈上的值
            return (str, true);
        }
        else if (val is double d)
        {
            var str = d.ToString();
            Stack.Set(idx, str); // 注意：这里会修改栈上的值
            return (str, true);
        }
        return ("", false);
    }

    public string ToString(int idx)
    {
        var (s, _) = ToStringX(idx);
        return s;
    }

    public bool IsCsharpFunction(int idx)
    {
        var val = Stack.Get(idx);
        if (val is not LuaClosure closure)
        {
            return false;
        }
        return closure.CSharpFunction != null;
    }

    public CsharpFunction ToCsharpFunction(int idx)
    {
        var val = Stack.Get(idx);
        if (val is LuaClosure closure)
        {
            return closure.CSharpFunction;
        }
        return null;
    }
}