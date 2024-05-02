using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇;

/**
给你一个 无重叠的 ，按照区间起始端点排序的区间列表。
在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。
 */
public class LeetCode_0057
{
    public static void Test()
    {
        LeetCode_0057 obj = new LeetCode_0057();
        Tools.PrintEnumerator(obj.Insert(
            new[] {new[]{1,3},new[]{6,9}},new []{2,5}));
        Tools.PrintEnumerator(obj.Insert(
            new[] {new[]{1,2},new[]{3,5},new[]{6,7},new[]{8,10},new[]{12,16}},new []{4,8}));
        Tools.PrintEnumerator(obj.Insert(
            Array.Empty<int[]>(),new []{5,7}));
        Tools.PrintEnumerator(obj.Insert(
            new[] {new[]{1,5}},new []{2,3}));
        Tools.PrintEnumerator(obj.Insert(
            new[] {new[]{1,5}},new []{2,7}));
        Tools.PrintEnumerator(obj.Insert(
            new[] {new[]{1,5}},new []{6,8}));
        Tools.PrintEnumerator(obj.Insert(
            new[] {new[]{6,8}},new []{1,5}));
    }
    
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        int left = newInterval[0];
        int right = newInterval[1];
        List<int[]> res = new List<int[]>();
        bool merge = false;
        for (int i = 0; i < intervals.Length; i++)
        {
            var ele = intervals[i];
            // 在插入区间左侧,直接加入结果集
            if (ele[1] < left)
            {
                res.Add(ele);
            }
            // 在插入区间右侧
            else if (ele[0] > right)
            {
                if (!merge)
                {
                    res.Add(new []{left,right});
                    merge = true;
                }
                res.Add(ele);
            }
            // 与插入区间有交集
            else
            {
                left = Math.Min(left, ele[0]);
                right = Math.Max(right, ele[1]);
            }
        }

        if (!merge)
        {
            res.Add(new []{left,right});
        }

        return res.ToArray();
    }
    
}