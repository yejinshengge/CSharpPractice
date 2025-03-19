namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR104
{
    public static void Test()
    {
        LeetCode_LCR104 obj = new LeetCode_LCR104();
        Console.WriteLine(obj.CombinationSum4(new []{1,2,3},4));// 7
        Console.WriteLine(obj.CombinationSum4(new []{9},3));// 0
        Console.WriteLine(obj.CombinationSum4(new []{1},1));// 1
    }
    
    public int CombinationSum4(int[] nums, int target)
    {
        // 设dp[i]为凑成i的排列数
        int[] dp = new int[target+1];
        // 凑成0的排列数为1
        dp[0] = 1;
        // 先枚举目标值，再枚举硬币，相当于不固定硬币的顺序
        for (int i = 1; i <= target; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i >= nums[j])
                    dp[i] += dp[i - nums[j]];
            }
        }

        return dp[target];
    }
}