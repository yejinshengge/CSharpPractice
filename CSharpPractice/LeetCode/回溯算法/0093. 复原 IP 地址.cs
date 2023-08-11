using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
 * 给定一个只包含数字的字符串 s ，用以表示一个 IP 地址，返回所有可能的有效 IP 地址，
 * 这些地址可以通过在 s 中插入 '.' 来形成。你 不能 重新排序或删除 s 中的任何数字。
 * 你可以按 任何 顺序返回答案。
 */
public class LeetCode_0093
{
    public static void Test()
    {
        LeetCode_0093 obj = new LeetCode_0093();
        var list1 = obj.RestoreIpAddresses("0000");
        Tools.PrintEnumerator(list1);
        
    }

    public IList<string> RestoreIpAddresses(string s) {
        _res.Clear();
        _builder.Clear();
        DoRestoreIpAddresses(s,0,0);
        return _res;
    }

    private List<string> _res = new List<string>();
    private StringBuilder _builder = new StringBuilder();
    private void DoRestoreIpAddresses(string s,int startIndex,int len)
    {
        if (startIndex >= s.Length&&len == 4)
        {
            _res.Add(_builder.ToString());
            return;
        }
        
        
        for (int i = startIndex; i <= Math.Min(startIndex+2,s.Length-1) && len <4; i++)
        {
            if((s.Length - i-1)/(4-len)>3)return;
            string id = s.Substring(startIndex, i - startIndex + 1);
            if(int.Parse(id) > 255) continue;
            if(s[startIndex] == '0' && i > startIndex) return;
            string str = id;
            if (len < 3)
                str += ".";
            _builder.Append(str);
            DoRestoreIpAddresses(s,i+1,len+1);
            _builder.Remove(_builder.Length - str.Length, str.Length);

        }
    }
}