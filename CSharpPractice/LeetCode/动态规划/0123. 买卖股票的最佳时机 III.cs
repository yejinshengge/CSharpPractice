namespace CSharpPractice.LeetCode.动态规划;

/**
给定一个数组，它的第 i 个元素是一支给定的股票在第 i 天的价格。
设计一个算法来计算你所能获取的最大利润。你最多可以完成 两笔 交易。
注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
 */
public class LeetCode_0123
{
    public static void Test()
    {
        LeetCode_0123 obj = new LeetCode_0123();
        Console.WriteLine(obj.MaxProfit(new []{3,3,5,0,0,3,1,4}));
        Console.WriteLine(obj.MaxProfit(new []{1,2,3,4,5}));
        Console.WriteLine(obj.MaxProfit(new []{7,6,4,3,1}));
        Console.WriteLine(obj.MaxProfit(new []{1}));
    }
    
    public int MaxProfit(int[] prices)
    {
        int[,] dp = new int[prices.Length,5];

        dp[0,1] = -prices[0];
        dp[0,3] = -prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            dp[i, 1] = Math.Max(dp[i - 1, 0] - prices[i], dp[i - 1, 1]);
            dp[i, 2] = Math.Max(dp[i - 1, 1] + prices[i], dp[i - 1, 2]);
            dp[i, 3] = Math.Max(dp[i - 1, 2] - prices[i], dp[i - 1, 3]);
            dp[i, 4] = Math.Max(dp[i - 1, 3] + prices[i], dp[i - 1, 4]);
        }

        return dp[prices.Length - 1, 4];
    }
}