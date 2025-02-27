using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR082
{
    public static void Test()
    {
        LeetCode_LCR082 obj = new LeetCode_LCR082();
        Tools.PrintEnumerator(obj.CombinationSum2(new []{10,1,2,7,6,1,5},8));
        Tools.PrintEnumerator(obj.CombinationSum2(new []{2,5,2,1,2},5));
        Tools.PrintEnumerator(obj.CombinationSum2(new []{2},5));
    }
    
    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        _res.Clear();
        _path.Clear();
        Array.Sort(candidates);
        _doCombinationSum2(candidates,new bool[candidates.Length],target,0,0);
        return _res;
    }

    private void _doCombinationSum2(int[] candidates,bool[] visited, int target,int sum,int index)
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
            var a = sum + candidates[i];
            //  已经超过target，后面不需要再看
            if(a > target) break;
            // 连续相同的数字，第一个未选中，后面一定会出现重复，所以全都排除
            if(i > 0 && candidates[i] == candidates[i-1] && !visited[i-1])
                continue;
            _path.Add(candidates[i]);
            visited[i] = true;
            _doCombinationSum2(candidates,visited,target,a,i+1);
            visited[i] = false;
            _path.RemoveAt(_path.Count-1);
        }
    }
}