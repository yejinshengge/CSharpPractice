using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 在一个小城市里，有 m 个房子排成一排，你需要给每个房子涂上 n 种颜色之一（颜色编号为 1 到 n ）。有的房子去年夏天已经涂过颜色了，所以这些房子不可以被重新涂色。

    我们将连续相同颜色尽可能多的房子称为一个街区。（比方说 houses = [1,2,2,3,3,2,1,1] ，它包含 5 个街区  [{1}, {2,2}, {3,3}, {2}, {1,1}] 。）

    给你一个数组 houses ，一个 m * n 的矩阵 cost 和一个整数 target ，其中：

    houses[i]：是第 i 个房子的颜色，0 表示这个房子还没有被涂色。
    cost[i][j]：是将第 i 个房子涂成颜色 j+1 的花费。
    请你返回房子涂色方案的最小总花费，使得每个房子都被涂色后，恰好组成 target 个街区。如果没有可用的涂色方案，请返回 -1 。
 */
public class LeetCode_1473
{
    public static void Test()
    {
        LeetCode_1473 obj = new LeetCode_1473();
        Console.WriteLine(obj.MinCost(new []{0,0,0,0,0},
            Tools.ConstructTArray("[[1,10],[10,1],[10,1],[1,10],[5,1]]"),5,2,3));
        Console.WriteLine(obj.MinCost(new []{0,2,1,2,0},
            Tools.ConstructTArray("[[1,10],[10,1],[10,1],[1,10],[5,1]]"),5,2,3));        
        Console.WriteLine(obj.MinCost(new []{0,0,0,0,0},
            Tools.ConstructTArray("[[1,10],[10,1],[1,10],[10,1],[1,10]]"),5,2,5));        
        Console.WriteLine(obj.MinCost(new []{3,1,2,3},
            Tools.ConstructTArray("[[1,1,1],[1,1,1],[1,1,1],[1,1,1]]"),4,3,3));
        Console.WriteLine(obj.MinCost(new []{0},
            Tools.ConstructTArray("[[2]]"),1,1,1));  
        Console.WriteLine(obj.MinCost(new []{1},
            Tools.ConstructTArray("[[2]]"),1,1,1));     
    }
    


    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
        int[,,] dp = new int[m+1,target+1,n+1];
        
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= target; j++)
            {
                for (int k = 0; k <= n; k++)
                {
                    dp[i, j, k] = int.MaxValue/2;
                }
            }
        }

        for (int k = 1; k <= n; k++)
        {
            dp[0, 0, k] = 0;
            if(k == houses[0])
                dp[1, 1, k] = 0;
            else if(houses[0] == 0)
                dp[1, 1, k] = cost[0][k-1];
        }

        
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                for (int k = 1; k <= n; k++)
                {
                    // 当前房屋未涂色
                    if (houses[i - 1] == 0)
                    {
                        for (int l = 1; l <= n; l++)
                        {
                            // 与前一个房屋为同一个街区
                            if (l == k)
                                dp[i, j, k] = Math.Min(dp[i, j, k], dp[i - 1, j, l]+cost[i-1][k-1]);
                            // 与前一个房屋为不同街区
                            else
                                dp[i, j, k] = Math.Min(dp[i, j, k], dp[i - 1, j-1, l]+cost[i-1][k-1]);
                        }
                    }
                    // 已经涂过该颜色，不需要再次涂色
                    else if(houses[i - 1] == k)
                    {
                        for (int l = 1; l <= n; l++)
                        {
                            // 与前一个房屋为同一个街区
                            if (l == k)
                                dp[i, j, k] = Math.Min(dp[i, j, k], dp[i - 1, j, l]);
                            // 与前一个房屋为不同街区
                            else
                                dp[i, j, k] = Math.Min(dp[i, j, k], dp[i - 1, j-1, l]);
                        }
                    }

                }
            }

        }

        int minCost = int.MaxValue/2;
        for (int i = 1; i <= n; i++)
        {
            minCost = Math.Min(minCost, dp[m, target, i]);
        }
        return minCost == int.MaxValue/2 ? -1:minCost;
    }
}