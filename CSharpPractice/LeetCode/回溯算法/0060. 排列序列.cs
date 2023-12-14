using System.Text;

namespace CSharpPractice.LeetCode.回溯算法;

/**
 * 给出集合 [1,2,3,...,n]，其所有元素共有 n! 种排列。
    
    按大小顺序列出所有排列情况，并一一标记，给定 n 和 k，返回第 k 个排列。
 */
public class LeetCode_0060
{
    public static void Test()
    {
        LeetCode_0060 obj = new LeetCode_0060();
        Console.WriteLine(obj.GetPermutation(3,3));
        Console.WriteLine(obj.GetPermutation(4,9));
        Console.WriteLine(obj.GetPermutation(3,1));
    }

    private int[] _factorial;
    private bool[] _used;
    private int _n;
    private int _k;
    public string GetPermutation(int n, int k)
    {
        _n = n;
        _k = k;
        // 计算阶乘数组
        _factorial = new int[n + 1];
        _factorial[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            _factorial[i] = _factorial[i - 1] * i;
        }
        // 记录是否使用过的数组
        _used = new bool[n+1];
        // 结果
        StringBuilder builder = new StringBuilder();
        _doGetPermutation(0, builder);
        return builder.ToString();
    }

    private void _doGetPermutation(int index, StringBuilder res)
    {
        if(index == _n)
            return;
        int fac = _factorial[_n - 1 - index];
        for (int i = 1; i <= _n; i++)
        {
            if(_used[i]) continue;
            if (fac < _k)
            {
                _k -= fac;
                continue;
            }

            res.Append(i);
            _used[i] = true;
            _doGetPermutation(index+1,res);
        }
    }
}