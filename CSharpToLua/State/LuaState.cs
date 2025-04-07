using CSharpToLua.API;
using BinChunk;

namespace CSharpToLua.State;

/// <summary>
/// Lua状态机实现类
/// </summary>
public partial class LuaState : ILuaState, ILuaVm
{
    // 栈
    private LuaStack stack;

    // 注册表
    public LuaTable Registry;


    /// <summary>
    /// 创建带有函数原型的Lua状态机实例
    /// </summary>
    /// <param name="stackSize">初始栈大小</param>
    /// <param name="proto">要执行的函数原型</param>
    public LuaState(int stackSize)
    {
        stack = new LuaStack(stackSize,this);
        Registry = new LuaTable();
        Registry.Put(Consts.LUA_RIDX_GLOBALS,new LuaTable());
        PushLuaStack(new LuaStack(stackSize,this));
    }

    /// <summary>
    /// 构造函数，初始化Lua栈
    /// </summary>
    public LuaState()
    {
        new LuaState(Consts.LUA_MINSTACK);
    }


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


    /// <summary>
    /// 压入新的Lua栈帧
    /// </summary>
    /// <param name="newStack">要压入的新栈帧</param>
    /// <remarks>
    /// 新栈帧会成为当前活动栈帧，原有栈帧链接为prev
    /// 用于函数调用时创建新的执行环境
    /// </remarks>
    public void PushLuaStack(LuaStack newStack)
    {
        // 新栈的prev指向当前栈
        newStack.Prev = this.stack;
        
        // 更新当前栈为新栈
        this.stack = newStack;
    }

    /// <summary>
    /// 弹出当前Lua栈帧，恢复上一个栈帧
    /// </summary>
    /// <remarks>
    /// 函数调用结束时，弹出当前执行环境，恢复调用者的环境
    /// 移除当前栈与前一个栈的链接，有助于垃圾回收
    /// </remarks>
    public void PopLuaStack()
    {
        // 保存当前栈引用
        LuaStack stack = this.stack;
        
        // 恢复前一个栈为当前栈
        this.stack = stack.Prev;
        
        // 断开链接，帮助垃圾回收
        stack.Prev = null;
    }

} 