namespace CSharpPractice.LeetCode.动态规划.记忆化搜索;

public class LeetCode_0403
{
    public static void Test()
    {
        LeetCode_0403 obj = new LeetCode_0403();
        Console.WriteLine(obj.CanCross(new []{0,1,3,5,6,8,12,17}));
        Console.WriteLine(obj.CanCross(new []{0,1,2,3,4,8,9,11}));
    }

    #region 暴力枚举

    #if false
    public bool CanCross(int[] stones)
    {
        return _doCanCross(stones, 0, 1);
    }

    private bool _doCanCross(int[] stones, int index, int dis)
    {
        if (index == stones.Length - 1) return true;
        if (dis == 0) return false;
        for (int i = index+1; i < stones.Length; i++)
        {
            if (stones[index] + dis == stones[i])
                return _doCanCross(stones, i, dis - 1) || 
                       _doCanCross(stones, i, dis) ||
                       _doCanCross(stones, i, dis + 1);
        }
        return false;
    }
    #endif
    
    #endregion

    #region 记忆化搜索

#if true
        private Dictionary<int, int> _dic = new();
    private Dictionary<string, bool> _cache = new();
    public bool CanCross(int[] stones)
    {
        _dic.Clear();
        _cache.Clear();
        for (int i = 0; i < stones.Length; i++)
        {
            _dic[stones[i]] = i;
        }
        return _doCanCross(stones, 0, 1);
    }

    private bool _doCanCross(int[] stones, int index, int dis)
    {
        if (index == stones.Length - 1) return true;
        if (dis == 0) return false;
        if (_cache.TryGetValue(index + "_" + dis, out var res))
            return res;
        if (_dic.TryGetValue(stones[index] + dis, out var newIndex))
        {
            var canCross = _doCanCross(stones, newIndex, dis - 1) ||
                                _doCanCross(stones, newIndex, dis) ||
                                _doCanCross(stones, newIndex, dis + 1);
            _cache[index + "_" + dis] = canCross;
            return canCross;
        }

        _cache[index + "_" + dis] = false;
        return false;
    }
#endif

    #endregion

    #region 动态规划

#if true
    // public bool CanCross(int[] stones)
    // {
    //     // 跳j步到第i块石子能否到达最后
    //     bool[,] dp = new bool[stones.Length+1,stones.Length+1];
    //
    //     for (int i = 2; i < stones.Length; i++)
    //     {
    //         for (int j = 1; j < i; j++)
    //         {
    //             // 跳到i用了多少步
    //             int k = stones[i] - stones[j];
    //             
    //             
    //         }
    //     }
    // }
#endif

    #endregion


}