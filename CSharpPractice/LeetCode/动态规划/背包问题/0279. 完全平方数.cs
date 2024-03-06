namespace CSharpPractice.LeetCode.动态规划.背包问题;

/**
 * 给你一个整数 n ，返回 和为 n 的完全平方数的最少数量 。
    
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
        int start = 1;
        while (start*start <= n)
        {
            nums.Add(start*start);
            start++;
        }

        int numsLen = nums.Count;
        // dp[i,j] 前i个数凑出j的最少数量
        int[,] dp = new int[numsLen+1, n + 1];
        for (int i = 0; i <= numsLen; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                dp[i, j] = 10001;
            }
        }
        
        for (int i = 1; i <= numsLen; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                dp[i, j] = dp[i - 1, j];
                for (int k = 1; nums[i-1]*k <= j; k++)
                {
                    dp[i, j] = Math.Min(dp[i, j - k * nums[i-1]] + k, dp[i, j]);
                }
            }
        }

        return dp[nums.Count, n];
    }
    
    public int NumSquares2(int n)
    {
        List<int> nums = new List<int>();
        int start = 1;
        while (start*start <= n)
        {
            nums.Add(start*start);
            start++;
        }

        int numsLen = nums.Count;
        int[] dp = new int[n + 1];

        for (int j = 1; j <= n; j++)
        {
            dp[j] = 10001;
        }
        
        
        for (int i = 1; i <= numsLen; i++)
        {
            for (int j = nums[i-1]; j <=n; j++)
            {
                dp[j] = Math.Min(dp[j - nums[i-1]] + 1, dp[j]);
            }
        }

        return dp[n];
    }
}