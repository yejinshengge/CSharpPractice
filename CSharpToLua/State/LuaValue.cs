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
                case LuaTable _:// 处理表类型
                    return LuaType.LUA_TTABLE;
                case LuaClosure _:// 处理闭包类型
                    return LuaType.LUA_TFUNCTION;
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

        /// <summary>
        /// 尝试将值转换为浮点数
        /// </summary>
        /// <param name="val">要转换的值</param>
        /// <returns>转换结果和是否成功的标志</returns>
        public static (double, bool) ToFloat(object val)
        {
            if (val is double d)
                return (d, true);
            else if (val is long l)
                return (l, true);
            else if (val is string s)
                return Number.Parser.ParseFloat(s);
            else
                return (0, false);
        }

        /// <summary>
        /// 尝试将值转换为整数
        /// </summary>
        /// <param name="val">要转换的值</param>
        /// <returns>转换结果和是否成功的标志</returns>
        public static (long, bool) ToInteger(object val)
        {
            if (val is long i)
                return (i, true);
            else if (val is double d)
                return Number.LuaMath.FloatToInteger(d);
            else if (val is string s)
                return StringToInteger(s);
            else
                return (0, false);
        }

        /// <summary>
        /// 尝试将字符串转换为整数
        /// </summary>
        /// <param name="s">要转换的字符串</param>
        /// <returns>转换结果和是否成功的标志</returns>
        private static (long, bool) StringToInteger(string s)
        {
            // 先尝试直接解析为整数
            var (i, ok) = Number.Parser.ParseInteger(s);
            if (ok)
                return (i, true);
            
            // 如果失败，尝试解析为浮点数，再转换为整数
            var (f, ok2) = Number.Parser.ParseFloat(s);
            if (ok2)
                return Number.LuaMath.FloatToInteger(f);
            
            return (0, false);
        }

        /// <summary>
        /// 设置元表
        /// </summary>
        /// <param name="val"></param>
        /// <param name="metatable"></param>
        /// <param name="ls"></param>
        public static void SetMetatable(object val,LuaTable metatable,LuaState ls)
        {
            if(val is LuaTable t)
            {
                t.Metatable = metatable;
                return;
            }
            
            var key = "_MT" + TypeOf(val);
            ls.Registry.Put(key,metatable);
        }

        /// <summary>
        /// 获取元表
        /// </summary>
        /// <param name="val"></param>
        /// <param name="ls"></param>
        /// <returns></returns>
        public static LuaTable GetMetatable(object val,LuaState ls)
        {
            if(val is LuaTable t)
                return t.Metatable;
            var key = "_MT" + TypeOf(val);
            var metatable = ls.Registry.Get(key);
            return metatable as LuaTable;
        }

        /// <summary>
        /// 调用元方法
        /// </summary>
        /// <param name="a">第一个操作数</param>
        /// <param name="b">第二个操作数</param>
        /// <param name="mmName">元方法名称</param>
        /// <param name="ls">Lua状态机</param>
        /// <returns>调用结果和是否成功的标志</returns>
        public static (object, bool) CallMetamethod(object a, object b, string mmName, LuaState ls)
        {
            object mm = GetMetafield(a, mmName, ls);
            if (mm == null)
            {
                mm = GetMetafield(b, mmName, ls);
                if (mm == null)
                {
                    return (null, false);
                }
            }
            
            ls.Stack.Check(4);
            ls.Stack.Push(mm);
            ls.Stack.Push(a);
            ls.Stack.Push(b);
            ls.Call(2, 1);
            return (ls.Stack.Pop(), true);
        }

        /// <summary>
        /// 获取元字段
        /// </summary>
        /// <param name="val">操作数</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="ls">Lua状态机</param>
        /// <returns>元字段值</returns>
        public static object GetMetafield(object val, string fieldName, LuaState ls)
        {
            var mt = GetMetatable(val, ls);
            if (mt != null)
            {
                return mt.Get(fieldName);
            }
            return null;
        }
    }
}
