namespace CSharpPractice.LeetCode.动态规划.背包问题;

/**
 * 给你一个二进制字符串数组 strs 和两个整数 m 和 n 。
    
    请你找出并返回 strs 的最大子集的长度，该子集中 最多 有 m 个 0 和 n 个 1 。
    
    如果 x 的所有元素也是 y 的元素，集合 x 是集合 y 的 子集 。
 */
public class LeetCode_0474
{
    public static void Test()
    {
        LeetCode_0474 obj = new LeetCode_0474();
        Console.WriteLine(obj.FindMaxForm2(new []{"10", "0001", "111001", "1", "0"},5,3));
        Console.WriteLine(obj.FindMaxForm2(new []{"10", "0", "1"},1,1));
    }
    
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int[,,] dp = new int[strs.Length+1,m+1,n+1];
        int[,] cnt = new int[strs.Length,2];
        for (int i = 0; i < strs.Length; i++)
        {
            foreach (var c in strs[i])
            {
                if (c == '0') cnt[i, 0]++;
                else cnt[i, 1]++;
            }
        }
        

        for (int i = 1; i <= strs.Length; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                for (int k = 0; k <= n; k++)
                {
                    if (j >= cnt[i - 1, 0] && k >= cnt[i - 1, 1])
                        dp[i, j, k] = Math.Max(dp[i - 1, j - cnt[i - 1, 0], k - cnt[i - 1, 1]] + 1, dp[i - 1, j, k]);
                    else
                        dp[i, j, k] = dp[i - 1, j, k];
                }
            }
        }

        return dp[strs.Length, m, n];
    }

    public int FindMaxForm2(string[] strs, int m, int n)
    {
        int[,] dp = new int[m+1,n+1];
        int[,] cnt = new int[strs.Length,2];
        for (int i = 0; i < strs.Length; i++)
        {
            foreach (var c in strs[i])
            {
                if (c == '0') cnt[i, 0]++;
                else cnt[i, 1]++;
            }
        }
        

        for (int i = 1; i <= strs.Length; i++)
        {
            for (int j = m; j >=cnt[i - 1, 0]; j--)
            {
                for (int k = n; k >= cnt[i - 1, 1]; k--)
                {
                    dp[j, k] = Math.Max(dp[j - cnt[i - 1, 0], k - cnt[i - 1, 1]] + 1, dp[j, k]);
                }
            }
        }

        return dp[m, n];
    }
}