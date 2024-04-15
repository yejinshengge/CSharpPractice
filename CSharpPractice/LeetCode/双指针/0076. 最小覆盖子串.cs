namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个字符串 s 、一个字符串 t 。返回 s 中涵盖 t 所有字符的最小子串。
 * 如果 s 中不存在涵盖 t 所有字符的子串，则返回空字符串 "" 。
 */
public class LeetCode_0076
{
    public static void Test()
    {
        LeetCode_0076 obj = new LeetCode_0076();
        Console.WriteLine(obj.MinWindow("ADOBECODEBANC","ABC"));
        Console.WriteLine(obj.MinWindow("a","a"));
        Console.WriteLine(obj.MinWindow("a","aa"));
    }
    
    public string MinWindow(string s, string t)
    {
        Dictionary<char, int> tDic = new Dictionary<char, int>();
        Dictionary<char, int> winDic = new Dictionary<char, int>();
        int totalKind = 0;
        foreach (var c in t)
        {
            if (tDic.TryAdd(c, 0))
            {
                totalKind++;
            }
            tDic[c]++;
        }

        string res = string.Empty;
        int left = 0, right = 0;
        while (right < s.Length)
        {
            var rightChar = s[right];
            // 新加入窗口的字符
            winDic.TryAdd(rightChar, 0);
            winDic[rightChar]++;
            if (tDic.ContainsKey(rightChar) && 
                winDic[rightChar] == tDic[rightChar]) 
                totalKind--;
            // 排除无用的左侧字符
            while (left < right)
            {
                var leftChar = s[left];
                if (!tDic.ContainsKey(leftChar) 
                    || winDic[leftChar] - 1 >= tDic[leftChar])
                {
                    winDic[leftChar]--;
                    left++;
                }
                else break;
            }
            // 更新结果
            if (totalKind == 0 && (res.Length == 0 || res.Length > right - left + 1))
                res = s.Substring(left, right - left + 1);
            right++;
        }

        return res;
    }
}