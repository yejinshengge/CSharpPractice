namespace CSharpToLua.API;

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

    /// <summary>
    /// Lua算术运算类型枚举
    /// </summary>
    public enum ArithOp
    {
        LUA_OPADD = 0,    // +加法
        LUA_OPSUB = 1,    // -减法
        LUA_OPMUL = 2,    // *乘法
        LUA_OPMOD = 3,    // %取模
        LUA_OPPOW = 4,    // ^乘方
        LUA_OPDIV = 5,    // /浮点除法
        LUA_OPIDIV = 6,   // //整数除法
        LUA_OPBAND = 7,   // &按位与
        LUA_OPBOR = 8,    // |按位或
        LUA_OPBXOR = 9,   // ~按位异或
        LUA_OPSHL = 10,   // <<左移
        LUA_OPSHR = 11,   // >>右移
        LUA_OPUNM = 12,   // -一元负号
        LUA_OPBNOT = 13   // ~按位非
    }

    /// <summary>
    /// Lua比较运算类型枚举
    /// </summary>
    public enum CompareOp
    {
        LUA_OPEQ = 0,     // ==等于
        LUA_OPLT = 1,     // <小于
        LUA_OPLE = 2      // <=小于等于
    }

    /// <summary>
    /// 函数加载或执行状态
    /// </summary>
    public enum ErrorCode
    {
        LUA_OK = 0,
        LUA_YIELD = 1,
        LUA_ERRRUN = 2,
        LUA_ERRSYNTAX = 3,
        LUA_ERRMEM = 4,
        LUA_ERRGCMM = 5,
        LUA_ERRERR = 6,
        LUA_ERRFILE = 7,
    }

    public static class Consts
    {
        /// <summary>
        /// 默认栈大小
        /// </summary>
        public const int LUA_MINSTACK = 20;
        /// <summary>
        /// Lua栈的最大索引(正负)
        /// </summary>
        public const int LUAI_MAXSTACK = 1000000;
        /// <summary>
        /// 注册表的伪索引
        /// </summary>
        public const int LUA_REGISTRYINDEX = -LUAI_MAXSTACK -1000;
        /// <summary>
        /// 全局环境在注册表里的索引
        /// </summary>
        public const long LUA_RIDX_GLOBALS = 2;

        /// <summary>
        /// 空值
        /// </summary>
        public const string LUA_NULL = "nil";

        /// <summary>
        /// 是否开启日志
        /// </summary>
        public const bool OPEN_LOG = false;

    }

