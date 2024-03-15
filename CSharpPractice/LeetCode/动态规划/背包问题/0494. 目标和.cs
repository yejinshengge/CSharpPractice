namespace CSharpPractice.LeetCode.动态规划.背包问题;

/**
 * 给你一个非负整数数组 nums 和一个整数 target 。
    
    向数组中的每个整数前添加 '+' 或 '-' ，然后串联起所有整数，可以构造一个 表达式 ：
    
    例如，nums = [2, 1] ，可以在 2 之前添加 '+' ，在 1 之前添加 '-' ，然后串联起来得到表达式 "+2-1" 。
    返回可以通过上述方法构造的、运算结果等于 target 的不同 表达式 的数目。
 */
public class LeetCode_0494
{
    public static void Test()
    {
        LeetCode_0494 obj = new LeetCode_0494();
        Console.WriteLine(obj.FindTargetSumWays3(new []{1,1,1,1,1},3));
        Console.WriteLine(obj.FindTargetSumWays3(new []{1},1));
    }
    
    public int FindTargetSumWays(int[] nums, int target)
    {
        int total = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            total += Math.Abs(nums[i]);
        }

        if (total < Math.Abs(target)) return 0;
        
        int[,] dp = new int[nums.Length+1,total*2+1];
        dp[0, total] = 1;

        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = -total; j <= total; j++)
            {
                if(j+nums[i-1]+total <= 2*total)
                    dp[i, j+total] += dp[i - 1, j + nums[i - 1]+total];
                if(j - nums[i - 1]+total >= 0)
                    dp[i, j+total] += dp[i - 1, j - nums[i - 1]+total];
            }
        }

        return dp[nums.Length, target+total];
    }
    
    public int FindTargetSumWays2(int[] nums, int target)
    {
        int total = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            total += nums[i];
        }

        if (total - target < 0 || (total - target) % 2 != 0)
            return 0;

        int negSum = (total - target) / 2;
        int[,] dp = new int[nums.Length+1,negSum+1];
        dp[0, 0] = 1;
        
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = 0; j <= negSum; j++)
            {
                dp[i, j] = dp[i - 1, j];
                if (j - nums[i - 1] >= 0)
                    dp[i, j] += dp[i - 1, j - nums[i - 1]];
            }
        }

        return dp[nums.Length, negSum];
    }
    
    public int FindTargetSumWays3(int[] nums, int target)
    {
        int total = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            total += nums[i];
        }

        if (total - target < 0 || (total - target) % 2 != 0)
            return 0;

        int negSum = (total - target) / 2;
        int[] dp = new int[negSum+1];
        dp[0] = 1;
        
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = negSum; j >=nums[i - 1]; j--)
            {
                dp[j] += dp[j - nums[i - 1]];
            }
        }

        return dp[negSum];
    }
}