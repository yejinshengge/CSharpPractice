namespace CSharpPractice.数据结构.练习;

public class MatrixFastPower {

    public static void Test()
    {
        Console.WriteLine(Pow(2,10));
    }

    public static double Pow(double a, int n)
    {
        double res = 1;
        while (n != 0)
        {
            if ((n & 1) == 1)
                res *= a;
            a *= a;
            n >>= 1;
        }

        return res;
    }
}