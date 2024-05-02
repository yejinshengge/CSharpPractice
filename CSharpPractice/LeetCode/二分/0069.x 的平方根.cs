namespace CSharpPractice.LeetCode.数组篇;
/**
给你一个非负整数 x ，计算并返回x的 算术平方根 。
由于返回类型是整数，结果只保留 整数部分 ，小数部分将被 舍去 。
注意：不允许使用任何内置指数函数和算符，例如 pow(x, 0.5) 或者 x ** 0.5 。
 */
public class LeetCode_0069
{
    public static void Test()
    {
        LeetCode_0069 obj = new LeetCode_0069();
        // Console.WriteLine(obj.MySqrt(4));
        // Console.WriteLine(obj.MySqrt(8));
        // Console.WriteLine(obj.MySqrt(10));
        // Console.WriteLine(obj.MySqrt(0));
        Console.WriteLine(obj.MySqrt(1));
    }

    public int MySqrt(int x)
    {
        if (x <=1) return x;
        int left = 0, right = x;
        while (left <= right)
        {
            int mid = (right - left) / 2 + left;
            var res = x / mid;
            if (res < mid)
                right = mid - 1;
            else if (res > mid)
                left = mid + 1;
            else
                return mid;
        }
        return left - 1;
    }
}