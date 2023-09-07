namespace CSharpPractice.LeetCode.动态规划;

/**
给定一个整数数组prices，其中第  prices[i] 表示第 i 天的股票价格 。
设计一个算法计算出最大利润。在满足以下约束条件下，你可以尽可能地完成更多的交易（多次买卖一支股票）:
卖出股票后，你无法在第二天买入股票 (即冷冻期为 1 天)。
注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
 */
public class LeetCode_0309
{
    public static void Test()
    {
        LeetCode_0309 obj = new LeetCode_0309();
        Console.WriteLine(obj.MaxProfit(new []{1,2,3,0,2}));
        Console.WriteLine(obj.MaxProfit(new []{1}));
        Console.WriteLine(obj.MaxProfit(new []{1,4,2,6,7,3,4,3,2,1,1,0,6}));
    }
    
    public int MaxProfit(int[] prices)
    {
        int[,] dp = new int[prices.Length, 3];
        dp[0, 0] = -prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            // 持有
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 2] - prices[i]);
            // 未持有
            dp[i, 1] = Math.Max(dp[i - 1, 0] + prices[i], Math.Max(dp[i - 1, 1], dp[i - 1, 2]));
            // 冷冻
            dp[i, 2] = dp[i - 1, 1];
        }

        return Math.Max(dp[prices.Length - 1, 1], dp[prices.Length - 1, 2]);
    }
}