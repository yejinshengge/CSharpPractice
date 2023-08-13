using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;
// 给定一个不含重复数字的数组 nums ，返回其 所有可能的全排列 。你可以 按任意顺序 返回答案。
public class LeetCode_0046
{
    public static void Test()
    {
        LeetCode_0046 obj = new LeetCode_0046();
        var list = obj.Permute(new[] { 1 });
        Tools.PrintEnumerator(list);
        
    }
    
    public IList<IList<int>> Permute(int[] nums) {
        _res.Clear();
        _path.Clear();
        _valid = new bool[21];
        DoPermute(nums);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private bool[] _valid ;
    private void DoPermute(int[] nums)
    {
        if (_path.Count == nums.Length)
        {
            _res.Add(new List<int>(_path));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if(_valid[nums[i]+10])
                continue;
            _path.Add(nums[i]);
            _valid[nums[i] + 10] = true;
            DoPermute(nums);
            _path.RemoveAt(_path.Count-1);
            _valid[nums[i] + 10] = false;
        }
    }
}