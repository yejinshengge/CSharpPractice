using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给定一个未排序的整数数组 nums ， 返回最长递增子序列的个数 。
    
    注意 这个数列必须是 严格 递增的。
 */
public class LeetCode_0673
{
    public static void Test()
    {
        LeetCode_0673 obj = new LeetCode_0673();
        // Console.WriteLine(obj.FindNumberOfLIS(new []{1,3,5,4,7}));
        // Console.WriteLine(obj.FindNumberOfLIS(new []{2,2,2,2,2}));
        // Console.WriteLine(obj.FindNumberOfLIS(new []{2}));
        Console.WriteLine(obj.FindNumberOfLIS2(new []{1,2,4,3,5,4,7,2}));
    }
    
    public int FindNumberOfLIS2(int[] nums)
    {
        // 错误解法
        int maxLen = 0;
        int[] dp = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }

            maxLen = Math.Max(dp[i], maxLen);
        }
        Tools.PrintArr(dp);
        Array.Sort(dp);
        int res = 1, left = dp.Length - 1, right = dp.Length - 1;
        while (left >= 0)
        {
            if (dp[left] > maxLen)
            {
                left--;
                right--;
            }
            else if (dp[left] == maxLen)
            {
                left--;
            }
            else
            {
                res *= (right - left);
                maxLen--;
                right = left;
            }
        }

        res *= (right + 1);
        return res;
    }
    
    public int FindNumberOfLIS(int[] nums)
    {
        int maxLen = 0;
        int res = 0;
        int[] dp = new int[nums.Length];
        int[] cnt = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            cnt[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    // 遇到更长的序列
                    if (dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        cnt[i] = cnt[j];
                    } 
                    // 遇到一样长的序列
                    else if (dp[i] == dp[j] + 1)
                    {
                        cnt[i] += cnt[j];
                    }
                }
            }
            // 有更长的序列
            if (dp[i] > maxLen)
            {
                maxLen = dp[i];
                res = cnt[i];
            }
            // 有一样长的序列
            else if(dp[i] == maxLen)
            {
                res += cnt[i];
            }
            
        }
        return res;
    }
}