using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR079
{
    public static void Test()
    {
        LeetCode_LCR079 obj = new LeetCode_LCR079();
        Tools.PrintEnumerator(obj.Subsets(new []{1,2,3}));
    }
    
    public IList<IList<int>> Subsets(int[] nums)
    {
        _res.Clear();
        _path.Clear();
        _doSubsets(nums, 0);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private void _doSubsets(int[] nums,int index)
    {
        _res.Add(new List<int>(_path));
        if (index == nums.Length)
        {
            return;
        }

        for (int i = index; i < nums.Length; i++)
        {
            _path.Add(nums[i]);
            _doSubsets(nums,i+1);
            _path.RemoveAt(_path.Count-1);
        }
    }
}