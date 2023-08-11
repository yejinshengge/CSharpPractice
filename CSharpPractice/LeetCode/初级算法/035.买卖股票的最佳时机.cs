namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给定一个数组 prices ，它的第i 个元素prices[i] 表示一支给定股票第 i 天的价格。
 * 你只能选择 某一天 买入这只股票，并选择在 未来的某一个不同的日子 卖出该股票。设计一个算法来计算你所能获取的最大利润。
 * 返回你可以从这笔交易中获取的最大利润。如果你不能获取任何利润，返回 0 。
 */
public class LeetCode_035
{
    public static void Test()
    {
        LeetCode_035 obj = new LeetCode_035();
        Console.WriteLine(obj.MaxProfit3(new []{7,6,4,3,1}));
    }

    // 思路一:双层循环,超时
    public int MaxProfit(int[] prices)
    {
        int max = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i+1; j < prices.Length; j++)
            {
                max = Math.Max(prices[j] - prices[i],max);
            }
        }
        return max;
    }

    // 思路二:动态规划
    public int MaxProfit2(int[] prices)
    {
        // 第0列为未持有股票的最大利润,第一列为持有股票时的最大利润
        int[,] arr = new int[prices.Length,2];

        arr[0, 0] = 0;
        arr[0, 1] = -prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            arr[i, 0] = Math.Max(arr[i - 1, 0], arr[i - 1, 1] + prices[i]);
            arr[i, 1] = Math.Max(arr[i - 1, 1], - prices[i]);
        }

        return arr[prices.Length - 1, 0];
    }

    // 对思路二的优化,不需要二维数组
    public int MaxProfit3(int[] prices)
    {
        // 第0列为未持有股票的最大利润,第一列为持有股票时的最大利润
        int hold = -prices[0];
        int unHold = 0;
        
        for (int i = 1; i < prices.Length; i++)
        {
            int todayHold = Math.Max(-prices[i], hold);
            int todayUnHold = Math.Max(unHold, hold + prices[i]);
            hold = todayHold;
            unHold = todayUnHold;
        }

        return unHold;
    }
    // 错误,只能买卖一次
    private int Process2(int[] prices, int day,int cur, bool isHold)
    {
        if (day >= prices.Length) return cur;
        // 当前持有股票,可以卖出或继续持有
        if (isHold)
            return Math.Max(Process2(prices, day + 1, cur + prices[day], false), 
                Process2(prices, day + 1, cur, true));
        // 当前未持有股票,可以买入,也可以观望
        else
            return Math.Max(Process2(prices, day + 1, cur - prices[day], true), 
                Process2(prices, day + 1, cur, false));
        
    }
}