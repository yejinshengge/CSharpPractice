namespace CSharpPractice.LeetCode.动态规划.背包问题;

/**
 * 给你一个整数数组 coins 表示不同面额的硬币，另给一个整数 amount 表示总金额。
    
    请你计算并返回可以凑成总金额的硬币组合数。如果任何硬币组合都无法凑出总金额，返回 0 。
    
    假设每一种面额的硬币有无限个。 
    
    题目数据保证结果符合 32 位带符号整数。
 */
public class LeetCode_0518
{
    public static void Test()
    {
        LeetCode_0518 obj = new LeetCode_0518();
        Console.WriteLine(obj.Change(5,new []{1, 2, 5}));
        Console.WriteLine(obj.Change(3,new []{2}));
        Console.WriteLine(obj.Change(10,new []{10}));
    }
    
    public int Change(int amount, int[] coins)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 1;
        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = coins[i]; j <= amount; j++)
            {
                dp[j] += dp[j - coins[i]];
            }
        }
        return dp[amount];
    }
}