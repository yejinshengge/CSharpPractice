namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个字符串 s ，找出其中最长的回文子序列，并返回该序列的长度。
子序列定义为：不改变剩余字符顺序的情况下，删除某些字符或者不删除任何字符形成的一个序列。
 */
public class LeetCode_0516
{
    public static void Test()
    {
        LeetCode_0516 obj = new LeetCode_0516();
        Console.WriteLine(obj.LongestPalindromeSubseq("bbbab"));
        Console.WriteLine(obj.LongestPalindromeSubseq("cbbd"));
        Console.WriteLine(obj.LongestPalindromeSubseq("a"));
    }
    
    public int LongestPalindromeSubseq(string s)
    {
        int[,] dp = new int[s.Length, s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            dp[i, i] = 1;
        }
        for (int i = s.Length-1; i >= 0; i--)
        {
            for (int j = i+1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[0, s.Length - 1];
    }
}