using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针;

/**
 * 给定两个字符串 s 和 p，找到 s 中所有 p 的 异位词 的子串，
 * 返回这些子串的起始索引。不考虑答案输出的顺序。
 * 异位词 指由相同字母重排列形成的字符串（包括相同的字符串）。
 */
public class LeetCode_0438
{
    public static void Test()
    {
        LeetCode_0438 obj = new LeetCode_0438();
        Tools.PrintEnumerator(obj.FindAnagrams("cbaebabacd","abc"));
        Tools.PrintEnumerator(obj.FindAnagrams("abab","ab"));
    }
    
    public IList<int> FindAnagrams(string s, string p)
    {
        int[] freq = new int[26];
        int total = 0;
        List<int> res = new List<int>();
        foreach (var c in p)
        {
            if (freq[c - 'a'] == 0)
                total++;
            freq[c - 'a']++;
        }
        
        for (int right = 0,left = 0; right < s.Length; right++)
        {
            freq[s[right] - 'a']--;
            if (freq[s[right] - 'a'] == 0)
                total--;
            // 长度超了，缩小窗口
            if (right - left + 1 > p.Length)
            {
                freq[s[left] - 'a']++;
                if (freq[s[left] - 'a'] == 1)
                    total++;
                left++;
            }
            if(total == 0)
                res.Add(left);
        }

        return res;
    }
}