namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。
'.' 匹配任意单个字符
'*' 匹配零个或多个前面的那一个元素
所谓匹配，是要涵盖 整个 字符串 s的，而不是部分字符串。
 */
public class LeetCode_0010
{
    public static void Test()
    {
        LeetCode_0010 obj = new LeetCode_0010();
        Console.WriteLine(obj.IsMatch("aa","a"));
        Console.WriteLine(obj.IsMatch("aa","a*"));
        Console.WriteLine(obj.IsMatch("ab",".*"));
    }
    
    public bool IsMatch(string s, string p)
    {
        bool[,] dp = new bool[s.Length+1,p.Length+1];
        dp[0, 0] = true;
        
        for (int i = 0; i < s.Length+1; i++)
        {
            for (int j = 1; j < p.Length+1; j++)
            {
                if (p[j - 1] == '*')
                {
                    if (j > 1 && _match(s,p,i,j-1))
                    {
                        dp[i, j] = dp[i - 1, j] | dp[i, j - 2];
                    }
                    else
                    {
                        dp[i, j] = dp[i, j - 2];
                    }
                }
                else
                {
                    if (_match(s,p,i,j))
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = false;
                    }
                }
            }
        }

        return dp[s.Length, p.Length];
    }

    private bool _match(string s,string p,int i,int j)
    {
        if (i == 0)
            return false;
        if (p[j - 1] == '.')
            return true;
        return s[i - 1] == p[j - 1];
    }
}