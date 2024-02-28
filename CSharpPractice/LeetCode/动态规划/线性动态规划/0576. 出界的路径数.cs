namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个大小为 m x n 的网格和一个球。球的起始坐标为 [startRow, startColumn] 。
 * 你可以将球移到在四个方向上相邻的单元格内（可以穿过网格边界到达网格之外）。你 最多 可以移动 maxMove 次球。
    
    给你五个整数 m、n、maxMove、startRow 以及 startColumn ，找出并返回可以将球移出边界的路径数量。
    因为答案可能非常大，返回对 109 + 7 取余 后的结果。
 */
public class LeetCode_0576
{
    public static void Test()
    {
        LeetCode_0576 obj = new LeetCode_0576();
        Console.WriteLine(obj.FindPaths(2,2,2,0,0));
        Console.WriteLine(obj.FindPaths(1,3,3,0,1));
    }

    private int MOD = 1000000007;
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        int[,,] dp = new int[m,n,maxMove+1];

        for (int i = 0; i < m; i++)
        {
            for (int j = 1; j <= maxMove; j++)
            {
                dp[i, 0, j]++;
                dp[i, n-1, j]++;
            }
        }
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j <= maxMove; j++)
            {
                dp[0, i, j]++;
                dp[m-1, i, j]++;
            }
        }

        for (int step = 1; step <= maxMove; step++)
        {
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (x - 1 >= 0)
                        dp[x, y, step] = (dp[x, y, step]+dp[x - 1, y, step - 1])%MOD;
                    if ( x + 1 < m)
                        dp[x, y, step] = (dp[x, y, step]+dp[x + 1, y, step - 1])%MOD;
                    if (y - 1 >= 0)
                        dp[x, y, step] = (dp[x, y, step]+dp[x, y-1, step - 1])%MOD;
                    if (y+1 < n)
                        dp[x, y, step] = (dp[x, y, step]+dp[x, y+1, step - 1])%MOD;
                }
            }
        }

        return dp[startRow, startColumn, maxMove];
    }
}