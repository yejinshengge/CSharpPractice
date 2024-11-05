using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR081
{
    public static void Test()
    {
        LeetCode_LCR081 obj = new LeetCode_LCR081();
        Tools.PrintEnumerator(obj.CombinationSum(new []{2,3,6,7},7));
        Tools.PrintEnumerator(obj.CombinationSum(new []{2,3,5},8));
        Tools.PrintEnumerator(obj.CombinationSum(new []{2},1));
        Tools.PrintEnumerator(obj.CombinationSum(new []{1},1));
        Tools.PrintEnumerator(obj.CombinationSum(new []{1},2));
    }
    
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        _res.Clear();
        _path.Clear();
        _doCombinationSum(candidates,target,0,0);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private void _doCombinationSum(int[] candidates, int target,int sum,int index)
    {
        if (sum == target)
        {
            _res.Add(new List<int>(_path));
            return;
        }
        if(sum > target)
            return;

        for (int i = index; i < candidates.Length; i++)
        {
            _path.Add(candidates[i]);
            _doCombinationSum(candidates,target,sum + candidates[i],i);
            _path.RemoveAt(_path.Count-1);
        }
    }
}