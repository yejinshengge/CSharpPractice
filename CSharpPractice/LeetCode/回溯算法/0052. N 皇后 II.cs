namespace CSharpPractice.LeetCode.回溯算法;

/**
n 皇后问题 研究的是如何将 n 个皇后放置在 n × n 的棋盘上，并且使皇后彼此之间不能相互攻击。

给你一个整数 n ，返回 n 皇后问题 不同的解决方案的数量。
 */
public class LeetCode_0052
{
    public static void Test()
    {
        LeetCode_0052 obj = new LeetCode_0052();
        Console.WriteLine(obj.TotalNQueens(4));
        Console.WriteLine(obj.TotalNQueens(1));
        Console.WriteLine(obj.TotalNQueens(9));
    }
    
    public int TotalNQueens(int n)
    {
        bool[,] map = new bool[n, n];
        return _doCalNQueens(n, 0, map);
    }

    private int _doCalNQueens(int n, int row,bool[,] map)
    {
        if (n <= row)
            return 1;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (_isValid(row, i, n, map))
            {
                map[row, i] = true;
                count += _doCalNQueens(n, row + 1, map);
                map[row, i] = false;
            }
        }
        return count;
    }
    
    private bool _isValid(int row, int col,int n,bool[,] map)
    {
        // 同一列
        for (int i = row; i >=0; i--)
        {
            if (map[i,col]) return false;
        }
        // 左上
        for (int i = row,j=col; i >= 0&&j>=0; i--,j--)
        {
            if (map[i,j]) return false;
        }
        // 右上
        for (int i = row,j=col; i >=0&&j<n; i--,j++)
        {
            if (map[i,j]) return false;
        }

        return true;
    }
}