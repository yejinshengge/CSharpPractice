namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个整数 n ，返回 和为 n 的完全平方数的最少数量 。

完全平方数 是一个整数，其值等于另一个整数的平方；换句话说，其值等于一个整数自乘的积。
例如，1、4、9 和 16 都是完全平方数，而 3 和 11 不是。
 */
public class LeetCode_0279
{
    public static void Test()
    {
        LeetCode_0279 obj = new LeetCode_0279();
        Console.WriteLine(obj.NumSquares(12));
        Console.WriteLine(obj.NumSquares(13));
    }
    
    public int NumSquares(int n)
    {
        List<int> nums = new List<int>();
        var target = Math.Sqrt(n);

        for (int i = 1; i <= target; i++)
        {
            nums.Add(i*i);
        }

        int[] dp = new int[n + 1];
        for (int i = 1; i < dp.Length; i++)
        {
            dp[i] = n + 1;
        }

        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = nums[i]; j <= n; j++)
            {
                dp[j] = Math.Min(dp[j], dp[j - nums[i]] + 1);
            }
        }

        return dp[n];
    }
}