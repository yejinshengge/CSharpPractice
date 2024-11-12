namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR088
{
    public static void Test()
    {
        LeetCode_LCR088 obj = new LeetCode_LCR088();
        Console.WriteLine(obj.MinCostClimbingStairs(new []{10, 15, 20}));
        Console.WriteLine(obj.MinCostClimbingStairs(new []{1, 100, 1, 1, 1, 100, 1, 1, 100, 1}));
    }
    
    public int MinCostClimbingStairs(int[] cost)
    {
        int[] dp = new int[cost.Length+1];
        for (int i = 2; i <= cost.Length; i++)
        {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
        }

        return dp[cost.Length];
    }
}