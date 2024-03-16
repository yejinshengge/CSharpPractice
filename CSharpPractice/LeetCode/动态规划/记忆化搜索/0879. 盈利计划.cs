namespace CSharpPractice.LeetCode.动态规划.记忆化搜索;

/**
 * 集团里有 n 名员工，他们可以完成各种各样的工作创造利润。
    
    第 i 种工作会产生 profit[i] 的利润，它要求 group[i] 名成员共同参与。如果成员参与了其中一项工作，就不能参与另一项工作。
    
    工作的任何至少产生 minProfit 利润的子集称为 盈利计划 。并且工作的成员总数最多为 n 。
    
    有多少种计划可以选择？因为答案很大，所以 返回结果模 10^9 + 7 的值。
 */
public class LeetCode_0879
{
    public static void Test()
    {
        LeetCode_0879 obj = new LeetCode_0879();
        Console.WriteLine(obj.ProfitableSchemes2(5,3,new []{2,2},new []{2,3}));
        Console.WriteLine(obj.ProfitableSchemes2(10,5,new []{2,3,5},new []{6,7,8}));
    }
    
    public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
    {
        const int MOD = 1000000007;
        int[,,] dp = new int[group.Length+1,n+1,minProfit+1];
        dp[0, 0, 0] = 1;

        for (int i = 1; i <= profit.Length; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                for (int k = 0; k <= minProfit; k++)
                {
                    dp[i, j, k] = dp[i - 1, j, k];
                    if (j - group[i-1] >= 0)
                        dp[i, j, k] = (dp[i, j, k] + dp[i - 1, j - group[i-1], 
                            Math.Max(k - profit[i-1],0)])%MOD;
                }
            }
        }

        int total = 0;
        for (int i = 0; i <= n; i++)
        {
            total = (total + dp[group.Length, i, minProfit]) % MOD;
        }
        return total;
    }
    
    public int ProfitableSchemes2(int n, int minProfit, int[] group, int[] profit)
    {
        const int MOD = 1000000007;
        int[,] dp = new int[n+1,minProfit+1];
        dp[0, 0] = 1;

        for (int i = 1; i <= profit.Length; i++)
        {
            for (int j = n; j >= group[i-1]; j--)
            {
                for (int k = 0; k <= minProfit; k++)
                {
                    dp[j, k] = (dp[j, k] + dp[j - group[i-1], 
                        Math.Max(k - profit[i-1],0)])%MOD;
                }
            }
        }

        int total = 0;
        for (int i = 0; i <= n; i++)
        {
            total = (total + dp[i, minProfit]) % MOD;
        }
        return total;
    }
}