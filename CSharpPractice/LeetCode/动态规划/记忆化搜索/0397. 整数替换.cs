namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

public class LeetCode_0397
{
    public static void Test()
    {
        LeetCode_0397 obj = new LeetCode_0397();
        Console.WriteLine(obj.IntegerReplacement(8));
        Console.WriteLine(obj.IntegerReplacement(7));
        Console.WriteLine(obj.IntegerReplacement(4));
        Console.WriteLine(obj.IntegerReplacement(1));
        Console.WriteLine(obj.IntegerReplacement(int.MaxValue));
    }

    private Dictionary<int, int> _dic = new();
    public int IntegerReplacement(int n)
    {
        _dic.Clear();
        return _doIntegerReplacement(n);
    }

    private int _doIntegerReplacement(int n)
    {
        if (_dic.TryGetValue(n, out var res))
            return res;
        if (n <= 1) return 0;
        if (n % 2 == 0)
            res = _doIntegerReplacement(n / 2) + 1;
        else
            res = Math.Min(_doIntegerReplacement((n-1)/2+1), 
                _doIntegerReplacement((n-1)/2)) + 2;
        _dic[n] = res;
        return _dic[n];
    }
}