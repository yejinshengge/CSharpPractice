namespace CSharpPractice.LeetCode.动态规划;

/**
 * 一条包含字母 A-Z 的消息通过以下映射进行了 编码 ：
    
    'A' -&gt; "1"
    'B' -&gt; "2"
    ...
    'Z' -&gt; "26"
    要 解码 已编码的消息，所有数字必须基于上述映射的方法，反向映射回字母（可能有多种方法）。例如，"11106" 可以映射为：
    
    "AAJF" ，将消息分组为 (1 1 10 6)
    "KJF" ，将消息分组为 (11 10 6)
    注意，消息不能分组为  (1 11 06) ，因为 "06" 不能映射为 "F" ，这是由于 "6" 和 "06" 在映射中并不等价。
    
    给你一个只含数字的 非空 字符串 s ，请计算并返回 解码 方法的 总数 。
    
    题目数据保证答案肯定是一个 32 位 的整数。
 */
public class LeetCode_0091
{
    public static void Test()
    {
        LeetCode_0091 obj = new LeetCode_0091();
        Console.WriteLine(obj.NumDecodings("12"));
        Console.WriteLine(obj.NumDecodings("226"));
        Console.WriteLine(obj.NumDecodings("06"));
    }
    
    public int NumDecodings(string s)
    {
        int len = s.Length;
        int[] dp = new int[len+1];
        dp[0] = 1;
        for (int i = 1; i <= len; i++)
        {
            if (s[i - 1] != '0')
            {
                dp[i] += dp[i - 1];
            }

            if (i > 1 && s[i - 2] != '0' 
                      && (s[i - 2] - '0') * 10 + (s[i - 1] - '0') <= 26)
            {
                dp[i] += dp[i - 2];
            }
        }

        return dp[len];
    }
}