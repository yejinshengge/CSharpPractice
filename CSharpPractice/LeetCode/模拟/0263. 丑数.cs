namespace CSharpPractice.LeetCode.模拟;

/**
 * 丑数 就是只包含质因数 2、3 和 5 的正整数。

    给你一个整数 n ，请你判断 n 是否为 丑数 。如果是，返回 true ；否则，返回 false 。
 */
public class LeetCode_0263
{
    public static void Test()
    {
        LeetCode_0263 obj = new LeetCode_0263();
        Console.WriteLine(obj.IsUgly(6));
        Console.WriteLine(obj.IsUgly(1));
        Console.WriteLine(obj.IsUgly(14));
    }
    
    public bool IsUgly(int n)
    {
        if (n <= 0) return false;
        while (n % 2 == 0) n /= 2;
        while (n % 3 == 0) n /= 3;
        while (n % 5 == 0) n /= 5;
        if (n == 1) return true;
        return false;
    }
}