namespace CSharpPractice.LeetCode.位运算;

/**
给你两个整数，被除数 dividend 和除数 divisor。将两数相除，要求 不使用 乘法、除法和取余运算。

整数除法应该向零截断，也就是截去（truncate）其小数部分。例如，8.345 将被截断为 8 ，-2.7335 将被截断至 -2 。

返回被除数 dividend 除以除数 divisor 得到的 商 。

注意：假设我们的环境只能存储 32 位 有符号整数，其数值范围是 [−231,  231 − 1] 。本题中，如果商 严格大于 231 − 1 ，
则返回 231 − 1 ；如果商 严格小于 -231 ，则返回 -231 。

 */
public class LeetCode_0029
{
    public static void Test()
    {
        LeetCode_0029 obj = new LeetCode_0029();
        Console.WriteLine(obj.Divide(10,3));
        Console.WriteLine(obj.Divide(7,-3));
        Console.WriteLine(obj.Divide(int.MaxValue,int.MinValue));
        Console.WriteLine(obj.Divide(int.MinValue,int.MaxValue));
        Console.WriteLine(obj.Divide(0,int.MaxValue));
    }
    
    public int Divide(int dividend, int divisor)
    {
        // 最小值/-1会越界
        if (dividend == int.MinValue && divisor == -1)
            return int.MaxValue;
        
        bool isPos = (dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0);
        dividend = dividend > 0 ? -dividend : dividend;
        divisor = divisor > 0 ? -divisor : divisor;

        if (dividend > divisor) return 0;
        int res = _doDivide(dividend, divisor);
        return isPos ? res : -res;
    }

    private int _doDivide(int a,int b)
    {
        if (a > b) return 0;
        int count = 1;
        int tb = b;

        while (tb>= a-tb)
        {
            count += count;
            tb += tb;
        }

        return count + _doDivide(a - tb, b);
    }
}