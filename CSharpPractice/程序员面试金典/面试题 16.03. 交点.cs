using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_16_03
{
    public static void Test()
    {
        LeetCode_16_03 obj = new LeetCode_16_03();
        Tools.PrintArr(obj.Intersection(new []{0,0 },new []{1,0},new []{1,1},new []{0,-1}));
    }
    
    public double[] Intersection(int[] start1, int[] end1, int[] start2, int[] end2)
    {
        int x1 = start1[0], x2 = end1[0], x3 = start2[0], x4 = end2[0];
        int y1 = start1[1], y2 = end1[1], y3 = start2[1], y4 = end2[1];
        double[] res = Array.Empty<double>();
        // 两直线平行
        if ((y2 - y1) * (x4 - x3) == (y4 - y3) * (x2 - x1))
        {
            // 两直线重合
            if ((y2 - y1) * (x3 - x1) == (y3 - y1) * (x2 - x1))
            {
                if(_isInside(x1,y1,x2,y2,x3,y3))
                    _updateRes(x3,y3,ref res);
                if(_isInside(x1,y1,x2,y2,x4,y4))
                    _updateRes(x4,y4,ref res);
                if(_isInside(x3,y3,x4,y4,x1,y1))
                    _updateRes(x1,y1,ref res);
                if(_isInside(x3,y3,x4,y4,x2,y2))
                    _updateRes(x2,y2,ref res);
            }
        }
        // 不平行
        else
        {
            double t1 = (double)((y1 - y3) * (x4 - x3) - (x1 - x3) * (y4 - y3)) /
                        ((x2 - x1) * (y4 - y3) - (y2 - y1) * (x4 - x3));
            double t2 = (double)((y2 - y1) * (x3 - x1) - (x2 - x1) * (y3 - y1)) /
                        ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
            // 交点在线段上
            if (t1 is >= 0 and <= 1 && t2 is >= 0 and <= 1)
                res = new[] { x1 + t1 * (x2 - x1), y1 + t1 * (y2 - y1) };
        }

        return res;
    }

    // 判断xk,yk是否在线段范围内
    private bool _isInside(int x1, int y1, int x2, int y2, int xk, int yk)
    {
        // 需要考虑垂直或水平线段
        return (x1 == x2||(xk >= Math.Min(x1,x2) && xk <= Math.Max(x1,x2))) && 
               (y1 == y2 || (yk >= Math.Min(y1, y2) && yk <= Math.Max(y1, y2)));
    }

    private void _updateRes(double xk, double yk,ref double[] res)
    {
        if (res.Length == 0 || xk < res[0] || xk == res[0] && yk < res[1])
        {
            res = new[] { xk, yk };
        }
    }
}