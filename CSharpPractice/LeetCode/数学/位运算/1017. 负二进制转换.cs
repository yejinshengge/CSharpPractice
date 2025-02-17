using System.Text;

namespace CSharpPractice.LeetCode.位运算;

public class LeetCode_1017 {
    public static void Test()
    {
        LeetCode_1017 obj = new LeetCode_1017();
        Console.WriteLine(obj.BaseNeg2(2));
        Console.WriteLine(obj.BaseNeg2(3));
        Console.WriteLine(obj.BaseNeg2(4));
    }

    private const int BASE = -2;
    public string BaseNeg2(int n)
    {
        if (n == 0) return "0";
        List<char> res = new();
        while (n != 0)
        {
            res.Add((char)((n & 1)+'0'));
            n = -(n >> 1);
        }

        res.Reverse();
        return new string(res.ToArray());
    }
}