using System.Collections;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
给你一个字符串 s，请你将 s 分割成一些子串，使每个子串都是 回文串 。返回 s 所有可能的分割方案。
回文串 是正着读和反着读都一样的字符串。
 */
public class LeetCode_0131
{
    public static void Test()
    {
        LeetCode_0131 obj = new LeetCode_0131();
        var res = obj.Partition("aab");
        Tools.PrintEnumerator(res);
    }

    public IList<IList<string>> Partition(string s) {
        _res.Clear();
        _path.Clear();
        DoPartition(s,0);
        return _res;
    }

    private IList<IList<string>> _res = new List<IList<string>>();
    private IList<string> _path = new List<string>();
    private void DoPartition(string s,int index)
    {
        if (index >= s.Length)
        {
            _res.Add(new List<string>(_path));
            return;
        }

        for (int i = index; i < s.Length; i++)
        {
            if (IsPalindrome(s, index, i))
            {
                string str = s.Substring(index, i - index + 1);
                _path.Add(str);
            }
            else
                continue;
            DoPartition(s,i+1);
            _path.RemoveAt(_path.Count-1);
        }
    }

    private bool IsPalindrome(string s,int start,int end)
    {
        for (int i = start,j=end; i<j; i++,j--)
        {
            if (s[i] != s[j]) return false;
        }

        return true;
    }
}