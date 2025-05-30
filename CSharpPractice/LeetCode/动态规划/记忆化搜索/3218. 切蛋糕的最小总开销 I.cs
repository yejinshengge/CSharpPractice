namespace CSharpPractice.LeetCode.动态规划.记忆化搜索;

public class LeetCode_3218
{
    public static void Test()
    {
        LeetCode_3218 obj = new LeetCode_3218();
        Console.WriteLine(obj.MinimumCost(3,2,new []{1,3},new []{5}));
        Console.WriteLine(obj.MinimumCost(2,2,new []{7},new []{4}));
        Console.WriteLine(obj.MinimumCost(1,1,Array.Empty<int>(),Array.Empty<int>()));
    }
    
    // 缓存
    private int[][][][] _cache;
    private int[] _horizontalCut;
    private int[] _verticalCut;
    public int MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut)
    {
        _cache = new int[m][][][];
        _horizontalCut = horizontalCut;
        _verticalCut = verticalCut;
        for (int i = 0; i < m; i++)
        {
            _cache[i] = new int[n][][];
            for (int j = 0; j < n; j++)
            {
                _cache[i][j] = new int[m][];
                for (int k = 0; k < m; k++)
                {
                    _cache[i][j][k] = new int[n];
                    Array.Fill(_cache[i][j][k],-1);
                }
            }
        }

        return _doMinimumCost(0,0,m-1,n-1);
    }
    
    // 切一块蛋糕需要的最小成本
    private int _doMinimumCost(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 && y1 == y2)
            return 0;
        if (_cache[x1][y1][x2][y2] > 0)
            return _cache[x1][y1][x2][y2];
        int res = int.MaxValue;
        // 沿第i行切开
        for (int i = x1; i < x2; i++)
        {
            res = Math.Min(res,
                _doMinimumCost(x1, y1, i, y2) + _doMinimumCost(i + 1, y1, x2, y2) + _horizontalCut[i]);
        }
        // 沿第i列切开
        for (int i = y1; i < y2; i++)
        {
            res = Math.Min(res,
                _doMinimumCost(x1, y1, x2, i) + _doMinimumCost(x1, i+1, x2, y2) + _verticalCut[i]);
        }

        _cache[x1][y1][x2][y2] = res;
        return res;
    }
}