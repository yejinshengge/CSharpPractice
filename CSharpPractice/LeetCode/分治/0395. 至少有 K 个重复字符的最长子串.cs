namespace CSharpPractice.LeetCode.分治;

public class LeetCode_0395
{
    public static void Test()
    {
        LeetCode_0395 obj = new LeetCode_0395();
    }
    
    public int LongestSubstring(string s, int k) {
        int[] cnt = new int[26];

        foreach (var t in s)
            cnt[t - 'a']++;

        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // 排除不符合条件的字符
            while (i < s.Length && cnt[s[i]-'a'] < k)
            {
                i++;
            }
            // 记录符合条件的字符
            int start = i, len = 0;
            while (i < s.Length && cnt[s[i] - 'a'] >= k)
            {
                i++;
                len++;
            }
            // 如果都符合条件，直接返回
            if (len == s.Length) return s.Length;
            res = Math.Max(res, LongestSubstring(s.Substring(start, len), k));
        }

        return res;
    }
}