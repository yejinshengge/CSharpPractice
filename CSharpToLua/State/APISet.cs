using CSharpToLua.API;

namespace CSharpToLua.State;

public partial class LuaState
{
    /// <summary>
    /// 设置表的值（操作：t[k] = v）
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    public void SetTable(int idx)
    {
        var value = stack.Pop();
        var key = stack.Pop();
        
        _setTableInternal(idx, key, value);
    }

    /// <summary>
    /// 表设置核心方法
    /// </summary>
    /// <param name="tableObj">表对象</param>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    private void _setTableInternal(int idx, object key, object value)
    {
        object v = stack.Get(idx);
        if(v is not LuaTable table)
        {
            throw new InvalidOperationException("操作对象不是表类型");
        }
        table.Put(key, value);
        stack.Set(idx, table);
    }

    private void _setTableInternal(object table, object key, object value)
    {
        if(table is not LuaTable luaTable)
        {
            throw new InvalidOperationException("操作对象不是表类型");
        }
        luaTable.Put(key, value);
    }

    /// <summary>
    /// 通过字符串键设置表值
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">字符串键</param>
    public void SetField(int idx, string key)
    {
        var value = stack.Pop();
        _setTableInternal(idx, key, value);
    }

    /// <summary>
    /// 通过整数键设置表值
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">整数键（1-based）</param>
    public void SetI(int idx, long key)
    {
        var value = stack.Pop();
        _setTableInternal(idx, key, value);
    }

    public void SetGlobal(string name)
    {
        var table = Registry.Get(Consts.LUA_RIDX_GLOBALS);
        var value = stack.Pop();
        _setTableInternal(table,name,value);
    }

    public void Register(string name,CsharpFunction func)
    {
        PushCSharpFunction(func);
        SetGlobal(name);
    }
}