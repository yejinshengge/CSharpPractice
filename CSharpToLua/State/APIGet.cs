using CSharpToLua.API;

namespace CSharpToLua.State;

public partial class LuaState
{
    /// <summary>
    /// 创建并压入一个预分配大小的表
    /// </summary>
    /// <param name="arraySize">数组部分初始容量</param>
    /// <param name="recordSize">哈希表部分初始容量</param>
    public void CreateTable(int arraySize, int recordSize)
    {
        var table = new LuaTable(arraySize, recordSize);
        stack.Push(table);
    }

    /// <summary>
    /// 创建并压入一个空表
    /// </summary>
    public void NewTable()
    {
        CreateTable(0, 0);
    }

    /// <summary>
    /// 表查询核心方法（实现getTable逻辑）
    /// </summary>
    /// <param name="tableObj">表对象</param>
    /// <param name="key">查询键</param>
    /// <returns>值的Lua类型</returns>
    private LuaType _getTableInternal(object tableObj, object key)
    {
        if (tableObj is not LuaTable table)
        {
            throw new InvalidOperationException("操作对象不是表类型");
        }

        var value = table.Get(key);
        stack.Push(value);
        return LuaValue.TypeOf(value);
    }

    /// <summary>
    /// 通用表查询方法
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <returns>获取值的类型</returns>
    public LuaType GetTable(int idx)
    {
        var table = stack.Get(idx);
        var key = stack.Pop();
        return _getTableInternal(table, key);
    }

    /// <summary>
    /// 通过字符串键获取表值
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">字符串键</param>
    /// <returns>获取值的类型</returns>
    public LuaType GetField(int idx, string key)
    {
        object v = stack.Get(idx);
        return _getTableInternal(v,key);
    }

    /// <summary>
    /// 通过整数键获取表值
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">整数键（1-based）</param>
    /// <returns>获取值的类型</returns>
    public LuaType GetI(int idx, long key)
    {
        object v = stack.Get(idx);
        return _getTableInternal(v,key);
    }

}
