using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。
机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish”）。
现在考虑网格中有障碍物。那么从左上角到右下角将会有多少条不同的路径？
网格中的障碍物和空位置分别用 1 和 0 来表示。
 */
public class LeetCode_0063
{
    public static void Test()
    {
        LeetCode_0063 obj = new LeetCode_0063();
        var tArray = Tools.ConstructTArray("[[0,1],[0,0]]");
        Console.WriteLine(obj.UniquePathsWithObstacles(tArray));
        
    }
    
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int[] arr = new int[obstacleGrid[0].Length];

        for (int i = 0; i < arr.Length; i++)
        {
            // 遇到障碍物
            if (obstacleGrid[0][i] == 1)
                break;
            arr[i] = 1;
        }

        for (int i = 1; i < obstacleGrid.Length; i++)
        {
            for (int j = 0; j < obstacleGrid[i].Length; j++)
            {
                // 遇到障碍物
                if (obstacleGrid[i][j] == 1)
                    arr[j] = 0;
                else if(j > 0)
                    arr[j] += arr[j - 1];
            }
        }
        return arr[^1];
    }
}