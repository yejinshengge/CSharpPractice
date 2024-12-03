using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR112
{
    public static void Test()
    {
        LeetCode_LCR112 obj = new LeetCode_LCR112();
        Console.WriteLine(obj.LongestIncreasingPath(Tools.ConstructTArray("[[9,9,4],[6,6,8],[2,1,1]]")));
        Console.WriteLine(obj.LongestIncreasingPath(Tools.ConstructTArray("[[3,4,5],[3,2,6],[2,2,1]]")));
        Console.WriteLine(obj.LongestIncreasingPath(Tools.ConstructTArray("[[1]]")));
    }
    
    public int LongestIncreasingPath(int[][] matrix)
    {
        int[,] lenMatrix = new int[matrix.Length,matrix[0].Length];
        maxLen = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                _dfs(matrix, lenMatrix, i, j);
            }
        }
        return maxLen;
    }

    private int maxLen = 0;
    private int _dfs(int[][] matrix, int[,] lenMatrix, int x, int y)
    {
        if (x < 0 || x >= matrix.Length || y < 0 || y >= matrix[0].Length)
            return 0;
        if (lenMatrix[x, y] > 0) return lenMatrix[x, y];
        int len = 1;
        if (x - 1 >= 0 && matrix[x][y] < matrix[x-1][y] )
            len = Math.Max(len, _dfs(matrix, lenMatrix, x - 1, y)+1);
        if (x + 1 < matrix.Length && matrix[x][y] < matrix[x+1][y])
            len = Math.Max(len, _dfs(matrix, lenMatrix, x + 1, y)+1);
        if (y - 1 >= 0 && matrix[x][y] < matrix[x][y-1])
            len = Math.Max(len, _dfs(matrix, lenMatrix, x, y - 1)+1);
        if (y + 1 < matrix[0].Length && matrix[x][y] < matrix[x][y + 1])
            len = Math.Max(len, _dfs(matrix, lenMatrix, x, y + 1)+1);
        lenMatrix[x, y] = len;
        maxLen = Math.Max(maxLen, len);
        return len;
    }
}