using BinChunk;

namespace CSharpToLua.State;

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
    /// 创建Lua闭包
    /// </summary>
    /// <param name="proto">函数原型</param>
    public LuaClosure(Prototype proto)
    {
        Proto = proto;
    }
}
