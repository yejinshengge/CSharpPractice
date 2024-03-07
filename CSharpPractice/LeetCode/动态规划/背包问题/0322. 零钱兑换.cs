namespace CSharpPractice.LeetCode.动态规划.背包问题;

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
        int[] dp = new int[amount+1];
        for (int i = 1; i <= amount; i++)
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

        if (dp[amount] >= 10001) return -1;
        return dp[amount];
    }
}