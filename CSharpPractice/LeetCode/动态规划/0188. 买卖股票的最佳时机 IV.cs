namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个整数数组 prices 和一个整数 k ，其中 prices[i] 是某支给定的股票在第 i 天的价格。

设计一个算法来计算你所能获取的最大利润。你最多可以完成 k 笔交易。也就是说，你最多可以买 k 次，卖 k 次。

注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
 */
public class LeetCode_0188
{
    public static void Test()
    {
        LeetCode_0188 obj = new LeetCode_0188();
        Console.WriteLine(obj.MaxProfit(2,new []{2,4,1}));
        Console.WriteLine(obj.MaxProfit(2,new []{3,2,6,5,0,3}));
    }
    
    public int MaxProfit(int k, int[] prices)
    {
        int statusNum = 2 * k + 1;
        int[,] dp = new int[prices.Length, statusNum];
        for (int i = 1; i < statusNum; i+=2)
        {
            dp[0, i] = -prices[0];
        }

        for (int i = 1; i < prices.Length; i++)
        {
            for (int j = 1; j < statusNum; j++)
            {
                if (j % 2 == 1)
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - 1] - prices[i]);
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - 1] + prices[i]);
            }
        }

        return dp[prices.Length - 1, statusNum-1];
    }
}