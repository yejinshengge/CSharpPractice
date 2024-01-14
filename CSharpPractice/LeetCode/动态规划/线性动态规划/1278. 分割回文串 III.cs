namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个由小写字母组成的字符串 s，和一个整数 k。
    
    请你按下面的要求分割字符串：
    
    首先，你可以将 s 中的部分字符修改为其他的小写英文字母。
    接着，你需要把 s 分割成 k 个非空且不相交的子串，并且每个子串都是回文串。
    请返回以这种方式分割字符串所需修改的最少字符数。
 */
public class LeetCode_1278
{
    public static void Test()
    {
        LeetCode_1278 obj = new LeetCode_1278();
        Console.WriteLine(obj.PalindromePartition("abc",2));
        Console.WriteLine(obj.PalindromePartition("aabbc",3));
        Console.WriteLine(obj.PalindromePartition("leetcode",8));
    }
    
    public int PalindromePartition(string s, int k)
    {
        // 计算所有子串变成回文所需修改的字符数
        int[,] cost = new int[s.Length,s.Length];
        // 枚举子串长度
        for (int len = 2; len <= s.Length; len++)
        {
            // 枚举子串起始位置
            for (int left = 0; left <= s.Length-len; left++)
            {
                int right = left + len - 1;
                cost[left, right] = cost[left+1, right-1] + (s[left] == s[right] ? 0 : 1);
            }
        }

        int[,] dp = new int[s.Length+1,k+1];
        for (int i = 0; i < s.Length+1; i++)
        {
            for (int j = 0; j < k+1; j++)
            {
                dp[i, j] = 101;
            }
        }

        dp[0, 0] = 0;
        // 枚举前i位
        for (int i = 1; i <= s.Length; i++)
        {
            // 枚举子串数量
            for (int j = 1; j <= Math.Min(i,k); j++)
            {
                // 枚举最后一个子串起始位置
                for (int l = 0; l < i; l++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[l, j - 1] + cost[l, i - 1]);
                }
            }
        }

        return dp[s.Length, k];
    }
}