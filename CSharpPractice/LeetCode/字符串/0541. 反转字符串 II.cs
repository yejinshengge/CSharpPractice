namespace CSharpPractice.LeetCode.字符串;
/**
给定一个字符串 s 和一个整数 k，从字符串开头算起，每计数至 2k 个字符，就反转这 2k 字符中的前 k 个字符。
如果剩余字符少于 k 个，则将剩余字符全部反转。
如果剩余字符小于 2k 但大于或等于 k 个，则反转前 k 个字符，其余字符保持原样。

 */
public class LeetCode_0541
{
    public static void Test()
    {
        LeetCode_0541 obj = new LeetCode_0541();
        Console.WriteLine(obj.ReverseStr("abcdefg",2));
        Console.WriteLine(obj.ReverseStr("abcd",2));
        Console.WriteLine(obj.ReverseStr("a",2));
        Console.WriteLine(obj.ReverseStr("ab",3));
        Console.WriteLine(obj.ReverseStr("abc",3));
    }

    public string ReverseStr(string s, int k)
    {

        int last = 0;
        int cur = 2*k;
        var charArray = s.ToCharArray();
        while (cur <= s.Length)
        {
            Reverse(charArray,last,cur-k-1);
            last = cur;
            cur += 2 * k;
        }

        if (last < s.Length)
        {
            Reverse(charArray,last,(last+k<s.Length?last+k:s.Length)-1);
        }

        return new string(charArray);
    }

    private void Reverse(char[] s,int left,int right)
    {
        while (left<right)
        {
            (s[left], s[right]) = (s[right], s[left]);
            left++;
            right--;
        }
    }
}