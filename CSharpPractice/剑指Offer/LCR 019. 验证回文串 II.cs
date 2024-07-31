namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR019
{
    public static void Test()
    {
        LeetCode_LCR019 obj = new LeetCode_LCR019();
        Console.WriteLine(obj.ValidPalindrome("aba"));
        Console.WriteLine(obj.ValidPalindrome("abca"));
        Console.WriteLine(obj.ValidPalindrome("abc"));
        Console.WriteLine(obj.ValidPalindrome("a"));
        Console.WriteLine(obj.ValidPalindrome("deeee"));
    }
    
    public bool ValidPalindrome(string s)
    {
        return _check(s, 0, s.Length - 1, true);
    }

    private bool _check(string s, int start, int end, bool flag)
    {
        while (start < end)
        {
            if (s[start] == s[end])
            {
                start++;
                end--;
            }
            else
                break;
        }

        return start >= end
               || (flag && _check(s, start + 1, end, !flag)) 
               || (flag && _check(s, start, end - 1, !flag));
    }
}