namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给定两个字符串 text1 和 text2，返回这两个字符串的最长 公共子序列 的长度。如果不存在 公共子序列 ，返回 0 。

    一个字符串的 子序列 是指这样一个新的字符串：它是由原字符串在不改变字符的相对顺序的情况下删除某些字符（也可以不删除任何字符）后组成的新字符串。

    例如，"ace" 是 "abcde" 的子序列，但 "aec" 不是 "abcde" 的子序列。
    两个字符串的 公共子序列 是这两个字符串所共同拥有的子序列。
 */
public class LeetCode_1143
{
    public static void Test()
    {
        LeetCode_1143 obj = new LeetCode_1143();
        Console.WriteLine(obj.LongestCommonSubsequence("abcde","ace"));
        Console.WriteLine(obj.LongestCommonSubsequence("abc","abc"));
        Console.WriteLine(obj.LongestCommonSubsequence("abc","def"));
    }
    
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int[,] dp = new int[text1.Length + 1, text2.Length + 1];

        for (int i = 1; i <= text1.Length; i++)
        {
            for (int j = 1; j <= text2.Length; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[text1.Length, text2.Length];
    }
}