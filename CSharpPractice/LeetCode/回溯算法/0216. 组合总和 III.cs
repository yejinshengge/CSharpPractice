using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
找出所有相加之和为 n 的 k 个数的组合，且满足下列条件：
只使用数字1到9
每个数字 最多使用一次 
返回 所有可能的有效组合的列表 。该列表不能包含相同的组合两次，组合可以以任何顺序返回。
 */
public class LeetCode_0216
{
    public static void Test()
    {
        LeetCode_0216 obj = new LeetCode_0216();
        var list1 = obj.CombinationSum3(3, 7);
        Tools.PrintEnumerator(list1);
        
        var list2 = obj.CombinationSum3(3, 9);
        Tools.PrintEnumerator(list2);
    }

    private IList<IList<int>> res = new List<IList<int>>();
    private IList<int> path = new List<int>();
    
    public IList<IList<int>> CombinationSum3(int k, int n) {
        res.Clear();
        path.Clear();
        DoCombinationSum3(k,n,0,1);
        return res;
    }

    private void DoCombinationSum3(int k, int n, int sum,int startIndex)
    {
        if(sum > n) return;
        if (path.Count == k)
        {
            if(sum == n)
                res.Add(new List<int>(path));
            return;
        }

        for (int i = startIndex; i <= 9 - (k-path.Count)+1; i++)
        {
            path.Add(i);
            DoCombinationSum3(k,n,sum+i,i+1);
            path.RemoveAt(path.Count-1);
        }
    }
}