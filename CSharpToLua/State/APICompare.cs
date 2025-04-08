using CSharpToLua.API;
using System;

namespace CSharpToLua.State
{
    public partial class LuaState
    {
        public bool Compare(int idx1, int idx2, CompareOp op)
        {
            if (!Stack.IsValid(idx1) || !Stack.IsValid(idx2))
            {
                return false;
            }
            object a = Stack.Get(idx1);
            object b = Stack.Get(idx2);

            switch (op)
            {
                // ==
                case CompareOp.LUA_OPEQ:
                    return Eq(a, b,this);
                // <
                case CompareOp.LUA_OPLT:
                    return Lt(a, b,this);
                // <=
                case CompareOp.LUA_OPLE:
                    return Le(a, b,this);
                default:
                    throw new ArgumentException("无效的比较操作符");
            }
        }

        private bool Eq(object a, object b,LuaState ls)
        {
            if (a == null)
                return b == null;

            switch (a)
            {
                case bool boolA:
                    return b is bool boolB && boolA == boolB;
                case string strA:
                    return b is string strB && strA == strB;
                case long longA:
                    return b switch
                    {
                        long longB => longA == longB,
                        double doubleB => longA == doubleB,
                        _ => false
                    };
                case double doubleA:
                    return b switch
                    {
                        double doubleB => doubleA == doubleB,
                        long longB => doubleA == longB,
                        _ => false
                    };
                // 元方法
                case LuaTable luaTableA:
                    if(b is LuaTable luaTableB && luaTableA != luaTableB && ls != null){
                        var (res,ok) = LuaValue.CallMetamethod(luaTableA,luaTableB,"__eq",ls);
                        if(ok){
                            return LuaValue.ToBoolean(res);
                        }
                    }
                    return a == b;
                default:
                    return a.Equals(b);
            }
        }

        private bool Lt(object a, object b,LuaState ls)
        {
            if (a is string strA && b is string strB)
                return string.Compare(strA, strB, StringComparison.Ordinal) < 0;

            if (a is long longA)
            {
                return b switch
                {
                    long longB => longA < longB,
                    double doubleB => longA < doubleB,
                    _ => throw new ArgumentException("无法比较的类型")
                };
            }

            if (a is double doubleA)
            {
                return b switch
                {
                    double doubleB => doubleA < doubleB,
                    long longB => doubleA < longB,
                    _ => throw new ArgumentException("无法比较的类型")
                };
            }
            // 元方法
            var (res,ok) = LuaValue.CallMetamethod(a,b,"__lt",ls);
            if(ok){
                return LuaValue.ToBoolean(res);
            }

            throw new ArgumentException("比较错误：不支持的类型");
        }

        private bool Le(object a, object b,LuaState ls)
        {
            if (a is string strA && b is string strB)
                return string.Compare(strA, strB, StringComparison.Ordinal) <= 0;

            if (a is long longA)
            {
                return b switch
                {
                    long longB => longA <= longB,
                    double doubleB => longA <= doubleB,
                    _ => throw new ArgumentException("无法比较的类型")
                };
            }

            if (a is double doubleA)
            {
                return b switch
                {
                    double doubleB => doubleA <= doubleB,
                    long longB => doubleA <= longB,
                    _ => throw new ArgumentException("无法比较的类型")
                };
            }
            // 元方法
            var (res,ok) = LuaValue.CallMetamethod(a,b,"__le",ls);
            if(ok){
                return LuaValue.ToBoolean(res);
            }
            var (res2,ok2) = LuaValue.CallMetamethod(b,a,"__lt",ls);
            if(ok2){
                return !LuaValue.ToBoolean(res2);
            }
            throw new ArgumentException("比较错误：不支持的类型");
        }

        /// <summary>
        /// 比较两个值(不考虑元表)
        /// </summary>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        public bool RawEqual(int idx1, int idx2)
        {
            if (!Stack.IsValid(idx1) || !Stack.IsValid(idx2))
            {
                return false;
            }

            var a = Stack.Get(idx1);
            var b = Stack.Get(idx2);
            return Eq(a, b,null);
        }
    }
}
