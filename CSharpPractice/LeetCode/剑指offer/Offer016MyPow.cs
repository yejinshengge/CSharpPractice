namespace CSharpPractice.LeetCode;

public class Offer016MyPow
{
    public static void Offer016MyPowMain()
    {
        Offer016MyPow obj = new();
        Console.WriteLine(obj.MyPow(2,3));
        Console.WriteLine(obj.MyPow(2,1));
        Console.WriteLine(obj.MyPow(2,0));
        Console.WriteLine(obj.MyPow(2,10));
        Console.WriteLine(obj.MyPow(2,-2));
        Console.WriteLine(obj.MyPow(1,-2147483648));
        Console.WriteLine("-------------------------");
        Console.WriteLine(obj.MyPow2(2,3));
        Console.WriteLine(obj.MyPow2(2,1));
        Console.WriteLine(obj.MyPow2(2,0));
        Console.WriteLine(obj.MyPow2(2,10));
        Console.WriteLine(obj.MyPow2(2,-2));
        Console.WriteLine(obj.MyPow2(1,-2147483648));
    }
    
    public double MyPow(double x, int n)
    {
        long N = n;
        if (N == 0)
            return 1;
        double res = x;
        long num = N > 0 ? N : -N;
        for (long i = 1; i < num; i++)
        {
            res *= x;
        }

        if (N < 0)
            res = 1 / res;
        return res;
    }
    
    public double MyPow2(double x, int n)
    {
        long N = n;
        if (N == 0)
            return 1;
        double res = Pow(x, N>0?N:-N);
        if (N < 0)
            res = 1 / res;
        return res;
    }

    private double Pow(double a, long n)
    {
        double res = 1;
        while (n !=0)
        {
            // 当前位为1,计入结果
            if ((n & 1) == 1)
                res = res * a;
            // a自乘
            a *= a;
            // n右移
            n >>= 1;
        }
        return res;
    }
}