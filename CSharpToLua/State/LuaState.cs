using CSharpToLua.API;
using BinChunk;

namespace CSharpToLua.State;

/// <summary>
/// Lua状态机实现类
/// </summary>
public partial class LuaState : ILuaState, ILuaVm
{
    private readonly LuaStack stack;
    private Prototype proto;  // 当前执行的函数原型
    private int pc;           // 程序计数器

    /// <summary>
    /// 创建带有函数原型的Lua状态机实例
    /// </summary>
    /// <param name="stackSize">初始栈大小</param>
    /// <param name="proto">要执行的函数原型</param>
    public LuaState(int stackSize, Prototype proto)
    {
        this.stack = new LuaStack(stackSize);
        this.proto = proto;
        this.pc = 0;
    }

    /// <summary>
    /// 构造函数，初始化Lua栈
    /// </summary>
    public LuaState()
    {
        this.stack = new LuaStack(20);
    }


    #region 基础栈操作
    public int GetTop()
    {
        return stack.Top;
    }

    public int AbsIndex(int idx)
    {
        return stack.AbsIndex(idx);
    }

    public void CheckStack(int n)
    {
        stack.Check(n);
    }

    public void Pop(int n)
    {
        SetTop(-n-1);
    }

    public void Copy(int fromIdx, int toIdx)
    {
        var val = stack.Get(fromIdx);
        stack.Set(toIdx, val);
    }

    public void PushValue(int idx)
    {
        var val = stack.Get(idx);
        stack.Push(val);
    }

    public void Replace(int idx)
    {
        var val = stack.Pop();
        stack.Set(idx, val);
    }

    public void Insert(int idx)
    {
        Rotate(idx, 1);
    }

    public void Remove(int idx)
    {
        Rotate(idx, -1);
        Pop(1);
    }

    public void Rotate(int idx, int n)
    {
        int t = stack.Top - 1;
        int p = stack.AbsIndex(idx) - 1;
        int m;
        
        if (n >= 0)
        {
            m = t - n;
        }
        else
        {
            m = p - n - 1;
        }
        
        stack.Reverse(p, m);
        stack.Reverse(m + 1, t);
        stack.Reverse(p, t);
    }

    public void SetTop(int idx)
    {
        int newTop = stack.AbsIndex(idx);
        if (newTop < 0)
        {
            throw new Exception("栈下溢！");
        }
        
        int n = stack.Top - newTop;
        if (n > 0)
        {
            for (int i = 0; i < n; i++)
            {
                stack.Pop();
            }
        }
        else if (n < 0)
        {
            for (int i = 0; i > n; i--)
            {
                stack.Push(null);
            }
        }
    }
    #endregion

    #region 类型检查与转换
    public string TypeName(LuaType tp)
    {
        switch (tp)
        {
            case LuaType.LUA_TNONE:     return "no value";
            case LuaType.LUA_TNIL:      return "nil";
            case LuaType.LUA_TBOOLEAN:  return "boolean";
            case LuaType.LUA_TNUMBER:   return "number";
            case LuaType.LUA_TSTRING:   return "string";
            case LuaType.LUA_TTABLE:    return "table";
            case LuaType.LUA_TFUNCTION: return "function";
            case LuaType.LUA_TTHREAD:   return "thread";
            default:                     return "userdata";
        }
    }

    public LuaType Type(int idx)
    {
        if (stack.IsValid(idx))
        {
            var val = stack.Get(idx);
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
        var val = stack.Get(idx);
        return val is long;
    }

    public bool ToBoolean(int idx)
    {
        var val = stack.Get(idx);
        return LuaValue.ToBoolean(val);
    }

    public double ToNumber(int idx)
    {
        var (n, _) = ToNumberX(idx);
        return n;
    }

    public (double, bool) ToNumberX(int idx)
    {
        var val = stack.Get(idx);
        return LuaValue.ToFloat(val);
    }

    public long ToInteger(int idx)
    {
        var (i, _) = ToIntegerX(idx);
        return i;
    }

    public (long, bool) ToIntegerX(int idx)
    {
        var val = stack.Get(idx);
        return LuaValue.ToInteger(val);
    }

    public (string, bool) ToStringX(int idx)
    {
        var val = stack.Get(idx);
        if (val is string s)
        {
            return (s, true);
        }
        else if (val is long l)
        {
            var str = l.ToString();
            stack.Set(idx, str); // 注意：这里会修改栈上的值
            return (str, true);
        }
        else if (val is double d)
        {
            var str = d.ToString();
            stack.Set(idx, str); // 注意：这里会修改栈上的值
            return (str, true);
        }
        return ("", false);
    }

    public string ToString(int idx)
    {
        var (s, _) = ToStringX(idx);
        return s;
    }
    #endregion

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