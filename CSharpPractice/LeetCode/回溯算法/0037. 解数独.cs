namespace CSharpPractice.LeetCode.回溯算法;

/**
编写一个程序，通过填充空格来解决数独问题。
数独的解法需 遵循如下规则：

数字 1-9 在每一行只能出现一次。
数字 1-9 在每一列只能出现一次。
数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。（请参考示例图）
数独部分空格内已填入了数字，空白格用 '.' 表示。
 */
public class LeetCode_0037
{
    public static void Test()
    {
        LeetCode_0037 obj = new LeetCode_0037();
        char[][] board = new char[][]
        {
            new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' },
        };
        obj.SolveSudoku(board);
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(board[i][j]+" ");
            }
            Console.WriteLine();
        }
    }
    
    public void SolveSudoku(char[][] board) {
        DoSolveSudoku(board);
    }

    private bool DoSolveSudoku(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if(board[i][j] != '.') continue;
                for (char k = '1'; k <= '9'; k++)
                {
                    if (IsValid(board, i, j,k))
                    {
                        board[i][j] = k;
                        if(DoSolveSudoku(board)) return true;
                        board[i][j] = '.';
                    }
                }
                return false;
            }
        }

        return true;
    }

    private bool IsValid(char[][] board, int row, int col,char val)
    {
        // 检查行
        for (int i = 0; i < 9; i++)
        {
            if (i != col && board[row][i] == val) return false;
        }
        // 检查列
        for (int i = 0; i < 9; i++)
        {
            if (i != row && board[i][col] == val) return false;
        }
        // 检查九宫格
        int startRow = row / 3 * 3;
        int startCol = col / 3 * 3;
        for (int i = startRow; i < startRow+3; i++)
        {
            for (int j = startCol; j < startCol+3; j++)
            {
                if ((i != row || j !=col) && board[i][j] == val) return false;
            }
        }

        return true;
    }
}