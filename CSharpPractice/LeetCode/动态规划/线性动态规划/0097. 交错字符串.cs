namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

// 给定三个字符串 s1、s2、s3，请你帮忙验证 s3 是否是由 s1 和 s2 交错 组成的。
public class LeetCode_0097
{
    public static void Test()
    {
        LeetCode_0097 obj = new LeetCode_0097();
        Console.WriteLine(obj.IsInterleave2("aabcc","dbbca","aadbbcbcac"));
        Console.WriteLine(obj.IsInterleave2("aabcc","dbbca","aadbbbaccc"));
        Console.WriteLine(obj.IsInterleave2("aabcc","dbbca","aadbbcbcac"));
        Console.WriteLine(obj.IsInterleave2("","",""));
        Console.WriteLine(obj.IsInterleave2("a","","c"));
    }
    
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length) return false;
        if (s1 + s2 == s3) return true;
        bool[,] dp = new bool[s1.Length+1,s2.Length+1];
        dp[0, 0] = true;

        for (int i = 0; i <= s1.Length; i++)
        {
            for (int j = 0; j <= s2.Length; j++)
            {
                if (i>0&&s1[i-1] == s3[i + j-1])
                    dp[i, j] |= dp[i - 1, j];
                if(j>0&&s2[j-1] == s3[i+j-1])
                    dp[i, j] |= dp[i, j-1];
            }
        }

        return dp[s1.Length, s2.Length];
    }

    public bool IsInterleave2(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length) return false;
        if (s1 + s2 == s3) return true;
        bool[] dp = new bool[s2.Length+1];
        dp[0] = true;

        for (int i = 0; i <= s1.Length; i++)
        {
            for (int j = 0; j <= s2.Length; j++)
            {
                if(i>0)
                    dp[j] = dp[j] && s1[i-1] == s3[i + j-1];
                if(j>0)
                    dp[j] = dp[j] || dp[j-1] && s2[j-1] == s3[i+j-1];
            }
        }

        return dp[s2.Length];
    }
}