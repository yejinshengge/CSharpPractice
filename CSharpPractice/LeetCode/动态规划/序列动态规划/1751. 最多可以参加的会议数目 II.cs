using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个 events 数组，其中 events[i] = [startDayi, endDayi, valuei] ，表示第 i 个会议在 startDayi 天开始，第 endDayi 天结束，如果你参加这个会议，你能得到价值 valuei 。同时给你一个整数 k 表示你能参加的最多会议数目。

你同一时间只能参加一个会议。如果你选择参加某个会议，那么你必须 完整 地参加完这个会议。会议结束日期是包含在会议内的，也就是说你不能同时参加一个开始日期与另一个结束日期相同的两个会议。

请你返回能得到的会议价值 最大和 。
 */
public class LeetCode_1751
{
    public static void Test()
    {
        LeetCode_1751 obj = new LeetCode_1751();
        Console.WriteLine(obj.MaxValue(Tools.ConstructTArray("[[1,2,4],[3,4,3],[2,3,1]]"),2));
        Console.WriteLine(obj.MaxValue(Tools.ConstructTArray("[[1,2,4],[3,4,3],[2,3,10]]"),2));
        Console.WriteLine(obj.MaxValue(Tools.ConstructTArray("[[1,1,1],[2,2,2],[3,3,3],[4,4,4]]"),3));
        Console.WriteLine(obj.MaxValue(Tools.ConstructTArray("[[74,91,40]]"),1));
        Console.WriteLine(obj.MaxValue(Tools.ConstructTArray("[[21,77,43],[2,74,47],[6,59,22],[47,47,38],[13,74,57],[27,55,27],[8,15,8]]"),4));
    }
    
    public int MaxValue(int[][] events, int k)
    {
        Array.Sort(events, (e1, e2) => e1[1] - e2[1]);
        int[,] dp = new int[events.Length+1,k+1];
        
        for (int i = 1; i <= events.Length; i++)
        {
            int left = 0, right = i-1;
            while (left < right)
            {
                int mid = (left + right+1) >> 1;
                if (events[mid][1] < events[i - 1][0])
                    left = mid;
                else
                    right = mid-1;
            }

            left = events[left][1] < events[i - 1][0] ? left : -1;
            for (int j = 1; j <= k; j++)
            {
                dp[i, j] = Math.Max(dp[left+1, j - 1] + events[i - 1][2], dp[i-1, j]);
            }
            
        }
        return dp[events.Length,k];
    }
}