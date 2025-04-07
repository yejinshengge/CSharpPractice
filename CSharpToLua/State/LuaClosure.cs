using BinChunk;
using CSharpToLua.API;

namespace CSharpToLua.State;

public class Upvalue
{
    internal object Value;
}

/// <summary>
/// Lua闭包实现类
/// 功能：封装函数原型，用于执行Lua代码
/// </summary>
public class LuaClosure
{
    /// <summary>
    /// 函数原型，包含代码、常量表等信息
    /// </summary>
    public Prototype Proto { get; set; }

    /// <summary>
    /// C#闭包
    /// </summary>
    public CsharpFunction CSharpFunction { get; set; }

    public Upvalue[] Upvalues { get; set; }

    /// <summary>
    /// 创建Lua闭包
    /// </summary>
    /// <param name="proto">函数原型</param>
    public LuaClosure(Prototype proto)
    {
        Proto = proto;
        if(proto.Upvalues != null && proto.Upvalues.Length > 0)
        {
            Upvalues = new Upvalue[proto.Upvalues.Length];
        }
    }

    /// <summary>
    /// 创建C#闭包
    /// </summary>
    /// <param name="csharpFunction"></param>
    public LuaClosure(CsharpFunction csharpFunction,int upvaluesCnt)
    {
        CSharpFunction = csharpFunction;
        if(upvaluesCnt > 0)
        {
            Upvalues = new Upvalue[upvaluesCnt];
        }
    }
}
