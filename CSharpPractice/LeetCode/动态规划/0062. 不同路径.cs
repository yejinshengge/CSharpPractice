namespace CSharpPractice.LeetCode.动态规划;

/**
一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。

机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish” ）。

问总共有多少条不同的路径？
 */
public class LeetCode_0062
{
    public static void Test()
    {
        LeetCode_0062 obj = new LeetCode_0062();
        Console.WriteLine(obj.UniquePaths(3,7));
        Console.WriteLine(obj.UniquePaths(3,2));
        Console.WriteLine(obj.UniquePaths(3,3));
    }
    
    public int UniquePaths(int m, int n)
    {
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = 1;
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                arr[j] += arr[j - 1];
            }
        }

        return arr[n - 1];
    }
}