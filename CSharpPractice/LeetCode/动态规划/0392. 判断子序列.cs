using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
给定字符串 s 和 t ，判断 s 是否为 t 的子序列。
字符串的一个子序列是原始字符串删除一些（也可以不删除）字符而不改变剩余字符相对位置形成的新字符串。
（例如，"ace"是"abcde"的一个子序列，而"aec"不是）。
 */
public class LeetCode_0392
{
    public static void Test()
    {
        LeetCode_0392 obj = new LeetCode_0392();
        Console.WriteLine(obj.IsSubsequence("abc","ahbgdc"));
        Console.WriteLine(obj.IsSubsequence("axc","ahbgdc"));
        Console.WriteLine(obj.IsSubsequence("",""));
        Console.WriteLine(obj.IsSubsequence("","ahbgdc"));
        Console.WriteLine(obj.IsSubsequence("b","abc"));
    }
    
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0) return true;
        bool[,] dp = new bool[s.Length+1, t.Length+1];
        for (int i = 0; i < t.Length; i++)
        {
            dp[0, i] = true;
        }
        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= t.Length; j++)
            {
                if (s[i - 1] == t[j - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                else
                    dp[i, j] = dp[i, j - 1];
            }
        }

        return dp[s.Length, t.Length];
    }
}