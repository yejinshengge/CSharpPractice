namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你一个整数数组 prices ，其中prices[i] 表示某支股票第 i 天的价格。
 * 在每一天，你可以决定是否购买和/或出售股票。你在任何时候最多只能持有 一股 股票。
 * 你也可以先购买，然后在 同一天 出售。返回 你能获得的 最大 利润。
 */
public class LeetCode_002
{
    public static void LeetCode_002Main()
    {
        LeetCode_002 obj = new LeetCode_002();
        int[] arr = new[] {7,6,4,3,1};
        Console.WriteLine(obj.MaxProfit1(arr));
    }
    // 思路:只要明天股票涨就持有,跌就抛售
    public int MaxProfit(int[] prices)
    {
        int max = 0;
        for (int i = 0; i < prices.Length-1; i++)
        {
            // 明天股票涨了,买入
            if (prices[i] < prices[i + 1])
                max += prices[i + 1] - prices[i];
        }
        return max;
    }

    // ______________________复习_________________________
    public int MaxProfit1(int[] prices)
    {
        int res = 0;
        for (int i = 0; i < prices.Length-1; i++)
        {
            if (prices[i + 1] > prices[i])
            {
                res += prices[i + 1] - prices[i];
            }
        }

        return res;
    }
}