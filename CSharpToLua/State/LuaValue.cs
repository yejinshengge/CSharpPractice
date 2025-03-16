namespace CSharpToLua.State
{
    using CSharpToLua.API;

    /// <summary>
    /// Lua值类型判断工具类
    /// 功能：根据C#对象类型判断对应的Lua类型
    /// 设计说明：
    /// 1. 使用C#模式匹配进行类型判断
    /// 2. 数值类型统一处理（long和double都视为Lua number）
    /// 3. 未实现的类型抛出明确异常
    /// </summary>
    public static class LuaValue
    {
        /// <summary>
        /// 获取值的Lua类型
        /// </summary>
        /// <param name="val">需要判断的对象</param>
        /// <returns>对应的Lua类型枚举值</returns>
        /// <exception cref="System.NotImplementedException">遇到未支持的类型时抛出</exception>
        public static LuaType TypeOf(object val)
        {
            switch (val)
            {
                case null:    // 处理nil类型
                    return LuaType.LUA_TNIL;
                case bool _:  // 处理布尔类型
                    return LuaType.LUA_TBOOLEAN;
                case long _:  // 处理整型数值
                case double _:// 处理浮点数值
                    return LuaType.LUA_TNUMBER;
                case string _:// 处理字符串类型
                    return LuaType.LUA_TSTRING;
                default:      // 未实现的类型处理
                    throw new System.NotImplementedException(
                        $"暂不支持的类型: {val.GetType().Name}, 需要扩展类型判断逻辑");
            }
        }
        
        /// <summary>
        /// 将Lua值转换为布尔类型
        /// 转换规则：
        /// - null (nil) 转换为 false
        /// - 布尔值保持不变
        /// - 其他任何值都转换为 true
        /// </summary>
        /// <param name="val">要转换的值</param>
        /// <returns>转换后的布尔值</returns>
        public static bool ToBoolean(object val)
        {
            if (val == null)
                return false;
            
            if (val is bool b)
                return b;
            
            return true; // 其他所有值都视为true
        }
    }
}
