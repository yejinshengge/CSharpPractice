using System.Text;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_06
{
    public static void Test()
    {
        LeetCode_01_06 obj = new LeetCode_01_06();
        Console.WriteLine(obj.CompressString("aabcccccaaa"));
        Console.WriteLine(obj.CompressString("abbccd"));
        Console.WriteLine(obj.CompressString(""));
    }
    
    public string CompressString(string s)
    {
        if (s.Length <= 1) return s;
        StringBuilder sb = new StringBuilder();
        int left = 0, right = 1;
        while (left < s.Length)
        {
            if(right >= s.Length || s[left] != s[right])
            {
                sb.Append(s[left]);
                sb.Append(right - left);
                left = right;
                right++;
            }
            else if (s[left] == s[right])
            {
                right++;
            }
        }
        
        return s.Length <= sb.Length ? s : sb.ToString();
    }
}