using System.Diagnostics;
using CSharpPractice.Util;
using Microsoft.VisualBasic;

namespace CSharpPractice.LeetCode;

public class Offer010Fib
{
    private const int MOD = 1000000007;
    private Dictionary<int, int> _resultMap = new();

    public int Fib(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        return (Fib(n - 1) + Fib(n - 2)) % MOD;
    }

    public int Fib2(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        if (_resultMap.ContainsKey(n))
            return _resultMap[n];
        int res = (Fib2(n - 1) + Fib2(n - 2)) % MOD;
        _resultMap[n] = res;
        return res;
    }

    public int Fib3(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        // f(0) f(1)
        int left = 0, right = 1;
        int res = 0;
        for (int i = 2; i <= n; i++)
        {
            res = (left + right) % MOD;
            left = right;
            right = res;
        }

        return res;
    }

    public int Fib4(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        MyMatrix a = new MyMatrix(2, 2)
        {
            [0, 0] = 1,
            [0, 1] = 1,
            [1, 0] = 1,
            [1, 1] = 0
        };
        MyMatrix res = Pow(a, n);
        return res[0, 1];
    }

    private MyMatrix Pow(MyMatrix a, int n)
    {
        // 单位矩阵
        MyMatrix res = new MyMatrix(2, 2)
        {
            [0, 0] = 1,
            [0, 1] = 0,
            [1, 0] = 0,
            [1, 1] = 1
        };
        while (n != 0)
        {
            if ((n & 1) == 1)
                res = res.Multiply(a);
            a = a.Multiply(a);
            n >>= 1;
        }
        return res;
    }

    public static void Offer010FibMain()
    {
        Offer010Fib obj = new();

        // PracticeUtil.GetMethodTime(() => { Console.WriteLine("f(43) = " + obj.Fib(43)); }, out double time2);
        // Console.WriteLine($"优化前总共花费{time2}ms.");

        // PracticeUtil.GetMethodTime(() => { Console.WriteLine("f(100) = " + obj.Fib2(1000000)); }, out double time1);
        // Console.WriteLine($"优化后总共花费{time1}ms.");

        TimeUtil.GetMethodTime(() => { Console.WriteLine("f(100) = " + obj.Fib3(45)); }, out double time3);
        Console.WriteLine($"优化后总共花费{time3}ms.");
        
        TimeUtil.GetMethodTime(() => { Console.WriteLine("f(100) = " + obj.Fib4(45)); }, out double time4);
        Console.WriteLine($"优化后总共花费{time4}ms.");
    }
}