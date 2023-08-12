using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
给你一个整数数组 nums ，数组中的元素 互不相同 。返回该数组所有可能的子集（幂集）。
解集 不能 包含重复的子集。你可以按 任意顺序 返回解集。
 */
public class LeetCode_0078
{
    public static void Test()
    {
        LeetCode_0078 obj = new LeetCode_0078();
        var list = obj.Subsets(new[] {0});
        Tools.PrintEnumerator(list);
    }

    public IList<IList<int>> Subsets(int[] nums) {
        _res.Clear();
        _path.Clear();
        DoSubsets(nums,0);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private void DoSubsets(int[] nums, int startIndex)
    {
        if (startIndex >= nums.Length)
        {
            _res.Add(new List<int>(_path));
            return;
        }

        for (int i = startIndex; i <= nums.Length; i++)
        {
            if(i < nums.Length)
                _path.Add(nums[i]);
            DoSubsets(nums,i+1);
            if(i < nums.Length)
                _path.RemoveAt(_path.Count-1);
        }
    }
}