namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR018
{
    public static void Test()
    {
        LeetCode_LCR018 obj = new LeetCode_LCR018();
        Console.WriteLine(obj.IsPalindrome("A man, a plan, a canal: Panama"));
        Console.WriteLine(obj.IsPalindrome("race a car"));
        Console.WriteLine(obj.IsPalindrome("a"));
        Console.WriteLine(obj.IsPalindrome(",!"));
    }
    
    public bool IsPalindrome(string s)
    {
        s = s.Trim().ToLower();
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (!_check(s[left]))
                left++;
            else if (!_check(s[right]))
                right--;
            else if (s[left] != s[right])
                return false;
            else
            {
                left++;
                right--;
            }
        }

        return true;
    }

    private bool _check(char s)
    {
        return (s >= 'a' && s <= 'z') 
               || (s >= '0' && s <= '9');
    }
}