using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_08
{
    public static void Test()
    {
        LeetCode_08_08 obj = new LeetCode_08_08();
        Tools.PrintArr(obj.Permutation("qqe"));
        Tools.PrintArr(obj.Permutation("ab"));
    }
    
    public string[] Permutation(string s)
    {
        _res.Clear();
        _path.Clear();
        var array = s.ToCharArray();
        Array.Sort(array);
        _doPermutation(array,new bool[array.Length]);
        return _res.ToArray();
    }

    private StringBuilder _path = new StringBuilder();
    private List<string> _res = new List<string>();
    private void _doPermutation(char[] arr, bool[] visited)
    {
        if (_path.Length == arr.Length)
        {
            _res.Add(_path.ToString());
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if(i > 0 && arr[i] == arr[i-1] && visited[i-1])
                continue;
            if(visited[i])
                continue;
            visited[i] = true;
            _path.Append(arr[i]);
            _doPermutation(arr,visited);
            _path.Remove(_path.Length - 1, 1);
            visited[i] = false;
        }
    }
}