using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_10_09
{
    public static void Test()
    {
        LeetCode_10_09 obj = new LeetCode_10_09();
        Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]"),16));
        Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]"),30));
        Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]"),6));
        Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]"),20));
        Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1,2,3,4,5],[6,7,8,9,10],[11,12,13,14,15],[16,17,18,19,20],[21,22,23,24,25]]"),15));
    }
    
    // 错误解法
    public bool SearchMatrix1(int[][] matrix, int target)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0) return false;
        int row = matrix.Length, col = matrix[0].Length;
        int rowLeft = 0, rowRight = row - 1;
        int colLeft = 0, colRight = col - 1;
        while (colLeft < colRight && rowLeft < rowRight)
        {
            int colMid = (colLeft + colRight) / 2;
            int rowMid = (rowLeft + rowRight) / 2;

            if (matrix[rowMid][colMid] == target)
                return true;
            if (matrix[rowMid][colMid] > target)
            {
                rowRight = rowMid;
                colRight = colMid;
            }
            else
            {
                rowLeft = rowMid+1;
                colLeft = colMid+1;
            }
        }

        int left = 0, right = rowRight;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (matrix[mid][colRight] == target)
                return true;
            if (matrix[mid][colRight] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        left = 0; right = colRight;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (matrix[rowRight][mid] == target)
                return true;
            if (matrix[rowRight][mid] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }
        return false;
    }

    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0) return false;
        int row = 0, col = matrix[0].Length-1;
        while (row < matrix.Length && col >= 0)
        {
            if (matrix[row][col] == target)
                return true;
            if (matrix[row][col] < target)
                row++;
            else
                col--;
        }
        return false;
    }
}