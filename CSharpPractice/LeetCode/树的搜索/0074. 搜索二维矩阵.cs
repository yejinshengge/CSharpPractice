using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.树的搜索;

public class LeetCode_0074
{
    public static void Test()
    {
        LeetCode_0074 obj = new LeetCode_0074();
        // Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]"),3));
        // Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]"),13));
        // Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1]]"),13));
        Console.WriteLine(obj.SearchMatrix(Tools.ConstructTArray("[[1,3]]"),3));
    }
    
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int x = 0, y = matrix[0].Length - 1;
        while (_check(m,n,x,y) && matrix[x][y] != target)
        {
            // 往左子树移动
            if (matrix[x][y] > target)
            {
                y--;
            }
            // 往右子树移动
            else
            {
                x++;
            }
        }

        return _check(m, n, x, y) && matrix[x][y] == target;
    }

    private bool _check(int m, int n, int x, int y)
    {
        return x >= 0 && x < m && y >= 0 && y < n;
    }
}