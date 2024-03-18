namespace CSharpPractice.LeetCode.动态规划.背包问题;

/**
 * 给你一个 下标从 0 开始 的整数数组 nums ，返回满足下述条件的 不同 四元组 (a, b, c, d) 的 数目 ：

    nums[a] + nums[b] + nums[c] == nums[d] ，且
    a < b < c < d

 */
public class LeetCode_1995
{
    public static void Test()
    {
        LeetCode_1995 obj = new LeetCode_1995();
        Console.WriteLine(obj.CountQuadruplets2(new int[]{1,2,3,6}));
        Console.WriteLine(obj.CountQuadruplets2(new int[]{3,3,6,4,5}));
        Console.WriteLine(obj.CountQuadruplets2(new int[]{1,1,1,3,5}));
    }
    
    public int CountQuadruplets(int[] nums)
    {
        int[,,] dp = new int[nums.Length+1,101,5];
        dp[0, 0, 0] = 1;

        // 前i个元素
        for (int i = 1; i <= nums.Length; i++)
        {
            // 恰好凑成j
            for (int j = 0; j <= 100; j++)
            {
                // 枚举用了几个数
                for (int k = 0; k <=3; k++)
                {
                    dp[i, j, k] += dp[i - 1, j, k];
                    if (j - nums[i-1] >= 0 && k - 1 >= 0)
                        dp[i, j, k] += dp[i - 1, j - nums[i-1], k - 1];
                }
            }
        }

        int res = 0;
        for (int i = 3; i <= nums.Length; i++)
        {
            res += dp[i, nums[i-1], 3];
        }

        return res;
    }
    
    public int CountQuadruplets2(int[] nums)
    {
        int[,] dp = new int[101,5];
        dp[0, 0] = 1;
        int res = 0;
        // 前i个元素
        for (int i = 1; i <= nums.Length; i++)
        {
            res += dp[nums[i-1], 3];
            // 恰好凑成j
            for (int j = 100; j >= nums[i-1]; j--)
            {
                // 枚举用了几个数
                for (int k = 3; k >= 1; k--)
                {
                    dp[j, k] += dp[j - nums[i-1], k - 1];
                }
            }
        }
        return res;
    }
}