using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个 n x n 的 方形 整数数组 matrix ，请你找出并返回通过 matrix 的下降路径 的 最小和 。
    
    下降路径 可以从第一行中的任何元素开始，并从每一行中选择一个元素。
    在下一行选择的元素和当前行所选元素最多相隔一列（即位于正下方或者沿对角线向左或者向右的第一个元素）。
    具体来说，位置 (row, col) 的下一个元素应当是 (row + 1, col - 1)、(row + 1, col) 或者 (row + 1, col + 1) 。
    
 */
public class LeetCode_0931
{
    public static void Test()
    {
        LeetCode_0931 obj = new LeetCode_0931();
        Console.WriteLine(obj.MinFallingPathSum(Tools.ConstructTArray("[[2,1,3],[6,5,4],[7,8,9]]")));
        Console.WriteLine(obj.MinFallingPathSum(Tools.ConstructTArray("[[-19,57],[-40,-5]]")));
        Console.WriteLine(obj.MinFallingPathSum(Tools.ConstructTArray("[[-19]]")));
    }
    
    public int MinFallingPathSum(int[][] matrix)
    {
        if (matrix.Length == 1) return matrix[0][0];
        int minPath = int.MaxValue;
        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (j == 0)
                    matrix[i][j] += Math.Min(matrix[i - 1][j], matrix[i - 1][j + 1]);
                else if(j==matrix[i].Length-1)
                    matrix[i][j] += Math.Min(matrix[i - 1][j], matrix[i - 1][j - 1]);
                else
                    matrix[i][j] += Math.Min(matrix[i - 1][j], Math.Min(matrix[i - 1][j - 1],matrix[i - 1][j + 1]));
                if (i == matrix[i].Length - 1)
                    minPath = Math.Min(matrix[i][j], minPath);
            }
        }

        return minPath;
    }
}