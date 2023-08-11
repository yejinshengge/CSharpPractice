using System.Collections;
using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
给定一个候选人编号的集合 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
candidates 中的每个数字在每个组合中只能使用 一次 。
注意：解集不能包含重复的组合。 
 */
public class LeetCode_0040
{
    public static void Test()
    {
        LeetCode_0040 obj = new LeetCode_0040();
        var res1 = obj.CombinationSum2(new[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
        //var res2 = obj.CombinationSum2(new[] {2,5,2,1,2 }, 5);
        Tools.PrintEnumerator(res1);
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        _res.Clear();
        _path.Clear();
        _valid = new bool[candidates.Length];
        Array.Sort(candidates);
        DoCombinationSum2(candidates,target,0,0);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private bool[] _valid;
    private void DoCombinationSum2(int[] candidates, int target, int index,int sum)
    {

        if (sum == target)
        {
            _res.Add(new List<int>(_path));
            return;
        }

        for (int i = index; i < candidates.Length && sum+candidates[i] <= target ; i++)
        {
            if(i > 0 && candidates[i] == candidates[i-1] &&_valid[i-1] == false)
                continue; 
            _valid[i] = true;
            _path.Add(candidates[i]);
            DoCombinationSum2(candidates,target,i+1,sum+candidates[i]);
            _path.RemoveAt(_path.Count-1);
            _valid[i] = false;
        }
    }
}