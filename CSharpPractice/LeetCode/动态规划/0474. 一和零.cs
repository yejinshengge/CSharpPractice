namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个二进制字符串数组 strs 和两个整数 m 和 n 。
请你找出并返回 strs 的最大子集的长度，该子集中 最多 有 m 个 0 和 n 个 1 。
如果 x 的所有元素也是 y 的元素，集合 x 是集合 y 的 子集 。
 */
public class LeetCode_0474
{
    public static void Test()
    {
        LeetCode_0474 obj = new LeetCode_0474();
        Console.WriteLine(obj.FindMaxForm(new []{"10", "0001", "111001", "1", "0"},5,3));
        Console.WriteLine(obj.FindMaxForm(new []{"10", "0", "1"},1,1));
    }
    
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int[][] dp = new int[m+1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n+1];
        }
        for (int k = 0;k<strs.Length;k++ )
        {
            int oneNum = 0, zeroNum = 0;
            for (int i = 0; i < strs[k].Length; i++)
            {
                if (strs[k][i] == '1')
                    oneNum++;
                else
                    zeroNum++;
            }

            for (int i = n; i >= oneNum; i--)
            {
                for (int j = m; j >= zeroNum; j--)
                {
                    dp[j][i] = Math.Max(dp[j][i], dp[j - zeroNum][i - oneNum] + 1);
                }
            }
        }

        return dp[m][n];
    }
}