using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
给你一个整数数组 nums ，找出并返回所有该数组中不同的递增子序列，递增子序列中 至少有两个元素 。你可以按 任意顺序 返回答案。
数组中可能含有重复元素，如出现两个整数相等，也可以视作递增序列的一种特殊情况。
 */
public class LeetCode_0491
{
    public static void Test()
    {
        LeetCode_0491 obj = new LeetCode_0491();
        var list = obj.FindSubsequences(new[] { 4,4,3,2,1 });
        Tools.PrintEnumerator(list);
    }

    public IList<IList<int>> FindSubsequences(int[] nums) {
        _res.Clear();
        _path.Clear();
        DoFindSubsequences(nums,0);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private void DoFindSubsequences(int[] nums, int startIndex)
    {
        if(_path.Count >= 2)
            _res.Add(new List<int>(_path));
        bool[] valid = new bool[201];
        for (int i = startIndex; i < nums.Length; i++)
        {
            if((_path.Count > 0 && nums[i] < _path[^1]) || valid[nums[i]+100])
                continue;
            _path.Add(nums[i]);
            valid[nums[i]+100] = true;
            DoFindSubsequences(nums,i+1);
            _path.RemoveAt(_path.Count-1);
        }
    }
}