using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR116
{
    public static void Test()
    {
        LeetCode_LCR116 obj = new LeetCode_LCR116();
        Console.WriteLine(obj.FindCircleNum(Tools.ConstructTArray("[[1,1,0],[1,1,0],[0,0,1]]")));
        Console.WriteLine(obj.FindCircleNum(Tools.ConstructTArray("[[1,0,0],[0,1,0],[0,0,1]]")));
    }
    
    public int FindCircleNum(int[][] isConnected)
    {
        int[] fathers = new int[isConnected.Length];
        for (int i = 0; i < isConnected.Length; i++)
        {
            fathers[i] = i;
        }

        int count = isConnected.Length;
        for (var i = 0; i < isConnected.Length; i++)
        {
            for (var j = i+1; j < isConnected[i].Length; j++)
            {
                if (isConnected[i][j] == 1 && _union(fathers, i, j))
                    count--;
            }
        }

        return count;
    }

    private bool _union(int[] fathers, int i, int j)
    {
        var root1 = _findFather(fathers, i);
        var root2 = _findFather(fathers, j);
        // 两个跟节点不一样，合并
        if (root1 != root2)
        {
            fathers[root1] = root2;
            return true;
        }
        return false;
    }

    private int _findFather(int[] fathers, int i)
    {
        // 当前节点的父亲不是它自己,继续寻找父节点
        if (fathers[i] != i)
            fathers[i] = _findFather(fathers, fathers[i]);
        return fathers[i];
    }
}