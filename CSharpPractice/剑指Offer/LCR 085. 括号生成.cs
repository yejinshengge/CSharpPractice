using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR085
{
    public static void Test()
    {
        LeetCode_LCR085 obj = new LeetCode_LCR085();
        Tools.PrintEnumerator(obj.GenerateParenthesis(3));
    }
    
    public IList<string> GenerateParenthesis(int n) {
        _res.Clear();
        _builder.Clear();
        _doGenerateParenthesis(n,n);
        return _res;
    }

    private IList<string> _res = new List<string>();
    private StringBuilder _builder = new StringBuilder();
    private void _doGenerateParenthesis(int left,int right)
    {
        if (left == 0 && right == 0)
        {
            _res.Add(_builder.ToString());
            return;
        }
        // 左括号有剩余，尝试添加左括号
        if (left > 0)
        {
            _builder.Append("(");
            _doGenerateParenthesis(left-1,right);
            _builder.Remove(_builder.Length - 1, 1);
        }
        // 已添加的左括号比右括号多，尝试添加右括号
        if (left < right)
        {
            _builder.Append(")");
            _doGenerateParenthesis(left,right-1);
            _builder.Remove(_builder.Length - 1, 1);
        }
    }
}