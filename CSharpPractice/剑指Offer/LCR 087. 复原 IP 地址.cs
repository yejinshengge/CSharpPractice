using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR087
{
    public static void Test()
    {
        LeetCode_LCR087 obj = new LeetCode_LCR087();
        Tools.PrintEnumerator(obj.RestoreIpAddresses("25525511135"));
        Tools.PrintEnumerator(obj.RestoreIpAddresses("0000"));
        Tools.PrintEnumerator(obj.RestoreIpAddresses("1111"));
        Tools.PrintEnumerator(obj.RestoreIpAddresses("010010"));
        Tools.PrintEnumerator(obj.RestoreIpAddresses("10203040"));
    }

    private IList<string> _res = new List<string>();
    private StringBuilder _path = new StringBuilder();
    public IList<string> RestoreIpAddresses(string s) {
        _res.Clear();
        _path.Clear();
        _doRestoreIpAddresses(s,0,4);
        return _res;
    }

    private void _doRestoreIpAddresses(string s, int index, int n)
    {
        if (n == 0)
        {
            if(index < s.Length) return;
            _path.Remove(_path.Length - 1, 1);
            _res.Add(_path.ToString());
            _path.Append('.');
            return;
        }

        for (int i = index; i < s.Length; i++)
        {
            var numStr = s.Substring(index,i-index+1);
            if(!int.TryParse(numStr,out var value)) break;
            if(value > 255) break;
            _path.Append(numStr);
            _path.Append('.');
            _doRestoreIpAddresses(s,i+1,n-1);
            _path.Remove(_path.Length - numStr.Length - 1, numStr.Length + 1);
            if(s[index] == '0') break;
        }
        
    }
}