namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个非负整数数组 nums 和一个整数 target 。

向数组中的每个整数前添加 '+' 或 '-' ，然后串联起所有整数，可以构造一个 表达式 ：

例如，nums = [2, 1] ，可以在 2 之前添加 '+' ，在 1 之前添加 '-' ，然后串联起来得到表达式 "+2-1" 。
返回可以通过上述方法构造的、运算结果等于 target 的不同 表达式 的数目。
 */
public class LeetCode_0494
{
    public static void Test()
    {
        LeetCode_0494 obj = new LeetCode_0494();
        Console.WriteLine(obj.FindTargetSumWays(new []{1,1,1,1,1},3));
        Console.WriteLine(obj.FindTargetSumWays(new []{1},1));
    }
    
    public int FindTargetSumWays(int[] nums, int target)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        if (Math.Abs(target) > sum) return 0;
        if ((sum + target) % 2 != 0) return 0;
        int bagSize = (sum + target) / 2;
        int[] dp = new int[bagSize+1];
        dp[0] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = bagSize; j >= nums[i]; j--)
            {
                dp[j] += dp[j - nums[i]];
            }
        }

        return dp[bagSize];
    }
}