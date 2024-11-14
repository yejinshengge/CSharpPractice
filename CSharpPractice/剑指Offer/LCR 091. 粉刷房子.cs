using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR091
{
    public static void Test()
    {
        LeetCode_LCR091 obj = new LeetCode_LCR091();
        Console.WriteLine(obj.MinCost(Tools.ConstructTArray("[[17,2,17],[16,16,5],[14,3,19]]")));
        Console.WriteLine(obj.MinCost(Tools.ConstructTArray("[[7,6,2]]")));
    }
    
    public int MinCost(int[][] costs)
    {
        int[,] dp = new int[1,3];
        for (int i = 1; i <= costs.Length; i++)
        {
            int val0 = Math.Min(dp[0, 1], dp[0, 2]) + costs[i-1][0];
            int val1 = Math.Min(dp[0, 2], dp[0, 0]) + costs[i-1][1];
            int val2 = Math.Min(dp[0, 0], dp[0, 1]) + costs[i-1][2];
            dp[0, 0] = val0;
            dp[0, 1] = val1;
            dp[0, 2] = val2;

        }

        return Math.Min(Math.Min(dp[0, 0], dp[0, 1]), dp[0, 2]);
    }
}