using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

// 数字 n 代表生成括号的对数，请你设计一个函数，用于能够生成所有可能的并且 有效的 括号组合。
public class LeetCode_0022
{
    public static void Test()
    {
        LeetCode_0022 obj = new LeetCode_0022();
        Tools.PrintEnumerator(obj.GenerateParenthesis(3));
    }

    // 回溯解法
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> res = new List<string>();
        _doGenerateParenthesis(n, "", 0, 0, res);
        return res;
    }
    
    private void _doGenerateParenthesis(int n,string s,int left,int right,List<string> res)
    {
        if(left>n||right>n||left<right) return;
        if (s.Length == 2 * n)
        {
            res.Add(s);
            return;
        }
        _doGenerateParenthesis(n , s + "(", left+1, right,res);
        _doGenerateParenthesis(n , s + ")", left, right + 1,res);
    }
    
    // 动态规划解法
    public IList<string> GenerateParenthesis1(int n)
    {
        List<string>[] dp = new List<string>[n+1];
        dp[0] = new List<string>() { "" };

        for (int i = 1; i <= n; i++)
        {
            List<string> cur = new List<string>();
            for (int j = 0; j < i; j++)
            {
                var list1 = dp[j];
                var list2 = dp[i - 1 - j];
                
                for (int k = 0; k < list1.Count; k++)
                {
                    for (int l = 0; l < list2.Count; l++)
                    {
                        cur.Add("("+list1[k]+")"+list2[l]);
                    }
                }
            }
            dp[i] = cur;
        }

        return dp[n];
    }

}