using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
 * 给你两个单词 word1 和 word2， 请返回将 word1 转换成 word2 所使用的最少操作数  。
 */
public class LeetCode_0072
{
    public static void Test()
    {
        LeetCode_0072 obj = new LeetCode_0072();
        Console.WriteLine(obj.MinDistance("zoologicoarchaeologist","zoogeologist"));
        Console.WriteLine(obj.MinDistance("intention","execution"));
        Console.WriteLine(obj.MinDistance("",""));
        Console.WriteLine(obj.MinDistance("","a"));
    }
    
    public int MinDistance(string word1, string word2)
    {
        int[,] dp = new int[word2.Length + 1, word1.Length + 1];
        for (int i = 1; i <= word2.Length; i++)
        {
            dp[i, 0] = i;
        }

        for (int i = 1; i <= word1.Length; i++)
        {
            dp[0, i] = i;
        }

        for (int i = 1; i <= word2.Length; i++)
        {
            for (int j = 1; j <= word1.Length; j++)
            {
                if (word1[j - 1] == word2[i - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1])) + 1;
            }
        }

        return dp[word2.Length, word1.Length];
    }
}