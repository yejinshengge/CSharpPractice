namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR094
{
    public static void Test()
    {
        LeetCode_LCR094 obj = new LeetCode_LCR094();
        Console.WriteLine(obj.MinCut("aab"));// 1
        Console.WriteLine(obj.MinCut("a"));// 0
        Console.WriteLine(obj.MinCut("ab"));// 1
        Console.WriteLine(obj.MinCut("aba"));// 0
    }
    
    public int MinCut(string s)
    {
        // 动态规划提前计算[i,j]是否为回文串
        bool[,] isPal = new bool[s.Length, s.Length];
        for (var i = 0; i < s.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (s[i] == s[j] && (i - j <= 1 || isPal[j + 1, i - 1]))
                    isPal[j,i] = true;
            }
        }

        
        int[] dp = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            // 如果[0,i]是回文串，则不需要分割
            if (isPal[0, i])
                dp[i] = 0;
            else
            {
                // 最多分割i次
                dp[i] = i;
                // 遍历[1,i]，找到最小的分割次数
                for (int j = 1; j <= i; j++)
                {
                    if (isPal[j, i])
                        dp[i] = Math.Min(dp[j - 1] + 1, dp[i]);
                }
            }
        }

        return dp[s.Length - 1];
    }
}