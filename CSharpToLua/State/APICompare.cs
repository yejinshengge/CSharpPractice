using CSharpToLua.API;
using System;

namespace CSharpToLua.State
{
    public partial class LuaState
    {
        public bool Compare(int idx1, int idx2, CompareOp op)
        {
            object a = stack.Get(idx1);
            object b = stack.Get(idx2);

            switch (op)
            {
                // ==
                case CompareOp.LUA_OPEQ:
                    return Eq(a, b);
                // <
                case CompareOp.LUA_OPLT:
                    return Lt(a, b);
                // <=
                case CompareOp.LUA_OPLE:
                    return Le(a, b);
                default:
                    throw new ArgumentException("无效的比较操作符");
            }
        }

        private bool Eq(object a, object b)
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
                default:
                    return a.Equals(b);
            }
        }

        private bool Lt(object a, object b)
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

            throw new ArgumentException("比较错误：不支持的类型");
        }

        private bool Le(object a, object b)
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

            throw new ArgumentException("比较错误：不支持的类型");
        }
    }
}
