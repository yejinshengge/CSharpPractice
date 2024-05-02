namespace CSharpPractice.LeetCode.二分;

public class LeetCode_0029
{
    public static void Test()
    {
        LeetCode_0029 obj = new LeetCode_0029();
        Console.WriteLine(obj.Divide(10,3));
        Console.WriteLine(obj.Divide(7,-3));
    }
    
    public int Divide(int dividend, int divisor)
    {
        // 溢出
        if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
        // 记录符号
        bool flag = !((dividend < 0 && divisor > 0) 
                      || (dividend > 0 && divisor < 0));
        // 转为负值防止溢出
        if (dividend > 0)
            dividend = -dividend;
        if (divisor > 0)
            divisor = -divisor;

        int ans = 0;
        // 倍增乘法
        while (dividend <= divisor)
        {
            int tmp = divisor, count = 1;
            // 翻倍后也不能超过被除数剩余部分
            while (tmp >= dividend - tmp)
            {
                // 除数翻倍
                tmp += tmp;
                // 商翻倍
                count += count;
            }

            dividend -= tmp;
            ans += count;
        }

        return flag ? ans : -ans;
    }


}