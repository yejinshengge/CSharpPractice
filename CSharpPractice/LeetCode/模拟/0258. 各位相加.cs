namespace CSharpPractice.LeetCode.模拟;

/**
 * 给定一个非负整数 num，反复将各个位上的数字相加，直到结果为一位数。返回这个结果。
 */
public class LeetCode_0258
{
    public static void Test()
    {
        LeetCode_0258 obj = new LeetCode_0258();
        Console.WriteLine(obj.AddDigits(38));
        Console.WriteLine(obj.AddDigits(0));
        Console.WriteLine(obj.AddDigits(int.MaxValue));
    }
    
    public int AddDigits(int num)
    {
        if (num == 0) return 0;
        int res = num % 9;
        return res == 0 ? 9:res;
    }
    
    public int AddDigits2(int num) {
        return (num - 1) % 9 + 1;
    }
}