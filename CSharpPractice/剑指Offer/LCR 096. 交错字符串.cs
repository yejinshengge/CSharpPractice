namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR096
{
    public static void Test()
    {
        LeetCode_LCR096 obj = new LeetCode_LCR096();
        Console.WriteLine(obj.IsInterleave("aabcc","dbbca","aadbbcbcac"));//t
        Console.WriteLine(obj.IsInterleave("aabcc","dbbca","aadbbbaccc"));//f
        Console.WriteLine(obj.IsInterleave("","",""));//t
        Console.WriteLine(obj.IsInterleave("a","b",""));//f
        Console.WriteLine(obj.IsInterleave("","","c"));//f
        Console.WriteLine(obj.IsInterleave("","b","b"));//t
    }
    
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length) return false;
        bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];
        dp[0, 0] = true;
        for (int i = 1; i <= s1.Length; i++)
        {
            dp[i, 0] = s1[i - 1] == s3[i - 1] && dp[i - 1, 0];
        }
        
        for (int i = 1; i <= s2.Length; i++)
        {
            dp[0,i] = s2[i - 1] == s3[i - 1] && dp[0,i-1];
        }
        
        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                int k = i + j;
                dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[k - 1]) ||
                           (dp[i, j - 1] && s2[j - 1] == s3[k - 1]);
                
            }
        }

        return dp[s1.Length, s2.Length];
    }
}