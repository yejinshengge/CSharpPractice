using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个 m * n 的矩阵，矩阵中的元素不是 0 就是 1，请你统计并返回其中完全由 1 组成的 正方形 子矩阵的个数。
 */
public class LeetCode_1277
{
    public static void Test()
    {
        LeetCode_1277 obj = new LeetCode_1277();
        Console.WriteLine(obj.CountSquares(Tools.ConstructTArray("[[0,1,1,1],[1,1,1,1],[0,1,1,1]]")));
    }
    
    public int CountSquares(int[][] matrix)
    {
        int[,] dp = new int[matrix.Length, matrix[0].Length];
        int total = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = matrix[i][j];
                else if (matrix[i][j] == 0)
                    dp[i, j] = 0;
                else
                    dp[i, j] = Math.Min(dp[i - 1,j], Math.Min(dp[i,j - 1], dp[i - 1,j - 1])) + 1;
                total += dp[i, j];
            }
        }

        return total;
    }
}