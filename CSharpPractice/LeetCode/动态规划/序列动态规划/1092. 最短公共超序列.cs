using System.Text;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你两个字符串 str1 和 str2，返回同时以 str1 和 str2 作为 子序列 的最短字符串。
 * 如果答案不止一个，则可以返回满足条件的 任意一个 答案。
    如果从字符串 t 中删除一些字符（也可能不删除），可以得到字符串 s ，那么 s 就是 t 的一个子序列。
 */
public class LeetCode_1092
{
    public static void Test()
    {
        LeetCode_1092 obj = new LeetCode_1092();
        Console.WriteLine(obj.ShortestCommonSupersequence("abac","cab"));
        Console.WriteLine(obj.ShortestCommonSupersequence("aaaaaaaa","aaaaaaaa"));
        Console.WriteLine(obj.ShortestCommonSupersequence("eabac","cabe"));
        Console.WriteLine(obj.ShortestCommonSupersequence("a","b"));
        Console.WriteLine(obj.ShortestCommonSupersequence("a","a"));
        Console.WriteLine(obj.ShortestCommonSupersequence("bbbaaaba","bbababbb"));
    }
    
    public string ShortestCommonSupersequence(string str1, string str2) {
        var str1Len = str1.Length;
        var str2Len = str2.Length;
        
        int[,] dp = new int[str1Len + 1, str2Len + 1];
        for (int i = 1; i <= str1Len; i++)
        {
            for (int j = 1; j <= str2Len; j++)
            {
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                if (str1[i - 1] == str2[j - 1])
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - 1] + 1);
            }
        }

        StringBuilder res = new StringBuilder();
        while (str1Len > 0 || str2Len > 0)
        {
            if (str1Len == 0) res.Append(str2[--str2Len]);
            else if (str2Len == 0) res.Append(str1[--str1Len]);
            else
            {
                if (str1[str1Len - 1] == str2[str2Len - 1])
                {
                    res.Append(str1[str1Len - 1]);
                    str1Len--;
                    str2Len--;
                }
                else if (dp[str1Len, str2Len] == dp[str1Len - 1, str2Len])
                    res.Append(str1[--str1Len]);
                else
                    res.Append(str2[--str2Len]);
            }
        }

        var charArray = res.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}