namespace CSharpPractice.LeetCode.动态规划;

/**
你是一个专业的小偷，计划偷窃沿街的房屋，每间房内都藏有一定的现金。
这个地方所有的房屋都 围成一圈 ，这意味着第一个房屋和最后一个房屋是紧挨着的。
同时，相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警 。

给定一个代表每个房屋存放金额的非负整数数组，计算你 在不触动警报装置的情况下 ，今晚能够偷窃到的最高金额。
 */
public class LeetCode_0213
{
    public static void Test()
    {
        LeetCode_0213 obj = new LeetCode_0213();
        Console.WriteLine(obj.Rob(new []{2,3,2}));
        Console.WriteLine(obj.Rob(new []{1,2,3,1}));
        Console.WriteLine(obj.Rob(new []{1,2,3}));
    }
    
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0],nums[1]);
        return Math.Max(OnRob(nums, 0, nums.Length - 2), OnRob(nums, 1, nums.Length - 1));
    }

    private int OnRob(int[] nums, int start, int end)
    {
        int[] dp = new int[nums.Length];
        dp[start] = nums[start];
        dp[start + 1] = Math.Max(nums[start], nums[start + 1]);

        for (int i = start+2; i <= end; i++)
        {
            dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
        }

        return dp[end];
    }
}