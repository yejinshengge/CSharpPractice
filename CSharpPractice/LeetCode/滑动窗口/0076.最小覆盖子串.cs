namespace CSharpPractice.LeetCode.数组篇.滑动窗口;

// 给你一个字符串 s 、一个字符串 t 。返回 s 中涵盖 t 所有字符的最小子串。
// 如果 s 中不存在涵盖 t 所有字符的子串，则返回空字符串 "" 。
// 对于 t 中重复字符，我们寻找的子字符串中该字符数量必须不少于 t 中该字符数量。
// 如果 s 中存在这样的子串，我们保证它是唯一的答案。
public class LeetCode_0076
{
    public static void Test()
    {
        LeetCode_0076 obj = new LeetCode_0076();
        Console.WriteLine(obj.MinWindow("ADOBECODEBANC","ABC"));
        Console.WriteLine(obj.MinWindow("a","a"));
        Console.WriteLine(obj.MinWindow("a","aa"));
    }

    // 滑动窗口
    public string MinWindow(string s, string t)
    {
        Dictionary<char,int> tar = new Dictionary<char,int>();
        Dictionary<char, int> ori = new Dictionary<char, int>();
        for (int i = 0; i < t.Length; i++)
        {
            ori.TryAdd(t[i], 0);
            ori[t[i]]++;
        }

        int left = 0, right = 0;
        int min = int.MaxValue;
        int minLeft = -1;
        
        while (right < s.Length)
        {
            if (ori.ContainsKey(s[right]))
            {
                tar.TryAdd(s[right], 0);
                tar[s[right]]++;
            }

            while (left <= right && Check(ori,tar))
            {
                // 记录最小子串位置
                int len = right - left+1;
                if (len < min)
                {
                    min = len;
                    minLeft = left;
                }

                if (ori.ContainsKey(s[left]))
                    tar[s[left]]--;
                left++;
            }

            right++;
        }

        return min == int.MaxValue ? "" : s.Substring(minLeft, min);
    }

    private bool Check(Dictionary<char, int> ori, Dictionary<char, int> tar)
    {
        foreach (var item in ori)
        {
            tar.TryGetValue(item.Key, out int res);
            if (res < item.Value)
                return false;
        }

        return true;
    }
}