namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_05
{
    public static void Test()
    {
        LeetCode_08_05 obj = new LeetCode_08_05();
        Console.WriteLine(obj.Multiply1(1,10));
        Console.WriteLine(obj.Multiply1(3,4));
        Console.WriteLine(obj.Multiply1(-1,2));
        Console.WriteLine(obj.Multiply1(0,2));
    }

    private Dictionary<int, int> _dic = new();
    public int Multiply(int a, int b)
    {
        if (a == 0 || b == 0)
            return 0;
        if (a == 1 || a == -1)
            return a== -1 ?-b:b;
        if (b == 1 || b == -1)
            return b == -1?-a:a;
        if (_dic.TryGetValue(a, out var multiply))
            return multiply;
        int res = Multiply(a >> 1, b) + Multiply((a + 1) >> 1, b);
        _dic[a] = res;
        return res;
    }

    // 快速幂
    public int Multiply1(int a, int b)
    {
        int num = 0;
        if ((b & 1) == 1)
            num = a;
        if ((b & 1) == 0)
            num = 0;
        if (b == 0)
            return num;
        return Multiply1(a + a, b >> 1) + num;
    }
}