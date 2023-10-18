namespace CSharpPractice.LeetCode.动态规划;

// 给你一个只包含 '(' 和 ')' 的字符串，找出最长有效（格式正确且连续）括号子串的长度。
public class LeetCode_0032
{
    public static void Test()
    {
        LeetCode_0032 obj = new LeetCode_0032();
        
    }
    
    public int LongestValidParentheses(string s)
    {
        if (s.Length <=1) return 0;
        int[] dp = new int[s.Length];
        dp[0] = 0;
        int maxLen = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == ')')
            {
                if (s[i - 1] == '(')
                {
                    dp[i] = (i-2>=0?dp[i - 2]:0) + 2;
                }
                else
                {
                    var index = i - dp[i - 1];
                    if (index > 0 && s[index-1] == '(')
                    {
                        dp[i] = (index-2>=0?dp[index-2]:0) + 2 + dp[i - 1];
                    }
                }

                maxLen = Math.Max(maxLen, dp[i]);
            }
        }

        return maxLen;
    }
}