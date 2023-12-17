using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
 * 给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
    
    说明：每次只能向下或者向右移动一步。
 */
public class LeetCode_0064
{
    public static void Test()
    {
        LeetCode_0064 obj = new LeetCode_0064();
        Console.WriteLine(obj.MinPathSum(Tools.ConstructTArray("[[1,3,1],[1,5,1],[4,2,1]]")));
        Console.WriteLine(obj.MinPathSum(Tools.ConstructTArray("[[1,2,3],[4,5,6]]")));
    }
    
    public int MinPathSum(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        int[] dp = new int[cols + 1];
        // 初始化DP
        for (int i = 1; i <= cols; i++)
        {
            dp[i] = grid[0][i - 1]+dp[i-1];
        }

        for (int i = 2; i <= rows; i++)
        {
            dp[1] += grid[i - 1][0];
            for (int j = 2; j <= cols; j++)
            {
                dp[j] = Math.Min(dp[j], dp[j - 1]) + grid[i - 1][j - 1];
            }
        }

        return dp[cols];
    }
}