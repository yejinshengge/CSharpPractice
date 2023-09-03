namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个由 不同 整数组成的数组 nums ，和一个目标整数 target 。
请你从 nums 中找出并返回总和为 target 的元素组合的个数。
题目数据保证答案符合 32 位整数范围。
 */
public class LeetCode_0377
{
    public static void Test()
    {
        LeetCode_0377 obj = new LeetCode_0377();
        Console.WriteLine(obj.CombinationSum4(new []{1,2,3},4));
        Console.WriteLine(obj.CombinationSum4(new []{9},3));
        
    }
    
    public int CombinationSum4(int[] nums, int target)
    {
        int[] dp = new int[target+1];
        dp[0] = 1;
        for (int i = 0; i <= target; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i >= nums[j]) dp[i] += dp[i - nums[j]];
            }
        }
        return dp[target];
    }
}