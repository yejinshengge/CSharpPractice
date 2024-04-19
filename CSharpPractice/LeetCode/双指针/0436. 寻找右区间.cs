using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个区间数组 intervals ，其中 intervals[i] = [starti, endi] ，且每个 starti 都 不同 。

    区间 i 的 右侧区间 可以记作区间 j ，并满足 startj >= endi ，且 startj 最小化 。注意 i 可能等于 j 。

    返回一个由每个区间 i 的 右侧区间 在 intervals 中对应下标组成的数组。如果某个区间 i 不存在对应的 右侧区间 ，则下标 i 处的值设为 -1 。
 */
public class LeetCode_0436
{
    public static void Test()
    {
        LeetCode_0436 obj = new LeetCode_0436();
        Tools.PrintArr(obj.FindRightInterval(Tools.ConstructTArray("[[1,2]]")));
        Tools.PrintArr(obj.FindRightInterval(Tools.ConstructTArray("[[3,4],[2,3],[1,2]]")));
        Tools.PrintArr(obj.FindRightInterval(Tools.ConstructTArray("[[1,4],[2,3],[3,4]]")));
        Tools.PrintArr(obj.FindRightInterval(Tools.ConstructTArray("[[4,5],[2,3],[1,2]]")));
        Tools.PrintArr(obj.FindRightInterval(Tools.ConstructTArray("[[1,1],[3,4]]")));
    }
    
    public int[] FindRightInterval2(int[][] intervals)
    {
        // 记录下标
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < intervals.Length; i++)
        {
            dic[intervals[i][0]] = i;
        }
        // 排序
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });
        int[] res = new int[intervals.Length];
        for (int i = 0; i < intervals.Length; i++)
        {
            int left = i;
            int right = intervals.Length - 1;
            int index = -1;
            while (left <= right)
            {
                int mid = (left + right) >> 1;
                if (intervals[mid][0] > intervals[i][1])
                {
                    right = mid - 1;
                    index = mid;
                }
                else if (intervals[mid][0] < intervals[i][1])
                    left = mid + 1;
                else
                {
                    index = mid;
                    break;
                }
            }

            int curIndex = dic[intervals[i][0]];
            if (index != -1)
            {
                int targetIndex = dic[intervals[index][0]];
                res[curIndex] = targetIndex;
            }
            else
            {
                res[curIndex] = -1;
            }
        }

        return res;
    }

    public int[] FindRightInterval(int[][] intervals)
    {
        var len = intervals.Length;
        int[][] startArr = new int[len][];
        int[][] endArr = new int[len][];

        for (int i = 0; i < len; i++)
        {
            startArr[i] = new[] { intervals[i][0], i };
            endArr[i] = new[] { intervals[i][1], i };
        }
        Array.Sort(startArr,(a,b)=>a[0] - b[0]);
        Array.Sort(endArr,(a,b)=>a[0] - b[0]);
        int[] res = new int[len];
        for (int i = 0,j=0; i < len; i++)
        {
            while (j < len && startArr[j][0] < endArr[i][0])
            {
                j++;
            }

            if (j < len)
                res[endArr[i][1]] = startArr[j][1];
            else
                res[endArr[i][1]] = -1;
        }

        return res;
    }
}