using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR074
{
    public static void Test()
    {
        LeetCode_LCR074 obj = new LeetCode_LCR074();

    }
    
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals,(e1,e2) => e1[0] - e2[0]);
        List<int[]> res = new List<int[]>();
        res.Add(intervals[0]);
        for (var i = 1; i < intervals.Length; i++)
        {
            var cur = intervals[i];
            var pre = res[^1];
            if (cur[0] <= pre[1])
                pre[1] = Math.Max(cur[1], pre[1]);
            else
                res.Add(cur);
        }

        return res.ToArray();
    }
}