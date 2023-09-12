using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
 * 给你两个字符串 s 和 t ，统计并返回在 s 的 子序列 中 t 出现的个数，结果需要对 10^9 + 7 取模。
 */
public class LeetCode_0115
{
    public static void Test()
    {
        LeetCode_0115 obj = new LeetCode_0115();
        Console.WriteLine(obj.NumDistinct("rabbbit","rabbit"));
        Console.WriteLine(obj.NumDistinct("babgbag","bag"));
    }
    
    public int NumDistinct(string s, string t)
    {
        int[,] dp = new int[s.Length, t.Length];
        int num = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t[0])
            {
                num++;
            }
            dp[i, 0] = num;
        }

        for (int i = 1; i < s.Length; i++)
        {
            for (int j = 1; j < t.Length; j++)
            {
                if (s[i] == t[j])
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                else
                    dp[i, j] = dp[i - 1, j];
            }
        }

        return dp[s.Length - 1, t.Length - 1];
    }
}