namespace CSharpPractice.LeetCode.初级算法;

/**
 * 如果在将所有大写字符转换为小写字符、并移除所有非字母数字字符之后，短语正着读和反着读都一样。则可以认为该短语是一个 回文串 。
 * 字母和数字都属于字母数字字符。
 */
public class LeetCode_016 {

    public static void LeetCode_016Main()
    {
        LeetCode_016 obj = new LeetCode_016();
        Console.WriteLine(obj.IsPalindrome2(" "));
        
    }

    private bool CheckNumAndLetter(char a)
    {
        return (a - '0' >= 0 && a - '0' <= 9) || (a >= 'a' && a <= 'z');
    }
    // 思路一:双指针
    public bool IsPalindrome(string s)
    {
        s = s.ToLower();
        int left = 0;
        int right = s.Length-1;
        bool flag = true;
        while (left < right)
        {
            while (left < s.Length && !CheckNumAndLetter(s[left]))
            {
                left++;
            }
            while (right >= 0 && !CheckNumAndLetter(s[right]))
            {
                right--;
            }

            if (left < right && s[left] != s[right])
            {
                flag = false;
                break;
            }

            left++;
            right--;
        }

        return flag;
    }

    // 思路二:正则表达式
    public bool IsPalindrome2(string s)
    {
        System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex("[^A-Za-z0-9]");
        var str = rex.Replace(s, "").ToLower();
        if (string.IsNullOrEmpty(str)) return true;
        var str2 = new string(str.Reverse().ToArray());
        return str == str2;
    }
}