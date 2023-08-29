namespace CSharpPractice.LeetCode.动态规划;

/**
给定一个正整数 n ，将其拆分为 k 个 正整数 的和（ k >= 2 ），并使这些整数的乘积最大化。
返回 你可以获得的最大乘积 。
 */
public class LeetCode_0343
{
    public static void Test()
    {
        LeetCode_0343 obj = new LeetCode_0343();
        Console.WriteLine(obj.IntegerBreak(2));
        Console.WriteLine(obj.IntegerBreak(10));
    }
    
    public int IntegerBreak(int n)
    {
        int[] arr = new int[n + 1];
        arr[2] = 1;
        for (int i = 3; i <= n; i++)
        {
            for (int j = 1; j <= i/2; j++)
            {
                arr[i] = Math.Max(arr[i], Math.Max((i - j) * j, arr[i - j] * j));
            }
        }

        return arr[n];
    }
}