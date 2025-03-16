namespace CSharpToLua.Number;

/// <summary>
/// 提供Lua特有的数学运算支持
/// </summary>
public static class LuaMath
{
    /// <summary>
    /// 整数地板除法
    /// </summary>
    /// <param name="a">被除数</param>
    /// <param name="b">除数</param>
    /// <returns>地板除法结果</returns>
    public static long IFloorDiv(long a, long b)
    {
        if (a > 0 && b > 0 || a < 0 && b < 0 || a % b == 0)
        {
            return a / b;
        }
        else
        {
            return a / b - 1;
        }
    }

    /// <summary>
    /// 浮点数地板除法
    /// </summary>
    /// <param name="a">被除数</param>
    /// <param name="b">除数</param>
    /// <returns>地板除法结果</returns>
    public static double FFloorDiv(double a, double b)
    {
        return System.Math.Floor(a / b);
    }

    /// <summary>
    /// 整数取模运算
    /// </summary>
    /// <param name="a">被除数</param>
    /// <param name="b">除数</param>
    /// <returns">取模结果</returns>
    public static long IMod(long a, long b)
    {
        return a - IFloorDiv(a, b) * b;
    }

    /// <summary>
    /// 浮点数取模运算
    /// </summary>
    /// <param name="a">被除数</param>
    /// <param name="b">除数</param>
    /// <returns>取模结果</returns>
    public static double FMod(double a, double b)
    {
        return a - System.Math.Floor(a / b) * b;
    }

    /// <summary>
    /// 左移位运算，支持负数位移（转为右移）
    /// </summary>
    /// <param name="a">要移位的数</param>
    /// <param name="n">移位位数</param>
    /// <returns>移位结果</returns>
    public static long ShiftLeft(long a, long n)
    {
        if (n >= 0)
        {
            return a << (int)n;
        }
        else
        {
            return ShiftRight(a, -n);
        }
    }

    /// <summary>
    /// 右移位运算，支持负数位移（转为左移）
    /// </summary>
    /// <param name="a">要移位的数</param>
    /// <param name="n">移位位数</param>
    /// <returns>移位结果</returns>
    public static long ShiftRight(long a, long n)
    {
        if (n >= 0)
        {
            return (long)((ulong)a >> (int)n);
        }
        else
        {
            return ShiftLeft(a, -n);
        }
    }

    /// <summary>
    /// 尝试将浮点数转换为整数
    /// </summary>
    /// <param name="f">要转换的浮点数</param>
    /// <returns>转换结果和是否精确转换的标志</returns>
    public static (long, bool) FloatToInteger(double f)
    {
        long i = (long)f;
        return (i, (double)i == f);
    }
}

