using System.Text;

namespace CSharpPractice.LeetCode.位运算;

/**
 * 给你两个二进制字符串 a 和 b ，以二进制字符串的形式返回它们的和。
 */
public class LeetCode_0067
{
    public static void Test()
    {
        LeetCode_0067 obj = new LeetCode_0067();
        Console.WriteLine(obj.AddBinary("11","1"));
        Console.WriteLine(obj.AddBinary("1010","1011"));
    }
    
    public string AddBinary(string a, string b)
    {
        StringBuilder res = new StringBuilder();
        int ca = 0;
        for (int i = a.Length - 1, j = b.Length - 1; i >= 0 || j >= 0; i--, j-- )
        {
            int num = ca;
            num += i >= 0 ? a[i] - '0' : 0;
            num += j >= 0 ? b[j] - '0' : 0;
            res.Append(num % 2);
            ca = num / 2;
        }

        if (ca == 1)
            res.Append(ca);
        var array = res.ToString().ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
    
}