using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

//给定两个整数 n 和 k，返回范围 [1, n] 中所有可能的 k 个数的组合。
//你可以按 任何顺序 返回答案。
public class LeetCode_0077
{
    public static void Test()
    {
        LeetCode_0077 obj = new LeetCode_0077();
        var arr = obj.Combine(1, 1);
        Tools.PrintEnumerator(arr);
    }

    private IList<IList<int>> res = new List<IList<int>>();
    private IList<int> path = new List<int>();
    public IList<IList<int>> Combine(int n, int k) {
        res.Clear();
        path.Clear();
        DoCombine(n,k,1);
        return res;
    }

    private void DoCombine(int n, int k, int index)
    {
        if (path.Count == k)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = index; i <= n-(k-path.Count)+1; i++)
        {
            path.Add(i);
            DoCombine(n,k,i+1);
            path.RemoveAt(path.Count-1);
        }
    }
}