namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR017
{
    public static void Test()
    {
        LeetCode_LCR017 obj = new LeetCode_LCR017();
        Console.WriteLine(obj.MinWindow("ADOBECODEBANC","ABC"));
        Console.WriteLine(obj.MinWindow("a","a"));
        Console.WriteLine(obj.MinWindow("a","aa"));
    }
    
    public string MinWindow(string s, string t)
    {
        Dictionary<char, int> dic = new();
        for (int i = 0; i < t.Length; i++)
        {
            dic.TryAdd(t[i], 0);
            dic[t[i]]++;
        }

        int count = dic.Count;
        int left = 0,right = 0;
        int minLen = int.MaxValue,minStart = 0,minEnd = 0;
        while (right < s.Length || (count==0 && right == s.Length))
        {
            if (count > 0)
            {
                if (dic.ContainsKey(s[right]))
                {
                    dic[s[right]]--;
                    if (dic[s[right]] == 0)
                        count--;
                }
                right++;
            }
            else
            {
                if (right - left< minLen)
                {
                    minLen = right - left;
                    minStart = left;
                    minEnd = right;
                }

                if (dic.ContainsKey(s[left]))
                {
                    dic[s[left]]++;
                    if (dic[s[left]] > 0)
                        count++;
                }
                left++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(minStart, minEnd - minStart);
    }
}