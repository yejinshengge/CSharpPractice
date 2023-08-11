namespace CSharpPractice.LeetCode.字符串;

// 给定一个非空的字符串 s ，检查是否可以通过由它的一个子串重复多次构成。
public class LeetCode_0459
{
    public static void Test()
    {
        LeetCode_0459 obj = new LeetCode_0459();
        Console.WriteLine(obj.RepeatedSubstringPattern("abab"));
        Console.WriteLine(obj.RepeatedSubstringPattern("abcabcabcabc"));
        Console.WriteLine(obj.RepeatedSubstringPattern("aba"));
        Console.WriteLine(obj.RepeatedSubstringPattern("abac"));
    }

    public bool RepeatedSubstringPattern(string s)
    {
        if (s.Length == 1) return false;
        var nextArr = GetNextArr(s);
        if (nextArr[s.Length] != 0 && 
            s.Length % (s.Length - nextArr[s.Length]) == 0)
            return true;
        return false;
    }

    private int[] GetNextArr(string str)
    {
        int[] next = new int[str.Length+1];
        next[0] = -1;
        next[1] = 0;

        int left = 0, right = 1;
        while (right < str.Length)
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
            }
        }

        return next;
    }
}