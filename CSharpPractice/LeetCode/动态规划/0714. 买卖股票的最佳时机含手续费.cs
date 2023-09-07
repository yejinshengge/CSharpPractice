namespace CSharpPractice.LeetCode.动态规划;

/**
给定一个整数数组 prices，其中 prices[i]表示第 i 天的股票价格 ；整数 fee 代表了交易股票的手续费用。

你可以无限次地完成交易，但是你每笔交易都需要付手续费。如果你已经购买了一个股票，在卖出它之前你就不能再继续购买股票了。

返回获得利润的最大值。

注意：这里的一笔交易指买入持有并卖出股票的整个过程，每笔交易你只需要为支付一次手续费。
 */
public class LeetCode_0714
{
    public static void Test()
    {
        LeetCode_0714 obj = new LeetCode_0714();
        Console.WriteLine(obj.MaxProfit(new []{1, 3, 2, 8, 4, 9},2));
        Console.WriteLine(obj.MaxProfit(new []{1,3,7,5,10,3},3));
    }
    
    public int MaxProfit(int[] prices, int fee)
    {
        int[,] dp = new int[prices.Length, 2];
        dp[0, 0] = -prices[0];
        dp[0, 1] = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            // 持有
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] - prices[i]);
            // 未持有
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i] - fee);
        }

        return Math.Max(dp[prices.Length - 1, 0], dp[prices.Length - 1, 1]);
    }
}