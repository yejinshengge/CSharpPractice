using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
给定两个单词 word1 和 word2 ，返回使得 word1 和  word2 相同所需的最小步数。
每步 可以删除任意一个字符串中的一个字符。
 */
public class LeetCode_0583
{
    public static void Test()
    {
        LeetCode_0583 obj = new LeetCode_0583();
        Console.WriteLine(obj.MinDistance("sea","eat"));
        Console.WriteLine(obj.MinDistance("leetcode","etco"));
        Console.WriteLine(obj.MinDistance("a","b"));
        Console.WriteLine(obj.MinDistance("a","a"));
    }
    
    public int MinDistance(string word1, string word2)
    {
        int[,] dp = new int[word1.Length+1,word2.Length+1];
        for (int i = 1; i <= word1.Length; i++)
        {
            dp[i, 0] = i;
        }

        for (int i = 1; i <= word2.Length; i++)
        {
            dp[0, i] = i;
        }

        for (int i = 1; i <= word1.Length; i++)
        {
            for (int j = 1; j <= word2.Length; j++)
            {
                if (word1[i-1] == word2[j-1])
                    dp[i, j] = dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Min(dp[i - 1, j]+1, dp[i, j - 1]+1);
            }
        }

        return dp[word1.Length, word2.Length];
    }
}