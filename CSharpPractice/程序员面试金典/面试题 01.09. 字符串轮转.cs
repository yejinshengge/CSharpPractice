namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_09
{
    public static void Test()
    {
        LeetCode_01_09 obj = new LeetCode_01_09();
        Console.WriteLine(obj.IsFlipedString("waterbottle", "erbottlewat"));
        Console.WriteLine(obj.IsFlipedString("aa", "aba"));
        Console.WriteLine(obj.IsFlipedString("", ""));
    }

    // 常规解法
    public bool IsFlipedString1(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        var ds2 = s2 + s2;
        return ds2.Contains(s1);
    }

    // 字符串哈希
    public bool IsFlipedString2(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        int len = s1.Length;
        int[] pre = new int[len * 2+1];
        int[] power = new int[len * 2+1];
        int baseNum = 13131;
        for (int i = 1; i <= len; i++)
        {
            pre[i] = pre[i - 1] * baseNum + s2[i-1];
        }

        int s2Hash = pre[len];
        s1 = s1 + s1;
        power[0] = 1;
        for (int i = 1; i <= len * 2; i++)
        {
            pre[i] = pre[i - 1] * baseNum + s1[i-1];
            power[i] = power[i - 1] * baseNum;
        }

        int left = 0, right = len;
        while (right <= len*2)
        {
            int curHash = pre[right] - pre[left] * power[len];
            if (curHash == s2Hash) return true;
            left++;
            right++;
        }

        return false;
    }

    // kmp
    public bool IsFlipedString(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        s1 = s1 + s1;
        int[] next = new int[s1.Length+1];
        next[0] = -1;
        int left = 0, right = 1;
        while (right < s1.Length-1)
        {
            if (s1[left] == s1[right])
            {
                left++;
                right++;
                next[right] = left;
            }
            else if (left > 0)
                left = next[left];
            else
                right++;
        }

        left = right = 0;
        while (left < s1.Length && right < s2.Length)
        {
            if (s1[left] == s2[right])
            {
                left++;
                right++;
            }
            else if (right > 0)
                right = next[right];
            else
                left++;
        }

        return right == s2.Length;
    }
}