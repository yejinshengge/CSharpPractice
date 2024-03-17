using System.Text;

namespace CSharpPractice.LeetCode.动态规划.背包问题;

/**
 * 给你一个整数数组 cost 和一个整数 target 。请你返回满足如下规则可以得到的 最大 整数：
    
    给当前结果添加一个数位（i + 1）的成本为 cost[i] （cost 数组下标从 0 开始）。
    总成本必须恰好等于 target 。
    添加的数位中没有数字 0 。
    由于答案可能会很大，请你以字符串形式返回。
    
    如果按照上述要求无法得到任何整数，请你返回 "0" 。
 */
public class LeetCode_1449
{
    public static void Test()
    {
        LeetCode_1449 obj = new LeetCode_1449();
        Console.WriteLine(obj.LargestNumber(new []{4,3,2,5,6,7,2,5,5},9));
    }
    
    public string LargestNumber(int[] cost, int target)
    {
        // 先求出目标字符串的最大长度
        int[] dp = new int[target+1];
        Array.Fill(dp,int.MinValue);
        dp[0] = 0;
        for (int i = 1; i <= 9; i++)
        {
            var u = cost[i - 1];
            for (int j = u; j <= target; j++)
            {
                dp[j] = Math.Max(dp[j], dp[j - u] + 1);
            }
        }
        if (dp[target] < 0) return "0";
        // 再从大开始选，利用dp数组回溯出字符串
        StringBuilder res = new StringBuilder();
        for (int i = 9; i >=1; i--)
        {
            var u = cost[i - 1];
            // 因为每个数可以选多次,所以用while
            while (target >= u && dp[target] == dp[target - u] + 1)
            {
                res.Append(i);
                target -= u;
            }
        }
        return res.ToString();
    }
    
}