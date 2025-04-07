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
        Stack.Push(table);
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
    /// <param name="isRaw">是否为原始表</param>
    /// <returns>值的Lua类型</returns>
    private LuaType _getTableInternal(object tableObj, object key,bool isRaw)
    {
        if (tableObj is LuaTable table)
        {
            var value = table.Get(key);
            if(isRaw || value != null || !table.HasMetafield("__index")){
                Stack.Push(value);
                return LuaValue.TypeOf(value);
            }
        }

        // 调用元方法
        if(!isRaw){
            var mf = LuaValue.GetMetafield(tableObj,"__index",this);
            if(mf != null){
                switch(mf){
                    case LuaTable mTable:
                        return _getTableInternal(mTable,key,false);
                    case LuaClosure closure:
                        Stack.Push(mf);
                        Stack.Push(tableObj);
                        Stack.Push(key);
                        Call(2,1);
                        var val = Stack.Get(-1);
                        return LuaValue.TypeOf(val);
                }
            }
        }
        throw new InvalidOperationException("无法获取表值");
    }

    /// <summary>
    /// 通用表查询方法
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <returns>获取值的类型</returns>
    public LuaType GetTable(int idx)
    {
        var table = Stack.Get(idx);
        var key = Stack.Pop();
        return _getTableInternal(table, key,false);
    }

    /// <summary>
    /// 通过字符串键获取表值
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">字符串键</param>
    /// <returns>获取值的类型</returns>
    public LuaType GetField(int idx, string key)
    {
        object v = Stack.Get(idx);
        return _getTableInternal(v,key,false);
    }

    /// <summary>
    /// 通过整数键获取表值
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">整数键（1-based）</param>
    /// <returns>获取值的类型</returns>
    public LuaType GetI(int idx, long key)
    {
        object v = Stack.Get(idx);
        return _getTableInternal(v,key,false);
    }

    /// <summary>
    /// 获取全局环境中的变量
    /// </summary>
    /// <param name="name">变量名</param>
    /// <returns>变量的类型</returns>
    public LuaType GetGlobal(string name)
    {
        var table = Registry.Get(Consts.LUA_RIDX_GLOBALS);
        return _getTableInternal(table,name,false);
    }
    
    /// <summary>
    /// 获取元表
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    public bool GetMetaTable(int idx)
    {
        var val = Stack.Get(idx);
        var mt = LuaValue.GetMetatable(val,this);
        if(mt != null){
            Stack.Push(mt);
            return true;
        }
        return false;
    }
    
}
