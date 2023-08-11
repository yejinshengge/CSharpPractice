using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
给定一个 n×n 的二维矩阵matrix 表示一个图像。请你将图像顺时针旋转 90 度。
你必须在 原地 旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要 使用另一个矩阵来旋转图像。
 */
public class LeetCode_011
{
    public static void LeetCode_011Main()
    {
        LeetCode_011 obj = new LeetCode_011();

        var arr = new[]
        {
            new[] {1, 2, 3},
            new[] {4, 5, 6},
            new[] {7, 8, 9},
        };
        
        obj.Rotate2(arr);
        Util.Tools.PrintArr(arr);
    }
    
    // 先上下交换,再按对角线交换
    public void Rotate(int[][] matrix)
    {
        int length = matrix.Length;
        // 先上下交换
        for (int i = 0; i < length/2; i++)
        {
            (matrix[i], matrix[length - i - 1]) = (matrix[length - i - 1], matrix[i]);
        }

        for (int i = 0; i < length; i++)
        {
            for (int j = i+1; j < length; j++)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }
    }

    // 一圈一圈旋转
    public void Rotate2(int[][] matrix)
    {
        int length = matrix.Length;
        for (int i = 0; i < length/2; i++)
        {
            for (int j = i; j < length-i-1; j++)
            {
                int n = length - 1 - i;
                int m = length - 1 - j;
                int temp = matrix[i][j];

                matrix[i][j] = matrix[m][i];
                matrix[m][i] = matrix[n][m];
                matrix[n][m] = matrix[j][n];
                matrix[j][n] = temp;

            }
        }
    }
    
    
}