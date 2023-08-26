using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.贪心算法;

/**
 * 以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。
 * 请你合并所有重叠的区间，并返回 一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间 。
 */
public class LeetCode_0056
{
    public static void Test()
    {
        LeetCode_0056 obj = new LeetCode_0056();
        var tArray = Tools.ConstructTArray("[[1,4],[4,5]]");
        Tools.PrintEnumerator(obj.Merge(tArray));
    }
    
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals,(e1,e2) => e1[0] - e2[0]);
        List<int[]> res = new List<int[]>();
        int left = intervals[0][0], right = intervals[0][1];
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] > right)
            {
                res.Add(new []{left,right});
                left = intervals[i][0];
                right = intervals[i][1];
            }
            else if (intervals[i][1] > right)
            {
                right = intervals[i][1];
            }
        }
        res.Add(new []{left,right});
        return res.ToArray();
    }
}