using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR118
{
    public static void Test()
    {
        LeetCode_LCR118 obj = new LeetCode_LCR118();
        Tools.PrintArr(obj.FindRedundantConnection(Tools.ConstructTArray("[[1,2],[1,3],[2,3]]")));
        Tools.PrintArr(obj.FindRedundantConnection(Tools.ConstructTArray("[[1,2],[2,3],[3,4],[1,4],[1,5]]")));
    }
    
    public int[] FindRedundantConnection(int[][] edges)
    {
        int maxNode = 0;
        foreach (var edge in edges)
        {
            maxNode = Math.Max(maxNode, edge[0]);
            maxNode = Math.Max(maxNode, edge[1]);
        }

        int[] fathers = new int[maxNode + 1];
        for (int i = 0; i < fathers.Length; i++)
        {
            fathers[i] = i;
        }
        
        foreach (var edge in edges)
        {
            if (!_union(fathers, edge[0], edge[1]))
                return edge;
        }

        return new int[2];
    }

    private bool _union(int[] fathers, int i, int j)
    {
        var root1 = _getFather(fathers, i);
        var root2 = _getFather(fathers, j);
        if (root1 != root2)
        {
            fathers[root1] = root2;
            return true;
        }

        return false;
    }

    private int _getFather(int[] fathers, int i)
    {
        if (fathers[i] != i)
            fathers[i] = _getFather(fathers, fathers[i]);
        return fathers[i];
    }
}