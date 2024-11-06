using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR083
{
    public static void Test()
    {
        LeetCode_LCR083 obj = new LeetCode_LCR083();
        Tools.PrintEnumerator(obj.Permute(new []{1,2,3}));
        Tools.PrintEnumerator(obj.Permute(new []{0,1}));
        Tools.PrintEnumerator(obj.Permute(new []{1}));
    }
    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    public IList<IList<int>> Permute(int[] nums) {
        _res.Clear();
        _path.Clear();
        _doPermute(nums,new bool[nums.Length]);
        return _res;
    }

    private void _doPermute(int[] nums,bool[] visited)
    {
        if (_path.Count == nums.Length)
        {
            _res.Add(new List<int>(_path));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if(visited[i]) continue;
            _path.Add(nums[i]);
            visited[i] = true;
            _doPermute(nums,visited);
            _path.RemoveAt(_path.Count-1);
            visited[i] = false;
        }
    }
}