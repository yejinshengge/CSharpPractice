using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR015
{
    public static void Test()
    {
        LeetCode_LCR015 obj = new LeetCode_LCR015();
        Tools.PrintEnumerator(obj.FindAnagrams("cbaebabacd","abc"));
        Tools.PrintEnumerator(obj.FindAnagrams("abab","ab"));
    }
    
    public IList<int> FindAnagrams(string s, string p)
    {
        IList<int> res = new List<int>();
        int[] count = new int[26];
        for (int i = 0; i < p.Length; i++)
            count[p[i] - 'a']--;

        int left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            int x = s[right] - 'a';
            count[x]++;
            while (count[x] > 0)
            {
                count[s[left] - 'a']--;
                left++;
            }
            if(right - left + 1 == p.Length)
                res.Add(left);
        }
        return res;
    }
}