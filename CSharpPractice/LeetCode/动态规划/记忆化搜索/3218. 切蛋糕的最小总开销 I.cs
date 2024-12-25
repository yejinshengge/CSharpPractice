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
    
    private int _doMinimumCost(int row1, int col1, int row2, int col2)
    {
        if (row1 == row2 && col1 == col2)
            return 0;
        if (_cache[row1][col1][row2][col2] > 0)
            return _cache[row1][col1][row2][col2];
        int res = int.MaxValue;
        for (int i = row1; i < row2; i++)
        {
            res = Math.Min(res,
                _doMinimumCost(row1, col1, i, col2) + _doMinimumCost(i + 1, col1, row2, col2) + _horizontalCut[i]);
        }
        
        for (int i = col1; i < col2; i++)
        {
            res = Math.Min(res,
                _doMinimumCost(row1, col1, row2, i) + _doMinimumCost(row1, i+1, row2, col2) + _verticalCut[i]);
        }

        _cache[row1][col1][row2][col2] = res;
        return res;
    }
}