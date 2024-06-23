using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_09
{
    public static void Test()
    {
        LeetCode_08_09 obj = new LeetCode_08_09();
        Tools.PrintEnumerator(obj.GenerateParenthesis(3));
        Tools.PrintEnumerator(obj.GenerateParenthesis(0));
    }
    
    private StringBuilder _path = new StringBuilder();
    private List<string> _res = new List<string>();
    // 全排列。超时
    public IList<string> GenerateParenthesis1(int n)
    {
        _res.Clear();
        _path.Clear();
        char[] arr = new char[n * 2];
        for (int i = 0; i < n; i++)
        {
            arr[i] = '(';
            arr[i + n] = ')';
        }
        _doGenerateParenthesis1(arr,new bool[2*n],0,0);
        return _res;
    }
    private void _doGenerateParenthesis1(char[] arr,bool[] visited,int left,int right)
    {
        if (_path.Length == arr.Length)
        {
            _res.Add(_path.ToString());
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if(i > 0 && visited[i-1] && arr[i] == arr[i-1])
                continue;
            if(visited[i])
                continue;
            int tmpLeft = left;
            int tmpRight = right;
            if (arr[i] == '(')
                tmpLeft = left+1;
            else
                tmpRight = right+1;
            if(tmpRight > tmpLeft)
                continue;

            visited[i] = true;
            _path.Append(arr[i]);
            _doGenerateParenthesis1(arr,visited,tmpLeft,tmpRight);
            _path.Remove(_path.Length - 1, 1);
            visited[i] = false;
        }
    }
    
    // 优化
    public IList<string> GenerateParenthesis(int n)
    {
        _res.Clear();
        _path.Clear();
        _doGenerateParenthesis(n,n);
        return _res;
    }

    private void _doGenerateParenthesis(int left, int right)
    {
        if (left == 0 && right == 0)
        {
            _res.Add(_path.ToString());
            return;
        }
        
        if(right < left)
            return;
        if (left > 0)
        {
            _path.Append('(');
            _doGenerateParenthesis(left-1,right);
            _path.Remove(_path.Length - 1, 1);
        }

        if (right > 0)
        {
            _path.Append(')');
            _doGenerateParenthesis(left,right-1);
            _path.Remove(_path.Length - 1, 1);
        }
    }
}