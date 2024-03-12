using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

public class LeetCode_0354
{
    public static void Test()
    {
        LeetCode_0354 obj = new LeetCode_0354();
        Console.WriteLine(obj.MaxEnvelopes(Tools.ConstructTArray("[[5,4],[6,4],[6,7],[2,3]]")));
        Console.WriteLine(obj.MaxEnvelopes(Tools.ConstructTArray("[[1,1],[1,1],[1,1]]")));
    }
    
    public int MaxEnvelopes(int[][] envelopes)
    {
        var length = envelopes.Length;
        int[] dp = new int[length];
        Array.Sort(envelopes, (e1, e2) =>
        {
            if (e1[0] != e2[0])
                return e1[0] - e2[0];
            return e1[1] - e2[1];
        });
        int max = 1;
        for (int i = 0; i < length; i++)
        {
            // 每个信封都可以单独成组
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if(envelopes[i][0] > envelopes[j][0] 
                   && envelopes[i][1] > envelopes[j][1])
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }

            max = Math.Max(max, dp[i]);
        }

        return max;
    }
}