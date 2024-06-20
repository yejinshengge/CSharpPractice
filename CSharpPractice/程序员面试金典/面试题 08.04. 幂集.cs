using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_04
{
    public static void Test()
    {
        LeetCode_08_04 obj = new LeetCode_08_04();
        Tools.PrintEnumerator(obj.Subsets(new []{1,2,3}));
    }

    // 回溯
    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    public IList<IList<int>> Subsets1(int[] nums) {
        _res.Clear();
        _path.Clear();
        _doSubsets(nums,0);
        return _res;
    }

    private void _doSubsets(int[] nums,int start)
    {
        _res.Add(new List<int>(_path));

        for (int i = start; i < nums.Length; i++)
        {
            _path.Add(nums[i]);
            _doSubsets(nums,i+1);
            _path.RemoveAt(_path.Count-1);
        }
    }

    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        res.Add(new List<int>());
        
        foreach (var num in nums)
        {
            int count = res.Count;
            for (int i = 0; i < count; i++)
            {
                var list = new List<int>(res[i]);
                list.Add(num);
                res.Add(list);
            }
        }

        return res;
    }
}