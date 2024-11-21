namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR097
{
    public static void Test()
    {
        LeetCode_LCR097 obj = new LeetCode_LCR097();
        Console.WriteLine(obj.NumDistinct("rabbbit","rabbit"));// 3
        Console.WriteLine(obj.NumDistinct("babgbag","bag"));// 5
        Console.WriteLine(obj.NumDistinct("",""));// 1
        Console.WriteLine(obj.NumDistinct("","aaa"));// 0
        Console.WriteLine(obj.NumDistinct("aaa",""));// 1
    }
    
    public int NumDistinct2(string s, string t) {
        if (s == t) return 1;
        if (s.Length <= t.Length) return 0;
        
        int[,] dp = new int[s.Length+1,t.Length+1];
        for (int i = 0; i <= s.Length; i++)
        {
            dp[i, 0] = 1;
        }
        
        for (var i = 1; i <= s.Length; i++)
        {
            var len = Math.Min(i, t.Length);
            for (var j = 1; j <= len; j++)
            {
                if (s[i - 1] == t[j - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                dp[i, j] += dp[i - 1, j];
            }
        }

        return dp[s.Length, t.Length];
    }
    
    public int NumDistinct(string s, string t) {
        if (s == t) return 1;
        if (s.Length <= t.Length) return 0;
        
        int[] dp = new int[t.Length+1];
        dp[0] = 1;
        
        for (var i = 1; i <= s.Length; i++)
        {
            var len = Math.Min(i, t.Length);
            int pre = 1;
            for (var j = 1; j <= len; j++)
            {
                int num = 0;
                if (s[i - 1] == t[j - 1])
                    num = pre;
                num += dp[j];
                pre = dp[j];
                dp[j] = num;
            }
        }

        return dp[t.Length];
    }
}