using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇;

/**
 * 给定一个 m x n 的矩阵，如果一个元素为 0 ，则将其所在行和列的所有元素都设为 0 。请使用 原地 算法。
 */
public class LeetCode_0073
{
    public static void Test()
    {
        LeetCode_0073 obj = new LeetCode_0073();
        var tArray = Tools.ConstructTArray("[[0,1,2,0],[3,4,5,2],[1,3,1,5]]");
        obj.SetZeroes(tArray);
        Tools.PrintArr(tArray);
    }
    
    public void SetZeroes(int[][] matrix)
    {
        int rowNum = matrix.Length;
        int colNum = matrix[0].Length;
        bool row0Flag = false;
        bool col0Flag = false;
        
        // 第一行和第一列是否变0
        for (int i = 0; i < rowNum; i++)
        {
            if (matrix[i][0] == 0)
                col0Flag = true;
        }
        for (int i = 0; i < colNum; i++)
        {
            if (matrix[0][i] == 0)
                row0Flag = true;
        }
        // 用第一行和第一列存储当前行列是否是0
        for (int i = 1; i < rowNum; i++)
        {
            for (int j = 1; j < colNum; j++)
            {
                if (matrix[i][j] == 0)
                    matrix[i][0] = matrix[0][j] = 0;
            }
        }
        // 设置所有为0的项
        for (int i = 1; i < rowNum; i++)
        {
            for (int j = 1; j < colNum; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            }
        }
        // 最后设置第一行和第一列
        if (row0Flag)
        {
            for (int i = 0; i < colNum; i++)
            {
                matrix[0][i] = 0;
            }
        }
        
        if (col0Flag)
        {
            for (int i = 0; i < rowNum; i++)
            {
                matrix[i][0] = 0;
            }
        }
    }
}