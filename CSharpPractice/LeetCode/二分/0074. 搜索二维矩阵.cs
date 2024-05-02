using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇;

/**
 * 给你一个满足下述两条属性的 m x n 整数矩阵：
    
    每行中的整数从左到右按非严格递增顺序排列。
    每行的第一个整数大于前一行的最后一个整数。
    给你一个整数 target ，如果 target 在矩阵中，返回 true ；否则，返回 false 。
 */
public class LeetCode_0074
{
    public static void Test()
    {
        LeetCode_0074 obj = new LeetCode_0074();
        var tArray = Tools.ConstructTArray("[[1],[3]]");
        Console.WriteLine(obj.SearchMatrix(tArray,3));
        tArray = Tools.ConstructTArray("[[1,3]]");
        Console.WriteLine(obj.SearchMatrix(tArray,3));
        tArray = Tools.ConstructTArray("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]");
        Console.WriteLine(obj.SearchMatrix(tArray,3));
        Console.WriteLine(obj.SearchMatrix(tArray,13));
    }
    
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        // 二分查找行
        int left = 0, right = rows-1;
        int mid = 0;
        while (left<=right)
        {
            mid = (left + right) / 2;
            if (matrix[mid][0] > target)
            {
                right = mid - 1;
            }
            else if (matrix[mid][cols-1] < target)
            {
                left = mid+1;
            }
            else
            {
                left = right = mid;
                break;
            }
        }

        if (left != right) return false;
        int row = left;
        // 二分查找列
        left = 0;
        right = cols-1;
        mid = 0;
        while (left<=right)
        {
            mid = (left + right) / 2;
            if (matrix[row][mid] > target)
            {
                right = mid - 1;
            }
            else if (matrix[row][mid] < target)
            {
                left = mid+1;
            }
            else
            {
                return true;
            }
        }

        return matrix[row][mid] == target;
    }
}