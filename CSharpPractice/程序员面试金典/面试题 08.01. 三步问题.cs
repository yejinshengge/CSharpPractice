namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_01
{
    public static void Test()
    {
        LeetCode_08_01 obj = new LeetCode_08_01();
        Console.WriteLine(obj.WaysToStep(3));
        Console.WriteLine(obj.WaysToStep(5));
    }
    
    public int WaysToStep(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 2;
        if (n == 3) return 4;
        const int MOD = 1000000007;
        int[] dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 4;
        for (int i = 4; i <= n; i++)
        {
            dp[i] = (dp[i - 1] + (dp[i - 2] + dp[i - 3])%MOD)%MOD;
        }

        return dp[n];
    }
}