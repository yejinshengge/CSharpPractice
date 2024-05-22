using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_08
{
    public static void Test()
    {
        LeetCode_01_08 obj = new LeetCode_01_08();
        // var tArray = Tools.ConstructTArray("[[1,1,1],[1,0,1],[1,1,1]]");
        var tArray = Tools.ConstructTArray("[[0,1,2,0],[3,4,5,2],[1,3,1,5]]");    
        obj.SetZeroes(tArray);
        Tools.PrintArr(tArray);
    }
    // 两个变量
    public void SetZeroes1(int[][] matrix)
    {
        bool rowHasZero = false, colHasZero = false;
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == 0) 
                colHasZero = true;
        }

        for (int i = 0; i < matrix[0].Length; i++)
        {
            if (matrix[0][i] == 0) 
                rowHasZero = true;
        }
        
        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[0][j] = 0;
                    matrix[i][0] = 0;
                }
            }
        }
        
        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if(matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            }
        }
        
        for (int i = 0; i < matrix.Length; i++)
        {
            if (colHasZero)
                matrix[i][0] = 0;
        }

        for (int i = 0; i < matrix[0].Length; i++)
        {
            if (rowHasZero)
                matrix[0][i] = 0;
        }
    }
    // 一个变量
    public void SetZeroes(int[][] matrix)
    {
        bool colHasZero = false;
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == 0)
                colHasZero = true;
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == 0)
                    matrix[i][0] = matrix[0][j] = 0;
            }
        }
        
        for (int i = matrix.Length-1; i >= 0; i--)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            }

            if (colHasZero)
                matrix[i][0] = 0;
        }
    }
}