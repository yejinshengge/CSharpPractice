using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.字符串;

/**
给定一个字符串 s 和一个字符串数组 words。 words 中所有字符串 长度相同。

 s 中的 串联子串 是指一个包含  words 中所有字符串以任意顺序排列连接起来的子串。

例如，如果 words = ["ab","cd","ef"]， 那么 "abcdef"， "abefcd"，"cdabef"， "cdefab"，"efabcd"， 
和 "efcdab" 都是串联子串。 "acdbef" 不是串联子串，因为他不是任何 words 排列的连接。
返回所有串联子串在 s 中的开始索引。你可以以 任意顺序 返回答案。
 */
public class LeetCode_0030
{
    public static void Test()
    {
        LeetCode_0030 obj = new LeetCode_0030();
        Tools.PrintEnumerator(obj.FindSubstring2("barfoothefoobarman", new[] { "foo", "bar" }));
        Tools.PrintEnumerator(obj.FindSubstring2("wordgoodgoodgoodbestword", new[] { "word","good","best","word" }));
        Tools.PrintEnumerator(obj.FindSubstring2("barfoofoobarthefoobarman", new[] { "bar","foo","the" }));
        Tools.PrintEnumerator(obj.FindSubstring2("wordgoodgoodgoodbestword", new[] { "word","good","best","good" }));
        Tools.PrintEnumerator(obj.FindSubstring2("foobarfoobar", new[] { "foo","bar" }));
        Tools.PrintEnumerator(obj.FindSubstring2("aaa", new[] { "a","a" }));
        Tools.PrintEnumerator(obj.FindSubstring2("a", new[] { "a" }));
    }

    #region KMP+回溯（超时）
    
    public IList<int> FindSubstring(string s, string[] words)
    {
        valid = new bool[words.Length];
        _path.Clear();
        _strs.Clear();
        List<int> res = new List<int>();
        Array.Sort(words);
        _combineStr(words);
        for (int i = 0; i < _strs.Count; i++)
        {
            var indexList = _kmp(s, _strs[i]);
            if(indexList.Count>0)
                res.AddRange(indexList);
        }
        return res;
    }

    private List<string> _path = new List<string>();
    private List<string> _strs = new List<string>();
    private bool[] valid;
    private void _combineStr(string[] words)
    {
        if (_path.Count == words.Length)
        {
            _strs.Add(string.Concat(_path));
            return;
        }
        
        for (int i = 0; i < words.Length; i++)
        {
            if(valid[i]) continue;
            if(i>0 && words[i] == words[i-1] && !valid[i-1]) continue;
            valid[i] = true;
            _path.Add(words[i]);
            _combineStr(words);
            _path.RemoveAt(_path.Count-1);
            valid[i] = false;
        }
    }

    private List<int> _kmp(string m,string n)
    {
        List<int> res = new List<int>();
        int[] next = _getNextArr(n);
        int p1 = 0, p2 = 0;
        while (p1 < m.Length)
        {
            if (m[p1] == n[p2])
            {
                p1++;
                p2++;
            }
            else if (p2 > 0)
            {
                p2 = next[p2];
            }
            else
            {
                p1++;
            }

            if (p2 == n.Length)
            {
                res.Add(p1 - p2);
                if (p1 < m.Length)
                {
                    p2 = next[p2-1];
                    p1--;
                }
            }
        }

        return res;
    }

    private int[] _getNextArr(string n)
    {
        int[] next = new int[n.Length];
        if (n.Length == 0) return next;
        next[0] = -1;
        if (n.Length == 1) return next;
        next[1] = 0;
        int left = 0, right = 1;
        
        while (right < n.Length-1)
        {
            if (n[left] == n[right])
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
                next[right] = 0;
            }
        }

        return next;
    }
    #endregion

    #region 滑动窗口

    public IList<int> FindSubstring2(string s, string[] words)
    {
        List<int> res = new List<int>();
        int sLen = s.Length;
        int arrLen = words.Length;
        int wordLen = words[0].Length;

        for (int i = 0; i <wordLen; i++)
        {
            if(i + arrLen*wordLen > sLen) break;
            Dictionary<string,int> dic = new Dictionary<string, int>();
            for (int j = 0; j < arrLen; j++)
            {
                var str = s.Substring(i+j*wordLen, wordLen);
                dic.TryAdd(str, 0);
                dic[str]++;
            }

            for (int j = 0; j < arrLen; j++)
            {
                var str = words[j];
                dic.TryAdd(str, 0);
                dic[str]--;
                if (dic[str] == 0)
                    dic.Remove(str);
            }

            for (int j = i; j <= sLen-arrLen*wordLen; j+= wordLen)
            {
                if (j != i)
                {
                    var dropStr = s.Substring(j - wordLen, wordLen);
                    dic.TryAdd(dropStr, 0);
                    dic[dropStr]--;
                    if (dic[dropStr] == 0)
                        dic.Remove(dropStr);
                    
                    var addStr = s.Substring(j + (arrLen-1)*wordLen, wordLen);
                    dic.TryAdd(addStr, 0);
                    dic[addStr]++;
                    if (dic[addStr] == 0)
                        dic.Remove(addStr);
                }
                if (dic.Count == 0)
                {
                    res.Add(j);
                }
            }
        }

        return res;
    }

    #endregion
}