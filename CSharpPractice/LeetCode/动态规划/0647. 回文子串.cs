namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个字符串 s ，请你统计并返回这个字符串中 回文子串 的数目。

回文字符串 是正着读和倒过来读一样的字符串。

子字符串 是字符串中的由连续字符组成的一个序列。

具有不同开始位置或结束位置的子串，即使是由相同的字符组成，也会被视作不同的子串。
 */
public class LeetCode_0647
{
    public static void Test()
    {
        LeetCode_0647 obj = new LeetCode_0647();
        Console.WriteLine(obj.CountSubstrings("abc"));
    }
    
    public int CountSubstrings(string s)
    {
        bool[,] dp = new bool[s.Length, s.Length];
        int res = 0;
        for (int i = s.Length-1; i >=0; i--)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (s[i] == s[j] && (j-i <= 1||dp[i + 1, j - 1]))
                {
                    dp[i, j] = true;
                    res++;
                }
            }
        }

        return res;
    }
}