using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给定一个三角形 triangle ，找出自顶向下的最小路径和。
    
    每一步只能移动到下一行中相邻的结点上。相邻的结点 在这里指的是 下标 与 上一层结点下标 
    相同或者等于 上一层结点下标 + 1 的两个结点。也就是说，如果正位于当前行的下标 i ，
    那么下一步可以移动到下一行的下标 i 或 i + 1 。
 */
public class LeetCode_0120
{
    public static void Test()
    {
        LeetCode_0120 obj = new LeetCode_0120();
        Console.WriteLine(obj.MinimumTotal(Tools.ConstructTList("[[2],[3,4],[6,5,7],[4,1,8,3]]")));
        Console.WriteLine(obj.MinimumTotal(Tools.ConstructTList("[[-10]]")));
    }
    
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int minPath = int.MaxValue;
        int[] dp = new int[triangle.Count];

        for (int i = 0; i < triangle.Count; i++)
        {
            for (int j = triangle[i].Count-1; j >=0; j--)
            {
                if(j == 0)
                    dp[j] += triangle[i][j];
                else if(j==i)
                    dp[j] = dp[j - 1]+triangle[i][j];
                else
                    dp[j] = Math.Min(dp[j - 1], dp[j]) + triangle[i][j];

                if (i == triangle.Count - 1)
                    minPath = Math.Min(minPath, dp[j]);
            }
        }
        
        return minPath;
    }
}