using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个整数数组 coins ，表示不同面额的硬币；以及一个整数 amount ，表示总金额。
计算并返回可以凑成总金额所需的 最少的硬币个数 。如果没有任何一种硬币组合能组成总金额，返回 -1 。
你可以认为每种硬币的数量是无限的。
 */
public class LeetCode_0322
{
    public static void Test()
    {
        LeetCode_0322 obj = new LeetCode_0322();
        Console.WriteLine(obj.CoinChange(new []{1, 2, 5},11));
        Console.WriteLine(obj.CoinChange(new []{2},3));
        Console.WriteLine(obj.CoinChange(new []{1},0));
    }
    
    public int CoinChange(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 0;
        for (int i = 1; i < dp.Length; i++)
        {
            dp[i] = 10001;
        }
        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = coins[i]; j <= amount; j++)
            {
                dp[j] = Math.Min(dp[j], dp[j - coins[i]] + 1);
            }
        }

        return dp[amount] == 10001? -1:dp[amount];
    }
}