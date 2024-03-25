namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给定一个未排序的整数数组 nums ， 返回最长递增子序列的个数 。

    注意 这个数列必须是 严格 递增的。
 */
public class LeetCode_0673
{
    public static void Test()
    {
        LeetCode_0673 obj = new LeetCode_0673();
        Console.WriteLine(obj.FindNumberOfLIS(new []{1,3,5,4,7}));
        Console.WriteLine(obj.FindNumberOfLIS(new []{2,2,2,2,2}));
        Console.WriteLine(obj.FindNumberOfLIS(new []{1,2,4,3,5,4,7,2}));
    }
    public int FindNumberOfLIS(int[] nums)
    {
        int[] dp = new int[nums.Length + 1];
        int[] counts = new int[nums.Length + 1];
        int maxCount = 0;
        int maxLen = 0;
        for (int i = 1; i <= nums.Length; i++)
        {
            dp[i] = 1;
            counts[i] = 1;
            for (int j = 1; j < i; j++)
            {
                if (nums[i - 1] > nums[j - 1])
                {
                    // 遇到更长的序列
                    if (dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        counts[i] = counts[j];
                    }
                    // 遇到一样长的序列
                    else if (dp[i] == dp[j] + 1)
                    {
                        counts[i] += counts[j];
                    }
                }
            }

            if (dp[i] > maxLen)
            {
                maxLen = dp[i];
                maxCount = counts[i];
            }
            else if (dp[i] == maxLen)
            {
                maxCount += counts[i];
            }
            
        }
        return maxCount;
    }
    
    
    //错误解法
    public int FindNumberOfLIS1(int[] nums)
    {
        int[] dp = new int[nums.Length + 1];
        int maxCount = 0;
        int maxLen = 0;
        for (int i = 1; i <= nums.Length; i++)
        {
            dp[i] = 1;
            for (int j = 1; j < i; j++)
            {
                if (nums[i - 1] > nums[j - 1])
                {
                    dp[i] = Math.Max(dp[i],dp[j] + 1);
                }
                else if (nums[i - 1] == nums[j - 1])
                {
                    dp[i] = Math.Max(dp[i],dp[j]);
                }
                if (dp[i] > maxLen)
                {
                    maxLen = dp[i];
                    maxCount = 1;
                }
                else if (dp[i] == maxLen)
                {
                    maxCount++;
                }
                
            }
            
        }

        return maxCount;
    }
}