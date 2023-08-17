using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
按照国际象棋的规则，皇后可以攻击与之处在同一行或同一列或同一斜线上的棋子。
n 皇后问题 研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
给你一个整数 n ，返回所有不同的 n 皇后问题 的解决方案。
每一种解法包含一个不同的 n 皇后问题 的棋子放置方案，该方案中 'Q' 和 '.' 分别代表了皇后和空位。
 */
public class LeetCode_0051
{
    public static void Test()
    {
        LeetCode_0051 obj = new LeetCode_0051();
        var list = obj.SolveNQueens(4);
        Tools.PrintEnumerator(list);
    }

    private IList<IList<string>> _res = new List<IList<string>>();
    private IList<char[]> _map;
    public IList<IList<string>> SolveNQueens(int n)
    {
        _res.Clear();
        _map = new List<char[]>(n);
        for (int i = 0; i < n; i++)
        {
            _map.Add(new char[n]);
            for (int j = 0; j < n; j++)
            {
                _map[i][j] = '.';
            }
        }
        DoSolveNQueens(n,0);
        return _res;
    }

    private void DoSolveNQueens(int n,int row)
    {
        if (row >= n)
        {
            List<string> path = new List<string>(n);
            for (int i = 0; i < n; i++)
            {
                path.Add(new string(_map[i]));
            }
            _res.Add(path);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (IsValid(row, i, n))
            {
                _map[row][i] = 'Q';
                DoSolveNQueens(n,row+1);
                _map[row][i] = '.';
            }
        }
    }

    private bool IsValid(int row, int col,int n)
    {
        // 同一列
        for (int i = row; i >=0; i--)
        {
            if (_map[i][col] == 'Q') return false;
        }
        // 左上
        for (int i = row,j=col; i >= 0&&j>=0; i--,j--)
        {
            if (_map[i][j] == 'Q') return false;
        }
        // 右上
        for (int i = row,j=col; i >=0&&j<n; i--,j++)
        {
            if (_map[i][j] == 'Q') return false;
        }

        return true;
    }
}