namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR095
{
    public static void Test()
    {
        LeetCode_LCR095 obj = new LeetCode_LCR095();
        Console.WriteLine(obj.LongestCommonSubsequence("abcde","ace" ));// 3
        Console.WriteLine(obj.LongestCommonSubsequence("abc","abc" ));// 3
        Console.WriteLine(obj.LongestCommonSubsequence("abc","def" ));// 0
        Console.WriteLine(obj.LongestCommonSubsequence("a","a" ));// 1
        Console.WriteLine(obj.LongestCommonSubsequence("a","b" ));// 0
    }
    
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int[] dp = new int[text2.Length+1];
        for (int i = 1; i <= text1.Length; i++)
        {
            int leftTop = 0;
            for (int j = 1; j <= text2.Length; j++)
            {
                int len = 0;
                if (text1[i-1] == text2[j-1])
                    len = leftTop + 1;
                else
                    len = Math.Max(dp[j], dp[j - 1]);
                leftTop = dp[j];
                dp[j] = len;
            }
        }

        return dp[text2.Length];
    }
}