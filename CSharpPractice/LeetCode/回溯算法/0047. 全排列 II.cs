using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

// 给定一个可包含重复数字的序列 nums ，按任意顺序 返回所有不重复的全排列。
public class LeetCode_0047
{
    public static void Test()
    {
        LeetCode_0047 obj = new LeetCode_0047();
        var list = obj.PermuteUnique(new[] { 1,1,2 });
        Tools.PrintEnumerator(list);
    }

    public IList<IList<int>> PermuteUnique(int[] nums) {
        _res.Clear();
        _path.Clear();
        _valid = new bool[nums.Length];
        Array.Sort(nums);
        DoPermuteUnique(nums);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private bool[] _valid;
    private void DoPermuteUnique(int[] nums)
    {
        if (_path.Count == nums.Length)
        {
            _res.Add(new List<int>(_path));
            return;
        }
        
        for (int i = 0; i < nums.Length; i++)
        {
            if(i > 0 && nums[i] == nums[i-1] && _valid[i-1] == false)
                continue;
            if (!_valid[i])
            {
                _valid[i] = true;
                _path.Add(nums[i]);
                DoPermuteUnique(nums);
                _path.RemoveAt(_path.Count-1);
                _valid[i] = false;
            }
        }
    }
}