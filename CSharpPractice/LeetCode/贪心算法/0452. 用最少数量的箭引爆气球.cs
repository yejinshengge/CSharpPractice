using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.贪心算法;

/**
有一些球形气球贴在一堵用 XY 平面表示的墙面上。墙面上的气球记录在整数数组 points ，
其中points[i] = [xstart, xend] 表示水平直径在 xstart 和 xend之间的气球。你不知道气球的确切 y 坐标。
一支弓箭可以沿着 x 轴从不同点 完全垂直 地射出。在坐标 x 处射出一支箭，若有一个气球的直径的开始和结束坐标为 xstart，
xend， 且满足  xstart ≤ x ≤ xend，则该气球会被 引爆 。可以射出的弓箭的数量 没有限制 。 弓箭一旦被射出之后，可以无限地前进。
给你一个数组 points ，返回引爆所有气球所必须射出的 最小 弓箭数 。
 */
public class LeetCode_0452
{
    public static void Test()
    {
        LeetCode_0452 obj = new LeetCode_0452();
        var tArray = Tools.ConstructTArray("[[-2147483646,-2147483645],[2147483646,2147483647]]");
        Console.WriteLine(obj.FindMinArrowShots(tArray));
    }
    
    public int FindMinArrowShots(int[][] points) {
        Array.Sort(points, (e1, e2) =>
        {
            if (e1[0] > e2[0]) return 1;
            if (e1[0] < e2[0]) return -1;
            return 0;
        });
        long startIndex = long.MinValue;
        long endIndex = long.MinValue;
        int total = 0;
        for (int i = 0; i < points.Length; i++)
        {
            if (endIndex < points[i][0])
            {
                total++;
                startIndex = points[i][0];
                endIndex = points[i][1];
            }
            else
            {
                startIndex = Math.Max(startIndex, points[i][0]);
                endIndex = Math.Min(endIndex, points[i][1]);
            }
        }

        return total;
    }
}