namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/*
 * 如果一个二进制字符串，是以一些 0（可能没有 0）后面跟着一些 1（也可能没有 1）的形式组成的，那么该字符串是 单调递增 的。
   
   给你一个二进制字符串 s，你可以将任何 0 翻转为 1 或者将 1 翻转为 0 。
   
   返回使 s 单调递增的最小翻转次数。
 */
public class LeetCode_0926
{
    public static void Test()
    {
        LeetCode_0926 obj = new LeetCode_0926();
        Console.WriteLine(obj.MinFlipsMonoIncr2("00110"));
        Console.WriteLine(obj.MinFlipsMonoIncr2("010110"));
        Console.WriteLine(obj.MinFlipsMonoIncr2("00011000"));
        Console.WriteLine(obj.MinFlipsMonoIncr2("0"));
    }
    
    public int MinFlipsMonoIncr(string s)
    {
        int[,] dp = new int[s.Length+1,2];

        for (int i = 1; i <= s.Length; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + (s[i - 1] - '0');
            dp[i, 1] = Math.Min(dp[i - 1, 0],dp[i-1,1]) + (s[i-1] == '0' ? 1:0);
        }

        return Math.Min(dp[s.Length, 0], dp[s.Length, 1]);
    }
    
    public int MinFlipsMonoIncr2(string s)
    {
        int zeroSitu = 0;
        int oneSitu = 0;
        for (int i = 1; i <= s.Length; i++)
        {
            int curZero = zeroSitu;
            zeroSitu += s[i - 1] - '0';
            oneSitu = Math.Min(curZero,oneSitu) + (s[i-1] == '0' ? 1:0);
        }

        return Math.Min(zeroSitu, oneSitu);
    }
}