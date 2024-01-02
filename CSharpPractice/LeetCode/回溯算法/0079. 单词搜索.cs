using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
 * 给定一个 m x n 二维字符网格 board 和一个字符串单词 word 。如果 word 存在于网格中，返回 true ；否则，返回 false 。
    
    单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
 */
public class LeetCode_0079
{
    public static void Test()
    {
        LeetCode_0079 obj = new LeetCode_0079();
        var charArray = Tools.ConstructCharArray("[[C,A,A],[A,A,A],[B,C,D]]");
        Console.WriteLine(obj.Exist(charArray,"AAB"));
        Console.WriteLine(obj.Exist(charArray,"SEE"));
        Console.WriteLine(obj.Exist(charArray,"ABCB"));
    }
    
    public bool Exist(char[][] board, string word)
    {
        bool[,] map = new bool[board.Length,board[0].Length];

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                var res = _doExist(board, map, word, i, j, 0);
                if (res) return true;
            }
        }

        return false;
    }

    private bool _doExist(char[][] board,bool[,] map, string word, int row, int col, int index)
    {
        if (index >= word.Length) return true;
        if(row >= board.Length || row < 0) return false;
        if (col >= board[row].Length || col < 0) return false;
        if (map[row, col]) return false;
        if (board[row][col] != word[index]) return false;
        map[row, col] = true;
        var res = _doExist(board, map, word, row + 1, col, index + 1) 
               || _doExist(board, map, word, row, col+1, index + 1)
               || _doExist(board, map, word, row-1, col, index + 1)
               || _doExist(board, map, word, row, col-1, index + 1);
        map[row, col] = false;
        return res;
    }
}