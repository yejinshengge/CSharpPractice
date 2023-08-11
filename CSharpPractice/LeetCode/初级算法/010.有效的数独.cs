namespace CSharpPractice.LeetCode.初级算法;

/**
请你判断一个9 x 9 的数独是否有效。只需要 根据以下规则 ，验证已经填入的数字是否有效即可。

数字1-9在每一行只能出现一次。
数字1-9在每一列只能出现一次。
数字1-9在每一个以粗实线分隔的3x3宫内只能出现一次。

 */
public class LeetCode_010
{
    public static void LeetCode_010Main()
    {
        LeetCode_010 obj = new LeetCode_010();
        Console.WriteLine(obj.IsValidSudoku3(new []
        {
            new char[] {'8','3','.','.','7','.','.','.','.'},
            new char[] {'6','.','.','1','9','5','.','.','.'},
            new char[] {'.','9','8','.','.','.','.','6','.'},
            new char[] {'8','.','.','.','6','.','.','.','3'},
            new char[] {'4','.','.','8','.','3','.','.','1'},
            new char[] {'7','.','.','.','2','.','.','.','6'},
            new char[] {'.','6','.','.','.','.','2','8','.'},
            new char[] {'.','.','.','4','1','9','.','.','5'},
            new char[] {'.','.','.','.','8','.','.','7','9'},
        }));
    }
    
    // 思路一:暴力枚举
    public bool IsValidSudoku(char[][] board)
    {
        HashSet<char> set = new HashSet<char>();
        
        // 遍历行
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] != '.')
                {
                    if(set.Contains(board[i][j]))
                        return false;
                    set.Add(board[i][j]);
                }
            }
            set.Clear();
        }
        
        // 遍历列
        for (int i = 0; i < board[0].Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                if (board[j][i] != '.')
                {
                    if(set.Contains(board[j][i]))
                        return false;
                    set.Add(board[j][i]);
                }
            }
            set.Clear();
        }
        // 遍历九宫格
        for (int i = 0; i < board.Length; i+=3)
        {
            for (int j = 0; j < board[0].Length; j+=3)
            {
                for (int k = i; k < i+3; k++)
                {
                    for (int l = j; l < j+3; l++)
                    {
                        if (board[k][l] != '.')
                        {
                            if(set.Contains(board[k][l]))
                                return false;
                            set.Add(board[k][l]);
                        }
                    }
                }
                set.Clear();
            }
        }
        return true;
    }

    // 思路二:暴力枚举优化
    public bool IsValidSudoku2(char[][] board)
    {
        int length = board.Length;
        bool[,] line = new bool[length,length];
        bool[,] row = new bool[length,length];
        bool[,] cell = new bool[length,length];

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if(board[i][j] == '.')
                    continue;
                // 数字对应下标
                int num = board[i][j] - '0' - 1;
                // 格子
                int cellIndex = i / 3 * 3 + j / 3;

                if (line[i, num] || row[j, num] || cell[cellIndex, num])
                    return false;
                line[i, num] = row[j, num] = cell[cellIndex, num] = true;
            }
        }
        return true;

    }
    
    // 思路三:利用位运算优化
    public bool IsValidSudoku3(char[][] board)
    {
        int length = board.Length;
        int[] line = new int[length];
        int[] row = new int[length];
        int[] cell = new int[length];

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if(board[i][j] == '.')
                    continue;
                // 数字对应位
                int num = 1<<(board[i][j] - '0');
                // 格子
                int cellIndex = i / 3 * 3 + j / 3;

                if ((line[i] & num) > 0 || (row[j] & num) > 0 || (cell[cellIndex] & num) > 0)
                    return false;
                line[i] |= num;
                row[j] |= num;
                cell[cellIndex] |= num;
            }
        }
        return true;

    }
}