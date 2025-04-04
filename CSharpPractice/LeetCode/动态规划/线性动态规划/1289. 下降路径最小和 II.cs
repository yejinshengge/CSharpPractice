using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个 n x n 整数矩阵 grid ，请你返回 非零偏移下降路径 数字和的最小值。
    
    非零偏移下降路径 定义为：从 grid 数组中的每一行选择一个数字，且按顺序选出来的数字中，相邻数字不在原数组的同一列。
 */
public class LeetCode_1289
{
    public static void Test()
    {
        LeetCode_1289 obj = new LeetCode_1289();
        Console.WriteLine(obj.MinFallingPathSum2(Tools.ConstructTArray("[[1,2,3],[4,5,6],[7,8,9]]")));
        Console.WriteLine(obj.MinFallingPathSum2(Tools.ConstructTArray("[[50,-18,-38,39,-20,-37,-61,72,22,79],[82,26,30,-96,-1,28,87,94,34,-89],[55,-50,20,76,-50,59,-58,85,83,-83],[39,65,-68,89,-62,-53,74,2,-70,-90],[1,57,-70,83,-91,-32,-13,49,-11,58],[-55,83,60,-12,-90,-37,-36,-27,-19,-6],[76,-53,78,90,70,62,-81,-94,-32,-57],[-32,-85,81,25,80,90,-24,10,27,-55],[39,54,39,34,-45,17,-2,-61,-81,85],[-77,65,76,92,21,68,78,-13,39,22]]")));
        Console.WriteLine(obj.MinFallingPathSum2(Tools.ConstructTArray("[[7]]")));
    }
    
    public int MinFallingPathSum(int[][] grid)
    {
        var n = grid.Length;
        // 设dp[i][j]表示第i行选择j时，前i行的最短非零偏移下降路径和
        int[][] dp = new int[n][];
        // 初始化第一行
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
            dp[0][i] = grid[0][i];
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i][j] = int.MaxValue;
                // 选择i-1行每一列的情况
                for (int k = 0; k < n; k++)
                {
                    if(k == j)
                        continue;
                    dp[i][j] = Math.Min(dp[i][j], dp[i - 1][k] + grid[i][j]);
                }
            }
        }
        // 找出最后一行最小值
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            min = Math.Min(dp[n - 1][i], min);
        }

        return min;
    }

    public int MinFallingPathSum2(int[][] grid)
    {
        var n = grid.Length;
        // 设dp[i][j]表示第i行选择j时，前i行的最短非零偏移下降路径和
        int[][] dp = new int[n][];
        // 初始化第一行
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
            dp[0][i] = grid[0][i];
        }
        
        for (int i = 1; i < n; i++)
        {
            // 找出上一行最小、次小的元素缓存下来
            int minIndex = -1, minLen = int.MaxValue;
            int secondLen = int.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (dp[i - 1][j] < minLen)
                {
                    secondLen = minLen;
                    minIndex = j;
                    minLen = dp[i - 1][j];
                    
                }
                else if (dp[i - 1][j] < secondLen)
                {
                    secondLen = dp[i - 1][j];
                }
            }

            for (int j = 0; j < n; j++)
            {
                // 当前列与前一行最小列重合，选择次小列
                if (j == minIndex)
                    dp[i][j] = secondLen + grid[i][j];
                else
                    dp[i][j] = minLen + grid[i][j];
            }
        }
        // 找出最后一行最小值
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            min = Math.Min(dp[n - 1][i], min);
        }
        return min;
    }
}