namespace CSharpToLua.API
{
    /// <summary>
    /// Lua类型枚举，对应Lua API中的基础类型定义
    /// 设计说明：
    /// 1. 使用自动递增方式保持与Lua官方类型定义一致
    /// 2. LUA_TNONE = -1 表示无效类型
    /// 3. 后续类型从0开始自动递增，与Lua 5.3官方定义顺序一致
    /// </summary>
    public enum LuaType
    {
        LUA_TNONE = -1,       // 无效类型，用于特殊场景
        LUA_TNIL,             // nil 类型，对应C# null
        LUA_TBOOLEAN,         // 布尔类型，对应C# bool
        LUA_TLIGHTUSERDATA,   // 轻量用户数据（指针类型）
        LUA_TNUMBER,          // 数值类型，统一处理long和double
        LUA_TSTRING,          // 字符串类型，对应C# string
        LUA_TTABLE,           // Lua表类型（暂未实现）
        LUA_TFUNCTION,        // 函数类型（暂未实现）
        LUA_TUSERDATA,        // 完整用户数据（暂未实现）
        LUA_TTHREAD           // 协程类型（暂未实现）
    }
}
