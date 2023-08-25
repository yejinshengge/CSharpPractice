using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.贪心算法;

// 给定一个区间的集合 intervals ，其中 intervals[i] = [starti, endi] 。
// 返回 需要移除区间的最小数量，使剩余区间互不重叠 。
public class LeetCode_0435
{
    public static void Test()
    {
        LeetCode_0435 obj = new LeetCode_0435();
        var tArray = Tools.ConstructTArray("[[-52,31],[-73,-26],[82,97],[-65,-11],[-62,-49],[95,99],[58,95],[-31,49],[66,98],[-63,2],[30,47],[-40,-26]]");
        Console.WriteLine(obj.EraseOverlapIntervals(tArray));
    }
    
    public int EraseOverlapIntervals(int[][] intervals)
    {
        int res = 0;
        Array.Sort(intervals, (e1, e2) =>
        {
            if (e1[0] == e2[0]) return e1[1] - e2[1];
            return e1[0] - e2[0];
        });
        int right = intervals[0][1];
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] < right)
            {
                res++;
                right = Math.Min(intervals[i][1], right);
            }
            else
                right = intervals[i][1];
        }

        return res;
    }
}