namespace CSharpPractice.LeetCode.动态规划.背包问题;

/**
 * 给你一个 只包含正整数 的 非空 数组 nums 。请你判断是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。
 */
public class LeetCode_0416
{
    public static void Test()
    {
        LeetCode_0416 obj = new LeetCode_0416();
        Console.WriteLine(obj.CanPartition1(new []{1,5,11,5}));
        Console.WriteLine(obj.CanPartition1(new []{1,2,3,5}));
    }
    
    public bool CanPartition(int[] nums)
    {
        int total = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            total += nums[i];
        }

        if ((total & 1) != 0) return false;
        int target = total >> 1;

        // dp[i,j] 前i个数能否凑成j
        bool[,] dp = new bool[nums.Length+1,target+1];
        // 递推公式
        // dp[i,j] = dp[i-1,j] || dp[i-1,j-nums[i]]
        // 初始状态 dp[0,0] = 1
        dp[0, 0] = true;
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                dp[i, j] = dp[i - 1, j];
                if (j >= nums[i - 1])
                    dp[i, j] |= dp[i - 1, j - nums[i-1]];
            }
        }

        return dp[nums.Length, target];
    }
    
    // 空间优化
    public bool CanPartition1(int[] nums)
    {
        int total = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            total += nums[i];
        }

        if ((total & 1) != 0) return false;
        int target = total >> 1;


        bool[] dp = new bool[target+1];
        dp[0] = true;
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = target; j >=1; j--)
            {
                dp[j] = dp[j];
                if (j >= nums[i - 1])
                    dp[j] |= dp[j - nums[i-1]];
            }
        }

        return dp[target];
    }
}