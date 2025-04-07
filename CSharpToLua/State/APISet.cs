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
        var t = Stack.Get(idx);
        var value = Stack.Pop();
        var key = Stack.Pop();
        
        _setTableInternal(t, key, value,false);
    }

    /// <summary>
    /// 表设置核心方法
    /// </summary>
    /// <param name="table">表对象</param>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    /// <param name="isRaw">是否为原始表</param>
    private void _setTableInternal(object tableObj, object key, object value,bool isRaw)
    {
        if(tableObj is LuaTable table)
        {
            if(isRaw || value != null || !table.HasMetafield("__newindex")){
                table.Put(key, value);
                return;
            }
        }
        // 调用元方法
        if(!isRaw){
            var mf = LuaValue.GetMetafield(tableObj,"__newindex",this);
            if(mf != null){
                switch(mf){
                    case LuaTable mTable:
                        _setTableInternal(mTable,key,value,false);
                        return;
                    case LuaClosure closure:
                        Stack.Push(mf);
                        Stack.Push(tableObj);
                        Stack.Push(key);
                        Stack.Push(value);
                        Call(3,0);
                        return;
                }
            }
        }
        throw new InvalidOperationException("无法设置表值");
    }

    /// <summary>
    /// 通过字符串键设置表值
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">字符串键</param>
    public void SetField(int idx, string key)
    {
        var t = Stack.Get(idx);
        var value = Stack.Pop();
        _setTableInternal(t, key, value,false);
    }

    /// <summary>
    /// 通过整数键设置表值
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">整数键（1-based）</param>
    public void SetI(int idx, long key)
    {
        var t = Stack.Get(idx);
        var value = Stack.Pop();
        _setTableInternal(t, key, value,false);
    }

    public void SetGlobal(string name)
    {
        var table = Registry.Get(Consts.LUA_RIDX_GLOBALS);
        var value = Stack.Pop();
        _setTableInternal(table,name,value,false);
    }

    public void Register(string name,CsharpFunction func)
    {
        PushCSharpFunction(func);
        SetGlobal(name);
    }

    /// <summary>
    /// 设置元表
    /// </summary>
    /// <param name="idx"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void SetMetatable(int idx)
    {
        var val = Stack.Get(idx);
        var mtVal = Stack.Pop();

        if(mtVal == null){
            LuaValue.SetMetatable(val,null,this);
        }
        else if(mtVal is LuaTable mt){
            LuaValue.SetMetatable(val,mt,this);
        }
        else{
            throw new InvalidOperationException("not a table!");
        }
    }
}