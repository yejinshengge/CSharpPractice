namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个整数数组 nums，返回 nums 中最长等差子序列的长度。
 */
public class LeetCode_1027
{
    public static void Test()
    {
        LeetCode_1027 obj = new LeetCode_1027();
        Console.WriteLine(obj.LongestArithSeqLength(new []{3,6,9,12}));
        Console.WriteLine(obj.LongestArithSeqLength(new []{9,4,7,2,10}));
        Console.WriteLine(obj.LongestArithSeqLength(new []{20,1,15,3,10,5,8}));
    }
    
    public int LongestArithSeqLength(int[] nums)
    {
        Dictionary<int, int>[] dp = new Dictionary<int, int>[nums.Length];
        int maxLen = 0;
        dp[0] = new Dictionary<int, int>();
        for (int i = 1; i < nums.Length; i++)
        {
            dp[i] = new Dictionary<int, int>();
            for (int j = 0; j < i; j++)
            {
                int d = nums[i] - nums[j];
                if (dp[j].ContainsKey(d))
                    dp[i][d] = dp[j][d] + 1;
                else
                    dp[i][d] = 2;
                maxLen = Math.Max(maxLen, dp[i][d]);
            }
        }
        return maxLen;
    }
    
}