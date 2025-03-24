namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR103
{
    public static void Test()
    {
        LeetCode_LCR103 obj = new LeetCode_LCR103();
        Console.WriteLine(obj.CoinChange(new []{1, 2, 5},11));
        Console.WriteLine(obj.CoinChange(new []{2},3));
        Console.WriteLine(obj.CoinChange(new []{1},0));
        Console.WriteLine(obj.CoinChange(new []{1},1));
        Console.WriteLine(obj.CoinChange(new []{1},2));
    }
    
    public int CoinChange2(int[] coins, int amount)
    {
        // 设dp[i][j]为前i种硬币凑成j的方法数
        int[,] dp = new int[coins.Length+1,amount+1];
        // 一种硬币都不选，凑成任何金额都是0 即dp[0][j] = 0
        // 其他初始化为最大值
        for (int i = 0; i <= coins.Length; i++)
        {
            for (int j = 1; j <= amount; j++)
            {
                dp[i, j] = amount + 1;
            }
        }
        
        for (int i = 1; i <= coins.Length; i++)
        {
            for (int j = 1; j <= amount; j++)
            {
                // 不使用当前硬币
                dp[i, j] = dp[i - 1, j];
                // 使用当前硬币，之前可能也选过这种硬币
                if (j >= coins[i - 1])
                    dp[i, j] = Math.Min(dp[i,j],dp[i, j - coins[i - 1]]+1);
            }
        }

        return dp[coins.Length, amount] > amount ? -1:dp[coins.Length, amount];
    }
    
    public int CoinChange(int[] coins, int amount)
    {
        int[] dp = new int[amount+1];

        for (int j = 1; j <= amount; j++)
        {
            dp[j] = amount + 1;
        }
        
        
        for (int i = 1; i <= coins.Length; i++)
        {
            for (int j = coins[i - 1]; j <= amount; j++)
            {
                // 依赖的是同一行，不需要从后往前遍历
                dp[j] = Math.Min(dp[j],dp[j - coins[i - 1]]+1);
            }
        }

        return dp[amount] > amount ? -1:dp[amount];
    }
}