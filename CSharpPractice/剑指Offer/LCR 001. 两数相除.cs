namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR001
{
    public static void Test()
    {
        LeetCode_LCR001 obj = new LeetCode_LCR001();
        // Console.WriteLine(obj.Divide(15,2));
        // Console.WriteLine(obj.Divide(7,-3));
        // Console.WriteLine(obj.Divide(0,1));
        // Console.WriteLine(obj.Divide(1,1));
        // Console.WriteLine(obj.Divide(int.MinValue,-1));
        Console.WriteLine(obj.Divide1(-2147483648,1));
    }
    
    public int Divide1(int a, int b)
    {
        // 防止溢出
        if (a == int.MinValue && b == -1)
            return int.MaxValue;
        // 统一符号
        bool flag = (a < 0 && b > 0) || (a > 0 && b < 0);
        int dividend = a > 0 ? -a : a;
        int divisor = b > 0 ? -b : b;
        int res = 0;
        while (dividend <= divisor)
        {
            int value = divisor;
            int quotient = 1;
            // 加法倍增 0xc0000000就是int.MinValue/2
            while (value >= 0xc0000000 && dividend <= value<<1 )
            {
                value <<=1;
                quotient<<=1;
            }

            res += quotient;
            dividend -= value;
        }

        return flag?-res:res;
    }
    
    public int Divide(int a, int b)
    {
        if (b == 1) return a;
        if (a == int.MinValue && b == -1)
            return int.MaxValue; // 处理溢出情况
        
        // 利用异或判断结果正负
        bool isNegative = (a < 0) ^ (b < 0);

        // 将操作数转为负数避免溢出
        int dividend = a > 0 ? -a : a;
        int divisor = b > 0 ? -b : b;
        int result = 0;

        // 从最大可能的2的幂次开始尝试，直到找到小于或等于被除数的最大2的幂次
        int maxBit = 1;
        while (divisor >= int.MinValue >> 1 && dividend <= divisor << 1) {
            divisor <<= 1;
            maxBit <<= 1;
        }

        // 现在从最大幂次开始，逐步试探减小被除数
        while (maxBit > 0 && dividend <= 0) {
            if (dividend <= divisor) {
                dividend -= divisor;
                result -= maxBit;
            }
            divisor >>= 1;
            maxBit >>= 1;
        }

        // 考虑结果的正负
        return isNegative ? result : -result;
    }
}