namespace CSharpPractice.LeetCode.字符串;

/**
给你两个字符串haystack 和 needle ，请你在 haystack 字符串中找出 needle 
字符串的第一个匹配项的下标（下标从 0 开始）。如果needle 不是 haystack 的一部分，则返回 -1 。
 */
public class LeetCode_0028
{
    public static void Test()
    {
        LeetCode_0028 obj = new LeetCode_0028();
        Console.WriteLine(obj.StrStr("sadbutsad","sad"));
        Console.WriteLine(obj.StrStr("leetcode","leeto"));
        Console.WriteLine(obj.StrStr("a","a"));
        Console.WriteLine(obj.StrStr("a","b"));
    }

    public int StrStr(string haystack, string needle)
    {
        if (needle.Length > haystack.Length) return -1;
        
        int[] next = GetNextArr(needle);

        int p1 = 0, p2 = 0;
        while (p1 < haystack.Length && p2 < needle.Length)
        {
            if (haystack[p1] == needle[p2])
            {
                p1++;
                p2++;
            }
            else if (p2 > 0)
            {
                p2 = next[p2];
            }
            else
            {
                p1++;
            }
        }

        return p2 == needle.Length ? p1 - p2 : -1;
    }

    private int[] GetNextArr(string str)
    {
        if (str.Length == 1) return new[] { -1 };
        int[] next = new int[str.Length];
        next[0] = -1;
        next[1] = 0;

        int left = 0, right = 1;
        while (right<str.Length-1)
        {
            if (str[left] == str[right])
            {
                left++;
                right++;
                next[right] = left;
            }
            else if (left > 0)
            {
                left = next[left];
            }
            else
            {
                right++;
                next[right] = 0;
            }
            
        }

        return next;
    }
}