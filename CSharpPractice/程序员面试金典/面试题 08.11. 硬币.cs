namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_11
{
    public static void Test()
    {
        LeetCode_08_11 obj = new LeetCode_08_11();
        Console.WriteLine(obj.WaysToChange(5));
        Console.WriteLine(obj.WaysToChange(10));
    }
    
    public int WaysToChange(int n)
    {
        int[] dp = new int[n+1];
        dp[0] = 1;
        int[] coins = {1,5,10,25 };
        
        foreach (var coin in coins)
        {
            for (int i = coin; i <= n; i++)
            {
                dp[i] = (dp[i]+dp[i - coin])%1000000007;
            }
        }
        return dp[n];
    }
}