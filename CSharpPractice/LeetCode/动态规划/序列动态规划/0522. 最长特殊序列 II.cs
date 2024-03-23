namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给定字符串列表 strs ，返回其中 最长的特殊序列 的长度。如果最长特殊序列不存在，返回 -1 。

    特殊序列 定义如下：该序列为某字符串 独有的子序列（即不能是其他字符串的子序列）。

     s 的 子序列可以通过删去字符串 s 中的某些字符实现。

    例如，"abc" 是 "aebdc" 的子序列，因为您可以删除"aebdc"中的下划线字符来得到 "abc" 。
    "aebdc"的子序列还包括"aebdc"、 "aeb" 和 "" (空字符串)。
 */
public class LeetCode_0522
{
    public static void Test()
    {
        LeetCode_0522 obj = new LeetCode_0522();
        Console.WriteLine(obj.FindLUSlength(new []{"aba","cdc","eae"}));
        Console.WriteLine(obj.FindLUSlength(new []{"aaa","aaa","aa"}));
    }
    
    public int FindLUSlength(string[] strs)
    {
        int maxLen = -1;

        for (int i = 0; i < strs.Length; i++)
        {
            bool isOk = true;
            if(strs[i].Length < maxLen) continue;
            for (int j = 0; j < strs.Length; j++)
            {
                if(i == j) continue;
                if (_check(strs[i], strs[j]))
                {
                    isOk = false;
                    break;
                }
            }

            if (isOk) maxLen = Math.Max(maxLen, strs[i].Length);
        }

        return maxLen;
    }

    private bool _check(string str1,string str2)
    {
        if (str1.Length > str2.Length) return false;
        int[,] dp = new int[str1.Length + 1, str2.Length + 1];

        for (int i = 1; i <= str1.Length; i++)
        {
            for (int j = 1; j <= str2.Length; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                if (dp[i, j] == str1.Length) return true;
            }
        }

        return false;
    }
}