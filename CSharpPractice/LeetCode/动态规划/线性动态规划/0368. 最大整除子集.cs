using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个由 无重复 正整数组成的集合 nums ，请你找出并返回其中最大的整除子集 answer ，子集中每一元素对 (answer[i], answer[j]) 都应当满足：
    answer[i] % answer[j] == 0 ，或
    answer[j] % answer[i] == 0
    如果存在多个有效解子集，返回其中任何一个均可。
 */
public class LeetCode_0368
{
    public static void Test()
    {
        LeetCode_0368 obj = new LeetCode_0368();
        Tools.PrintEnumerator(obj.LargestDivisibleSubset(new []{1,2,3}));
        Tools.PrintEnumerator(obj.LargestDivisibleSubset(new []{1,2,4,8}));
        Tools.PrintEnumerator(obj.LargestDivisibleSubset(new []{2,3,4,8}));
        Tools.PrintEnumerator(obj.LargestDivisibleSubset(new []{2,5,7}));
    }
    
    public IList<int> LargestDivisibleSubset2(int[] nums)
    {
        // 错误解法
        int dp = 1;
        int index = 0;
        int maxLen = 1;
        Array.Sort(nums);
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] % nums[i - 1] == 0)
                dp += 1;
            else
                dp = 1;
            if (dp > maxLen)
            {
                maxLen = dp;
                index = i;
            }
        }

        List<int> res = new List<int>();
        for (int i = index; i >= index-maxLen+1; i--)
        {
            res.Add(nums[i]);
        }

        return res;
    }
    
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        int[] dp = new int[nums.Length];
        int maxSize = 0;
        int maxVal = 0;
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0)
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }

            if (dp[i] > maxSize)
            {
                maxSize = dp[i];
                maxVal = nums[i];
            }
        }

        List<int> res = new List<int>();
        for (int i = nums.Length-1; i >=0 && maxSize > 0; i--)
        {
            if (dp[i] == maxSize && maxVal % nums[i] == 0)
            {
                res.Add(nums[i]);
                maxSize--;
                maxVal = nums[i];
            }
        }


        return res;
    }
}