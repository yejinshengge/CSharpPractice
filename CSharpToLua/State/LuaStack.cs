namespace CSharpToLua.State;

using System.Collections.Generic;
using CSharpToLua.API;

/// <summary>
/// Lua虚拟栈实现
/// 功能：模拟Lua的调用栈结构
/// 设计说明：
/// 1. 使用动态List实现可扩展栈结构
/// 2. 索引支持正负索引（正索引从1开始，负索引从-1开始）
/// 3. 自动扩容机制保证栈空间
/// 4. 支持栈帧链接、闭包执行和程序计数器
/// </summary>
public class LuaStack
{
    private readonly List<object> slots = new();
    public int Top { get; set; }

    /// <summary>
    /// 上一级栈帧，用于实现栈帧链
    /// </summary>
    public LuaStack Prev { get; set; }

    /// <summary>
    /// 当前栈帧正在执行的闭包
    /// </summary>
    public LuaClosure Closure { get; set; }

    /// <summary>
    /// 可变参数存储数组
    /// </summary>
    public List<object> VarArgs { get; set; }

    /// <summary>
    /// 程序计数器，记录当前执行的指令位置
    /// </summary>
    public int PC { get; set; }

    private LuaState luaState;

    /// <summary>
    /// 初始化指定容量的栈
    /// </summary>
    public LuaStack(int size,LuaState state)
    {
        // 预填充null元素模拟Lua栈初始状态
        for (int i = 0; i < size; i++)
        {
            slots.Add(null);
        }
        Top = 0;

        // 新增字段初始化
        Prev = null;
        Closure = null;
        VarArgs = new List<object>();
        PC = 0;
        luaState = state;
    }

    /// <summary>
    /// 确保栈空间足够容纳n个元素
    /// </summary>
    public void Check(int n)
    {
        int free = slots.Count - Top;
        for (int i = free; i < n; i++)
        {
            slots.Add(null);
        }
    }

    /// <summary>
    /// 压入栈顶元素
    /// </summary>
    public void Push(object val)
    {
        if (Top == slots.Count)
        {
            throw new System.StackOverflowException("Lua栈溢出");
        }
        slots[Top++] = val;
    }

    /// <summary>
    /// 弹出栈顶元素
    /// </summary>
    public object Pop()
    {
        if (Top < 1)
        {
            throw new System.InvalidOperationException("Lua栈下溢");
        }
        var val = slots[--Top];
        slots[Top] = null; // 帮助GC回收
        return val;
    }

    /// <summary>
    /// 转换相对索引为绝对索引
    /// 索引规则：
    /// 正数：从栈底开始（1-based）
    /// 负数：从栈顶开始（-1表示栈顶）
    /// </summary>
    public int AbsIndex(int idx)
    {
        if(idx <= Consts.LUA_REGISTRYINDEX)
            return idx;
        return idx > 0 ? idx : idx + Top + 1;
    }

    /// <summary>
    /// 验证索引有效性
    /// </summary>
    public bool IsValid(int idx)
    {
        if(idx == Consts.LUA_REGISTRYINDEX)
            return true;
        int absIdx = AbsIndex(idx);
        return absIdx > 0 && absIdx <= Top;
    }

    /// <summary>
    /// 获取指定索引处的值
    /// </summary>
    public object Get(int idx)
    {
        if(idx == Consts.LUA_REGISTRYINDEX)
            return luaState.Registry;
        int absIdx = AbsIndex(idx);
        return absIdx > 0 && absIdx <= Top ? slots[absIdx - 1] : null;
    }

    /// <summary>
    /// 设置指定索引处的值
    /// </summary>
    public void Set(int idx, object val)
    {
        if(idx == Consts.LUA_REGISTRYINDEX)
        {
            luaState.Registry = val as LuaTable;
            return;
        }
        int absIdx = AbsIndex(idx);
        if (absIdx > 0 && absIdx <= Top)
        {
            slots[absIdx - 1] = val;
            return;
        }
        throw new System.ArgumentOutOfRangeException($"无效栈索引: {idx}");
    }

    /// <summary>
    /// 反转栈中指定范围的元素
    /// </summary>
    /// <param name="from">起始索引（包含）</param>
    /// <param name="to">结束索引（包含）</param>
    public void Reverse(int from, int to)
    {
        if(to > from)
        {
            slots.Reverse(from, to - from + 1);
        }
        else if(to < from)
        {
            slots.Reverse(to, from - to + 1);
        }
    }

    /// <summary>
    /// 弹出多个栈顶元素
    /// </summary>
    /// <param name="n">要弹出的元素数量</param>
    /// <returns>弹出的元素数组，索引0为最先弹出的元素</returns>
    public object[] PopN(int n)
    {
        // 创建结果数组
        object[] values = new object[n];
        
        // 从后向前弹出元素（保持原始顺序）
        for (int i = n - 1; i >= 0; i--)
        {
            values[i] = Pop();
        }
        
        return values;
    }

    /// <summary>
    /// 批量压入元素到栈顶
    /// </summary>
    /// <param name="values">要压入的元素数组</param>
    /// <param name="n">指定压入数量，负数表示压入全部</param>
    /// <remarks>
    /// 如果n大于数组长度，将用null值填充
    /// 如果n小于0，将压入数组所有元素
    /// </remarks>
    public void PushN(object[] values, int n)
    {
        // 计算实际压入数量
        int valueCount = values.Length;
        if (n < 0)
        {
            n = valueCount;
        }
        
        // 压入元素
        for (int i = 0; i < n; i++)
        {
            if (i < valueCount)
            {
                Push(values[i]);
            }
            else
            {
                Push(null); // 压入nil值
            }
        }
    }
}

