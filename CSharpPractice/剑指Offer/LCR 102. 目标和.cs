namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR102
{
    public static void Test()
    {
        LeetCode_LCR102 obj = new LeetCode_LCR102();
        Console.WriteLine(obj.FindTargetSumWays(new []{1,1,1,1,1},3));//5
        Console.WriteLine(obj.FindTargetSumWays(new []{1},1));//1
        Console.WriteLine(obj.FindTargetSumWays(new []{500,500,500},500));//3
    }
    
    public int FindTargetSumWays(int[] nums, int target)
    {
        // 找到可以凑成( target + sum ) / 2的方法
        int sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        sum = (sum + target);
        if (sum % 2 != 0) return 0;
        sum /= 2;
        // 设dp[i][j]为前i个数凑成j的方法数
        // 状态转移方程：dp[i][j] = dp[i-1][j] + dp[i-1][j-nums[i]]
        // 优化成滚动数组：dp[j] = dp[j] + dp[j-nums[i]]
        int[] dp = new int[sum+1];
        // 前0个数凑成0的方法数为1
        dp[0] = 1;
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = sum; j >= nums[i-1]; j--)
            {
                dp[j] += dp[j - nums[i - 1]];
            }
        }

        return dp[sum];
    }
}