using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_12
{
    public static void Test()
    {
        LeetCode_08_12 obj = new LeetCode_08_12();
        Tools.PrintEnumerator(obj.SolveNQueens(4));
    }
    
    private IList<IList<string>> _res = new List<IList<string>>();
    public IList<IList<string>> SolveNQueens(int n) {
        _res.Clear();
        char[][] queen = new char[n][];
        for (int i = 0; i < queen.Length; i++)
        {
            queen[i] = new char[n];
            Array.Fill(queen[i],'.');
        }
        _doSolveNQueens(0,queen);
        return _res;
    }

    
    private void _doSolveNQueens(int curRow,char[][] queen)
    {
        if (curRow >= queen.Length)
        {
            List<string> path = new List<string>();
            for (int i = 0; i < queen.Length; i++)
            {
                path.Add(new string(queen[i]));
            }
            _res.Add(path);
            return;
        }

        for (int i = 0; i < queen[0].Length; i++)
        {
            if(!_check(queen,curRow,i))
                continue;
            queen[curRow][i] = 'Q';
            _doSolveNQueens(curRow + 1, queen);
            queen[curRow][i] = '.';
        }
    }

    private bool _check(char[][] queen, int x, int y)
    {
        // 检查同一列
        for (int i = 0; i < queen.Length; i++)
        {
            if (queen[i][y]=='Q') return false;
        }
        
        // 检查对角线
        for (int i = x, j = y; i < queen.Length && j < queen[0].Length ; i++,j++)
        {
            if (queen[i][j]=='Q') return false;
        }
        for (int i = x, j = y; i >=0 && j < queen[0].Length ; i--,j++)
        {
            if (queen[i][j]=='Q') return false;
        }
        for (int i = x, j = y; i < queen.Length && j >= 0 ; i++,j--)
        {
            if (queen[i][j]=='Q') return false;
        }
        for (int i = x, j = y; i >=0 && j >= 0 ; i--,j--)
        {
            if (queen[i][j]=='Q') return false;
        }

        return true;
    }
}