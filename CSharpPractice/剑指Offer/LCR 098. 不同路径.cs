namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR098
{
    public static void Test()
    {
        LeetCode_LCR098 obj = new LeetCode_LCR098();
        Console.WriteLine(obj.UniquePaths(3,7));//28
        Console.WriteLine(obj.UniquePaths(3,2));//3
        Console.WriteLine(obj.UniquePaths(7,3));//28
        Console.WriteLine(obj.UniquePaths(3,3));//6
        Console.WriteLine(obj.UniquePaths(1,1));//1
        
    }
    
    public int UniquePaths2(int m, int n)
    {
        int[,] dp = new int[m,n];
        for (int i = 0; i < m; i++)
        {
            dp[i, 0] = 1;
        }

        for (int i = 0; i < n; i++)
        {
            dp[0, i] = 1;
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m-1, n-1];
    }
    
    public int UniquePaths(int m, int n)
    {
        int[] dp = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[j] += dp[j - 1];
            }
        }

        return dp[n-1];
    }
}