using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
给你一个整数数组 nums ，其中可能包含重复元素，请你返回该数组所有可能的子集（幂集）。
解集 不能 包含重复的子集。返回的解集中，子集可以按 任意顺序 排列。
 */
public class LeetCode_0090
{

    public static void Test()
    {
        LeetCode_0090 obj = new LeetCode_0090();
        Tools.PrintEnumerator(obj.SubsetsWithDup(new[] {1,2,2}));
        Tools.PrintEnumerator(obj.SubsetsWithDup(new[] {0 }));
    }

    #region 1st
    #if false
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        _res.Clear();
        _path.Clear();
        Array.Sort(nums);
        _valid = new bool[nums.Length];
        DoSubsetsWithDup(nums,0);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private bool[] _valid;
    private void DoSubsetsWithDup(int[] nums, int startIndex)
    {
        if (startIndex >= nums.Length)
        {
            _res.Add(new List<int>(_path));
            return;
        }
        for (int i = startIndex; i <= nums.Length; i++)
        {
            if(i > 0 && i<nums.Length && nums[i] == nums[i-1] && _valid[i-1] == false)
                continue;
            if (i < nums.Length)
            {
                _path.Add(nums[i]);
                _valid[i] = true;
            }
            DoSubsetsWithDup(nums,i+1);
            if (i < nums.Length)
            {
                _path.RemoveAt(_path.Count-1);
                _valid[i] = false;
            }
        }
    }
    #endif
    
    #endregion

    #region 2st

    #if true
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        _valid = new bool[nums.Length];
        _res.Clear();
        _path.Clear();
        Array.Sort(nums);
        _doSubsetsWithDup(nums, 0);
        return _res;
    }

    private bool[] _valid;
    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private void _doSubsetsWithDup(int[] nums, int index)
    {
        _res.Add(new List<int>(_path));
            
        for (int i = index; i < nums.Length; i++)
        {
            if(i > 0 && nums[i-1] == nums[i] && _valid[i-1] == false)
                continue;

            _path.Add(nums[i]);
            _valid[i] = true;
            
            _doSubsetsWithDup(nums,i+1);

            _valid[i] = false;
            _path.RemoveAt(_path.Count-1);
            
        }
    }
    
    #endif

    #endregion
}