using static CSharpToLua.Number.LuaMath;
using System;
using CSharpToLua.API;

namespace CSharpToLua.State;

/// <summary>
/// 提供Lua算术运算的实现
/// </summary>
public partial class LuaState
{
    // 整数运算
    internal static readonly Func<long, long, long> IAdd = (a, b) => a + b;
    internal static readonly Func<long, long, long> ISub = (a, b) => a - b;
    internal static readonly Func<long, long, long> IMul = (a, b) => a * b;
    internal static readonly Func<long, long, long> IMod = (a, b) => Number.LuaMath.IMod(a, b);
    internal static readonly Func<long, long, long> IIDiv = (a, b) => IFloorDiv(a, b);
    internal static readonly Func<long, long, long> BAnd = (a, b) => a & b;
    internal static readonly Func<long, long, long> BOr = (a, b) => a | b;
    internal static readonly Func<long, long, long> BXor = (a, b) => a ^ b;
    internal static readonly Func<long, long, long> Shl = ShiftLeft;
    internal static readonly Func<long, long, long> Shr = ShiftRight;
    internal static readonly Func<long, long, long> IUnm = (a, _) => -a;
    internal static readonly Func<long, long, long> BNot = (a, _) => ~a;

    // 浮点运算
    internal static readonly Func<double, double, double> FAdd = (a, b) => a + b;
    internal static readonly Func<double, double, double> FSub = (a, b) => a - b;
    internal static readonly Func<double, double, double> FMul = (a, b) => a * b;
    internal static readonly Func<double, double, double> FMod = (a, b) => Number.LuaMath.FMod(a, b);
    internal static readonly Func<double, double, double> Pow = Math.Pow;
    internal static readonly Func<double, double, double> Div = (a, b) => a / b;
    internal static readonly Func<double, double, double> FIDiv = (a, b) => FFloorDiv(a, b);
    internal static readonly Func<double, double, double> FUnm = (a, _) => -a;

    // 定义运算符结构体
    private struct Operator
    {
        public Func<long, long, long> IntegerFunc;
        public Func<double, double, double> FloatFunc;

        public Operator(Func<long, long, long> integerFunc,
                        Func<double, double, double> floatFunc)
        {
            IntegerFunc = integerFunc;
            FloatFunc = floatFunc;
        }
    }

    // 运算符表
    private static readonly Operator[] operators = new Operator[]
    {
            new Operator(IAdd, FAdd),  // LUA_OPADD
            new Operator(ISub, FSub),  // LUA_OPSUB
            new Operator(IMul, FMul),  // LUA_OPMUL
            new Operator(IMod, FMod),  // LUA_OPMOD
            new Operator(null, Pow),   // LUA_OPPOW
            new Operator(null, Div),   // LUA_OPDIV
            new Operator(IIDiv, FIDiv),// LUA_OPIDIV
            new Operator(BAnd, null),  // LUA_OPBAND
            new Operator(BOr, null),   // LUA_OPBOR
            new Operator(BXor, null),  // LUA_OPBXOR
            new Operator(Shl, null),   // LUA_OPSHL
            new Operator(Shr, null),   // LUA_OPSHR
            new Operator(IUnm, FUnm),  // LUA_OPUNM
            new Operator(BNot, null)   // LUA_OPBNOT
    };

    /// <summary>
    /// 执行算术运算
    /// </summary>
    public void Arith(ArithOp op)
    {
        object b = stack.Pop();
        object a;

        if (op != ArithOp.LUA_OPUNM && op != ArithOp.LUA_OPBNOT)
        {
            a = stack.Pop();
        }
        else
        {
            a = b;
        }

        Operator oper = operators[(int)op];
        object result = PerformArith(a, b, oper);

        if (result != null)
        {
            stack.Push(result);
        }
        else
        {
            throw new ArithmeticException("算术运算错误");
        }
    }

    private object PerformArith(object a, object b, Operator oper)
    {
        // 处理按位运算
        if (oper.FloatFunc == null)
        {
            var (x, ok1) = LuaValue.ToInteger(a);
            var (y, ok2) = LuaValue.ToInteger(b);
            if (ok1 && ok2)
            {
                return oper.IntegerFunc(x, y);
            }
        }
        else
        {
            // 处理混合类型运算
            if (oper.IntegerFunc != null)
            {
                if (a is long x && b is long y)
                {
                    return oper.IntegerFunc(x, y);
                }
            }

            // 尝试转换为浮点数运算
            var (xf, ok1) = LuaValue.ToFloat(a);
            var (yf, ok2) = LuaValue.ToFloat(b);
            if (ok1 && ok2)
            {
                return oper.FloatFunc(xf, yf);
            }
        }

        return null;
    }
}
