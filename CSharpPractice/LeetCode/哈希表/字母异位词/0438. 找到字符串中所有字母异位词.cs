using System.Text;

namespace CSharpPractice.LeetCode.哈希表篇;

/**
给定两个字符串s和 p，找到s中所有p的异位词的子串，返回这些子串的起始索引。不考虑答案输出的顺序。
异位词 指由相同字母重排列形成的字符串（包括相同的字符串）。
 */
public class LeetCode_0438
{
    public static void Test()
    {
        LeetCode_0438 obj = new LeetCode_0438();
        var res1 = obj.FindAnagrams2("cbaebabacd", "abc");
        var res2 = obj.FindAnagrams2("abab", "ab");
        var res3 = obj.FindAnagrams2("a", "b");
    }
    
    public IList<int> FindAnagrams(string s, string p)
    {
        IList<int> res = new List<int>();
        int[] dic = new int[26];
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < p.Length; i++)
        {
            dic[p[i] - 'a']++;
        }

        for (int i = 0; i < dic.Length; i++)
        {
            if (dic[i] > 0)
            {
                builder.Append((char)(i + 'a'));
                builder.Append(dic[i]);
                dic[i] = 0;
            }
        }

        string pKey = builder.ToString();
        builder.Clear();
        int left = 0;
        int right = p.Length - 1;

        while (right < s.Length)
        {
            for (int i = left; i <= right; i++)
            {
                dic[s[i] - 'a']++;
            }
            for (int i = 0; i < dic.Length; i++)
            {
                if (dic[i] > 0)
                {
                    builder.Append((char)(i + 'a'));
                    builder.Append(dic[i]);
                    dic[i] = 0;
                }
            }

            string sKey = builder.ToString();
            builder.Clear();
            if(sKey == pKey)
                res.Add(left);
            left++;
            right++;
        }

        return res;
    }
    
    // 思路二：可变滑动窗口
    public IList<int> FindAnagrams2(string s, string p)
    {
        int[] dic = new int[26];
        IList<int> res = new List<int>();
        for (int i = 0; i < p.Length; i++)
        {
            dic[p[i] - 'a']++;
        }

        int left = 0;
        int right = 0;

        while (right < s.Length)
        {
            int rightIndex = s[right] - 'a';
            if (dic[rightIndex] > 0)
            {
                dic[rightIndex]--;
                right++;
                if(right - left == p.Length) res.Add(left);
            }
            else
            {
                dic[s[left] - 'a']++;
                left++;
            }
        }

        return res;
    }
}