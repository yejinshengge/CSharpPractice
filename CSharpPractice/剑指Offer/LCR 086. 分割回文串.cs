using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR086
{
    public static void Test()
    {
        LeetCode_LCR086 obj = new LeetCode_LCR086();
        Tools.PrintArr(obj.Partition("google"));
    }
    
    public string[][] Partition(string s)
    {
        _path.Clear();
        _res.Clear();
        bool[,] dp = new bool[s.Length, s.Length];
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                dp[i, j] = true;
            }
        }
        for (int i = s.Length-1; i >= 0; i--)
        {
            for (int j = i+1; j < s.Length; j++)
            {
                dp[i, j] = s[i] == s[j] && dp[i + 1, j - 1];
            }
        }
        _doPartition(dp,s,0);
        string[][] res = new string[_res.Count][];
        for (var i = 0; i < _res.Count; i++)
        {
            var list = _res[i];
            res[i] = list.ToArray();
        }

        return res;
    }

    private List<string> _path = new List<string>();
    private List<List<string>> _res = new List<List<string>>();
    private void _doPartition(bool[,] dp,string s,int index)
    {
        if (index == s.Length)
        {
            _res.Add(new List<string>(_path));
            return;
        }

        for (int i = index; i < s.Length; i++)
        {
            if(!dp[index,i])continue;
            _path.Add(s.Substring(index,i-index+1));
            _doPartition(dp,s,i+1);
            _path.RemoveAt(_path.Count - 1);
        }
    }
}