namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个字符串 s ，仅反转字符串中的所有元音字母，并返回结果字符串。

    元音字母包括 'a'、'e'、'i'、'o'、'u'，且可能以大小写两种形式出现不止一次。
 */
public class LeetCode_0345
{
    public static void Test()
    {
        LeetCode_0345 obj = new LeetCode_0345();
        Console.WriteLine(obj.ReverseVowels("hello"));
        Console.WriteLine(obj.ReverseVowels("leetcode"));
        Console.WriteLine(obj.ReverseVowels("a"));
    }
    
    public string ReverseVowels(string s)
    {
        int left = 0, right = s.Length - 1;
        var charArray = s.ToCharArray();
        while (left < right)
        {
            if (!_check(charArray[left]))
            {
                left++;
            }
            else if (!_check(charArray[right]))
            {
                right--;
            }
            else
            {
                (charArray[left], charArray[right]) = (charArray[right], charArray[left]);
                left++;
                right--;
            }
        }

        return new string(charArray);
    }

    private bool _check(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' 
               || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
    }
}