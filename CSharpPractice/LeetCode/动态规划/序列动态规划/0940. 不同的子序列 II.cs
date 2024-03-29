namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给定一个字符串 s，计算 s 的 不同非空子序列 的个数。因为结果可能很大，所以返回答案需要对 10^9 + 7 取余 。

    字符串的 子序列 是经由原字符串删除一些（也可能不删除）字符但不改变剩余字符相对位置的一个新字符串。

    例如，"ace" 是 "abcde" 的一个子序列，但 "aec" 不是。
 */
public class LeetCode_0940
{
    public static void Test()
    {
        LeetCode_0940 obj = new LeetCode_0940();
        Console.WriteLine(obj.DistinctSubseqII2("abc"));
        Console.WriteLine(obj.DistinctSubseqII2("aba"));
        Console.WriteLine(obj.DistinctSubseqII2("aaa"));
    }
    public int DistinctSubseqII(string s)
    {
        const int MOD = 1000000007;
        // 前i个字符，以j结尾的子序列个数
        int[,] dp = new int[s.Length+1,26];

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                // 不以i结尾
                if (s[i - 1] - 'a' != j)
                {
                    dp[i, j] = dp[i - 1, j];
                }
                // 以i结尾
                else
                {
                    dp[i, j] = 1;
                    for (int k = 0; k < 26; k++)
                    {
                        dp[i, j] =(dp[i, j] + dp[i - 1, k])%MOD;
                    }
                }
            }
        }

        int res = 0;
        for (int i = 0; i < 26; i++)
        {
            res = (res + dp[s.Length, i]) % MOD;
        }

        return res;
    }
    
    public int DistinctSubseqII2(string s)
    {
        const int MOD = 1000000007;
        int[] dp = new int[26];
        int total = 0;
        for (int i = 1; i <= s.Length; i++)
        {
            // 之前以该字符结尾的子序列个数
            var index = s[i-1] - 'a';
            int pre = dp[index];
            // 现在以该字符结尾的子序列个数
            dp[index] = (total + 1) % MOD;
            // 将数量添加到总数
            total = (total + dp[index]) % MOD;
            // 减去之前以该字符结尾的子序列个数，因为现在已经包含了之前
            total = (total - pre + MOD) % MOD;
        }

        return total;
    }
}