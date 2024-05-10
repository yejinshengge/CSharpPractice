using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;
// 给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。答案可以按 任意顺序 返回。
public class LeetCode_0017
{
    public static void Test()
    {
        LeetCode_0017 obj = new LeetCode_0017();
        Tools.PrintEnumerator(obj.LetterCombinations("23"));
        Tools.PrintEnumerator(obj.LetterCombinations("2"));
        Tools.PrintEnumerator(obj.LetterCombinations(""));
    }

    #region 
        public IList<string> LetterCombinations1(string digits) {
            _path.Clear();
            _builder.Clear();
            DoLetterCombinations(digits,0);
            return _path;
        }

        private IList<string> _path = new List<string>();
        private StringBuilder _builder = new StringBuilder();

        private void DoLetterCombinations(string digits,int index)
        {
            if (_builder.Length == digits.Length)
            {
                if(_builder.Length > 0)
                    _path.Add(_builder.ToString());
                return;
            }

            string tmp = "";
            switch (digits[index])
            {
                case '2':
                    tmp = "abc";
                    break;
                case '3':
                    tmp = "def";
                    break;
                case '4':
                    tmp = "ghi";
                    break;
                case '5':
                    tmp = "jkl";
                    break;
                case '6':
                    tmp = "mno";
                    break;
                case '7':
                    tmp = "pqrs";
                    break;
                case '8':
                    tmp = "tuv";
                    break;
                case '9':
                    tmp = "wxyz";
                    break;
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                _builder.Append(tmp[i]);
                DoLetterCombinations(digits,index+1);
                _builder.Remove(_builder.Length - 1, 1);
            }
        }
    
    #endregion
    
    public IList<string> LetterCombinations(string digits)
    {
        _res.Clear();
        _word.Clear();
        if (digits.Length == 0) return _res;
        string[] strArr = { "","","abc","def","ghi","jkl","mno","pqrs","tuv","wxyz" };
        _doLetterCombinations(strArr, digits, 0);
        return _res;
    }

    private List<string> _res = new List<string>();
    private StringBuilder _word = new StringBuilder();
    private void _doLetterCombinations(string[] strArr, string digits, int index)
    {
        if (_word.Length == digits.Length)
        {
            _res.Add(_word.ToString());
            return;
        }

        int num = digits[index] - '0';
        foreach (var c in strArr[num])
        {
            _word.Append(c);
            _doLetterCombinations(strArr, digits, index + 1);
            _word.Remove(_word.Length - 1, 1);
        }
    }
}