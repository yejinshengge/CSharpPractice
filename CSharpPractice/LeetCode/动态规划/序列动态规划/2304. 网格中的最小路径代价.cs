using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个下标从 0 开始的整数矩阵 grid ，矩阵大小为 m x n ，由从 0 到 m * n - 1 的不同整数组成。你可以在此矩阵中，从一个单元格移动到 下一行 的任何其他单元格。如果你位于单元格 (x, y) ，且满足 x < m - 1 ，你可以移动到 (x + 1, 0), (x + 1, 1), ..., (x + 1, n - 1) 中的任何一个单元格。注意： 在最后一行中的单元格不能触发移动。

每次可能的移动都需要付出对应的代价，代价用一个下标从 0 开始的二维数组 moveCost 表示，该数组大小为 (m * n) x n ，其中 moveCost[i][j] 是从值为 i 的单元格移动到下一行第 j 列单元格的代价。从 grid 最后一行的单元格移动的代价可以忽略。

grid 一条路径的代价是：所有路径经过的单元格的 值之和 加上 所有移动的 代价之和 。从 第一行 任意单元格出发，返回到达 最后一行 任意单元格的最小路径代价。
 */
public class LeetCode_2304
{
    public static void Test()
    {
        LeetCode_2304 obj = new LeetCode_2304();
        Console.WriteLine(obj.MinPathCost(Tools.ConstructTArray("[[5,3],[4,0],[2,1]]"),Tools.ConstructTArray("[[9,8],[1,5],[10,12],[18,6],[2,4],[14,3]]")));
        Console.WriteLine(obj.MinPathCost(Tools.ConstructTArray("[[5,1,2],[4,0,3]]"),Tools.ConstructTArray("[[12,10,15],[20,23,8],[21,7,1],[8,1,13],[9,10,25],[5,3,2]]")));
    }
    
    public int MinPathCost(int[][] grid, int[][] moveCost)
    {
        int[,] dp = new int[grid.Length+1,grid[0].Length+1];
        for (int i = 1; i <= grid[0].Length; i++)
        {
            dp[1, i] = grid[0][i - 1];
        }
        
        for (int i = 2; i <= grid.Length; i++)
        {
            for (int j = 1; j <= grid[i-1].Length; j++)
            {
                dp[i, j] = int.MaxValue;
                for (int k = 1; k <= grid[i-1].Length; k++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 1, k] + moveCost[grid[i - 2][k - 1]][j - 1]+grid[i-1][j-1]);
                }
            }
        }

        int min = int.MaxValue;
        for (int i = 1; i <= grid[0].Length; i++)
        {
            min = Math.Min(min, dp[grid.Length, i]);
        }

        return min;
    }
}