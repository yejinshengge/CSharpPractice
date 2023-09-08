namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个整数数组 nums ，找到其中最长严格递增子序列的长度。

子序列 是由数组派生而来的序列，删除（或不删除）数组中的元素而不改变其余元素的顺序。
例如，[3,6,2,7] 是数组 [0,3,1,6,2,2,7] 的子序列。
 */
public class LeetCode_0300
{
    public static void Test()
    {
        LeetCode_0300 obj = new LeetCode_0300();
        Console.WriteLine(obj.LengthOfLIS(new []{10,9,2,5,3,7,101,18}));
        Console.WriteLine(obj.LengthOfLIS(new []{0,1,0,3,2,3}));
        Console.WriteLine(obj.LengthOfLIS(new []{7,7,7,7,7,7,7}));
        Console.WriteLine(obj.LengthOfLIS(new []{1}));
    }
    
    public int LengthOfLIS(int[] nums)
    {
        if (nums.Length <= 1) return nums.Length;
        int[] dp = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
        }

        int res = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j]) dp[i] = Math.Max(dp[i], dp[j] + 1);
            }

            res = Math.Max(res, dp[i]);
        }

        return res;
    }
}