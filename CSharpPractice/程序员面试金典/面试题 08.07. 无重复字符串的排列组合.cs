using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_07
{
    public static void Test()
    {
        LeetCode_08_07 obj = new LeetCode_08_07();
        Tools.PrintArr(obj.Permutation("qwe"));
    }
    
    public string[] Permutation(string s)
    {
        _path.Clear();
        _res.Clear();
        _doPermutation(s, new bool[s.Length]);
        return _res.ToArray();
    }

    private StringBuilder _path = new StringBuilder();
    private List<string> _res = new List<string>();
    private void _doPermutation(string s,bool[] visited)
    {
        if (_path.Length == s.Length)
        {
            _res.Add(_path.ToString());
            return;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if(visited[i])
                continue;
            visited[i] = true;
            _path.Append(s[i]);
            _doPermutation(s,visited);
            visited[i] = false;
            _path.Remove(_path.Length - 1,1);
        }
    }
}