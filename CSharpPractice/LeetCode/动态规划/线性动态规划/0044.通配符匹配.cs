namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个输入字符串 (s) 和一个字符模式 (p) ，请你实现一个支持 '?' 和 '*' 匹配规则的通配符匹配：
    '?' 可以匹配任何单个字符。
    '*' 可以匹配任意字符序列（包括空字符序列）。
    判定匹配成功的充要条件是：字符模式必须能够 完全匹配 输入字符串（而不是部分匹配）。
 */
public class LeetCode_0044
{
    public static void Test()
    {
        LeetCode_0044 obj = new LeetCode_0044();
        Console.WriteLine(obj.IsMatch("aa","a"));
        Console.WriteLine(obj.IsMatch("aa","*"));
        Console.WriteLine(obj.IsMatch("cb","?a"));
        Console.WriteLine(obj.IsMatch("","****"));
    }
    
    public bool IsMatch(string s, string p)
    {
        s = " " + s;
        p = " " + p;
        bool[,] dp = new bool[s.Length+1,p.Length+1];
        dp[0, 0] = true;
        for (int i = 1; i < s.Length+1; i++)
        {
            for (int j = 1; j < p.Length+1; j++)
            {
                if(p[j-1] == '?')
                    dp[i, j] = dp[i - 1, j - 1];
                else if(p[j-1] == '*')
                    dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                else
                    dp[i, j] = dp[i - 1, j - 1] && p[j-1] == s[i-1];
            }
        }

        return dp[s.Length, p.Length];
    }
}