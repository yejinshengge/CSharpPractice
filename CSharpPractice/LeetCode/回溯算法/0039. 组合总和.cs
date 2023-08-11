using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
给你一个 无重复元素 的整数数组 candidates 和一个目标整数 target ，找出 candidates 
中可以使数字和为目标数 target 的 所有 不同组合 ，并以列表形式返回。你可以按 任意顺序 返回这些组合。
candidates 中的 同一个 数字可以 无限制重复被选取 。如果至少一个数字的被选数量不同，则两种组合是不同的。 

对于给定的输入，保证和为 target 的不同组合数少于 150 个。
 */
public class LeetCode_0039
{
    public static void Test()
    {
        LeetCode_0039 obj = new LeetCode_0039();
        var list = obj.CombinationSum(new[] { 2 }, 1);
        Tools.PrintEnumerator(list);
    }
    
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        _res.Clear();
        _path.Clear();
        DoCombinationSum(candidates,target,0,0);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private void DoCombinationSum(int[] candidates, int target,int sum,int index)
    {
        if (sum >= target)
        {
            if (sum == target)
            {
                var newList = new List<int>(_path);
                _res.Add(newList);
            }
            return;
        }

        for (int i = index; i < candidates.Length; i++)
        {
            _path.Add(candidates[i]);
            DoCombinationSum(candidates,target,sum+candidates[i],i);
            _path.RemoveAt(_path.Count-1);
        }
        
    }
    
}