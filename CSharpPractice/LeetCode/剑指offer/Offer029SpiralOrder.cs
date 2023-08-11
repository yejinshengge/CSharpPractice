namespace CSharpPractice.LeetCode;

public class Offer029SpiralOrder
{
    public static void Offer029SpiralOrderMain()
    {
        Offer029SpiralOrder obj = new();
        int[][] matrix =
        {
            
            
        };
        var spiralOrder = obj.SpiralOrder(matrix);
        Console.WriteLine(spiralOrder);
    }
    public int[] SpiralOrder(int[][] matrix)
    {
        if (matrix == null)
            return null;
        if (matrix.Length == 0 || matrix[0].Length == 0)
            return new int[]{};
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int start = 0;
        int index = 0;
        int[] res = new int[rows * cols];
        while (rows > start * 2 && cols > start * 2)
        {
            PrintCircle(matrix, rows, cols, start, ref index, res);
            start++;
        }
        return res;
    }

    private void PrintCircle(int[][] matrix, int rows, int cols,int start,ref int index, int[] res)
    {
        int endRow = rows - start - 1;
        int endCol = cols - start - 1;
        for (int i = start; i <= endCol; i++)
        {
            res[index++] = matrix[start][i];
        }

        if (endRow > start)
        {
            for (int i = start+1; i <= endRow; i++)
            {
                res[index++] = matrix[i][endCol];
            }
        }

        if (endRow > start && endCol > start)
        {
            for (int i = endCol-1; i >= start; i--)
            {
                res[index++] = matrix[endRow][i];
            }
        }

        if (endRow > start+1 && endCol > start)
        {
            for (int i = endRow-1; i >= start+1; i--)
            {
                res[index++] = matrix[i][start];
            }
        }
    }
}