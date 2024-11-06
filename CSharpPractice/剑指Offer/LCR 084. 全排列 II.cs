using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR084
{
    public static void Test()
    {
        LeetCode_LCR084 obj = new LeetCode_LCR084();
        Tools.PrintEnumerator(obj.PermuteUnique(new []{1,1,2}));
        Tools.PrintEnumerator(obj.PermuteUnique(new []{1,2,3}));
        Tools.PrintEnumerator(obj.PermuteUnique(new []{1}));
    }
    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    public IList<IList<int>> PermuteUnique(int[] nums) {
        _res.Clear();
        _path.Clear();
        Array.Sort(nums);
        _doPermuteUnique(nums,new bool[nums.Length]);
        return _res;
    }

    private void _doPermuteUnique(int[] nums, bool[] visited)
    {
        if (_path.Count == nums.Length)
        {
            _res.Add(new List<int>(_path));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if(visited[i]) continue;
            if(i > 0 && nums[i] == nums[i-1] && !visited[i-1]) continue;
            _path.Add(nums[i]);
            visited[i] = true;
            _doPermuteUnique(nums,visited);
            visited[i] = false;
            _path.RemoveAt(_path.Count-1);
        }
    }
}