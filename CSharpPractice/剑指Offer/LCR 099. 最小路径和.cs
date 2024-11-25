using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR099
{
    public static void Test()
    {
        LeetCode_LCR099 obj = new LeetCode_LCR099();
        Console.WriteLine(obj.MinPathSum(Tools.ConstructTArray("[[1,3,1],[1,5,1],[4,2,1]]")));
        Console.WriteLine(obj.MinPathSum(Tools.ConstructTArray("[[1,2,3],[4,5,6]]")));
        Console.WriteLine(obj.MinPathSum(Tools.ConstructTArray("[[1]]")));
    }
    
    public int MinPathSum(int[][] grid)
    {
        int[] dp = new int[grid[0].Length];
        int sum = 0;
        sum = 0;
        for (int i = 0; i < grid[0].Length; i++)
        {
            sum += grid[0][i];
            dp[i] = sum;
        }
        for (int i = 1; i < grid.Length; i++)
        {
            dp[0] += grid[i][0];
            for (int j = 1; j < grid[0].Length; j++)
            {
                dp[j] = Math.Min(dp[j-1], dp[j]) + grid[i][j];
            }
        }

        return dp[grid[0].Length-1];
    }
}