using System.Text;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR020
{
    public static void Test()
    {
        LeetCode_LCR020 obj = new LeetCode_LCR020();
        Console.WriteLine(obj.CountSubstrings("abc"));
        Console.WriteLine(obj.CountSubstrings("aaa"));
    }
    
    public int CountSubstrings1(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            count += _palindrome(s, i, i);
            count += _palindrome(s, i, i+1);
        }

        return count;
    }

    private int _palindrome(string s, int start, int end)
    {
        int count = 0;
        while (start >= 0 && end < s.Length && s[start] == s[end])
        {
            count++;
            start--;
            end++;
        }

        return count;
    }

    public int CountSubstrings(string s)
    {
        StringBuilder sb = new StringBuilder();
        // 添加边界字符避免边界检查
        sb.Append("&");
        sb.Append("#");
        foreach (var c in s)
        {
            sb.Append(c);
            sb.Append("#");
        }
        sb.Append("%");
        
        int maxR = 0, maxIndex = 0;
        int[] f = new int[sb.Length-1];
        int res = 0;
        for (int i = 1; i < sb.Length-1; i++)
        {
            f[i] = i > maxR ? 1 : Math.Min(maxR - i + 1, f[2 * maxIndex - i]);
            while (sb[i + f[i]] == sb[i - f[i]])
            {
                f[i]++;
            }

            if (i + f[i] - 1 > maxR)
            {
                maxIndex = i;
                maxR = i + f[i] - 1;
            }

            res += f[i] / 2;
        }

        return res;
    }
}