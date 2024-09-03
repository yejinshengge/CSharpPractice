namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR057
{
    public static void Test()
    {
        LeetCode_LCR057 obj = new LeetCode_LCR057();
        // Console.WriteLine(obj.ContainsNearbyAlmostDuplicate(new []{1,2,3,1},3,0));
        // Console.WriteLine(obj.ContainsNearbyAlmostDuplicate(new []{1,0,1,1},1,2));
        // Console.WriteLine(obj.ContainsNearbyAlmostDuplicate(new []{1,5,9,1,5,9},2,3));
        Console.WriteLine(obj.ContainsNearbyAlmostDuplicate(new []{2,0,-2,2},2,1));
    }
    
    public bool ContainsNearbyAlmostDuplicate1(int[] nums, int k, int t)
    {
        SortedSet<long> set = new();
        for (var i = 0; i < nums.Length; i++)
        {
            if (set.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Count > 0)
                return true;

            set.Add(nums[i]);
            if (i >= k)
                set.Remove(nums[i - k]);
        }

        return false;
    }

    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
    {
        Dictionary<long, long> dic = new();
        int buketSize = t + 1;
        for (int i = 0; i < nums.Length; i++)
        {
            var id = _getId(nums[i], buketSize);
            if (dic.ContainsKey(id))
                return true;
            if (dic.ContainsKey(id - 1) && nums[i] - dic[id - 1] <= t)
                return true;
            if (dic.ContainsKey(id + 1) && dic[id + 1] - nums[i] <= t)
                return true;
            dic[id] = nums[i];
            if (i >= k)
                dic.Remove(_getId(nums[i - k], buketSize));
        }

        return false;
    }

    private long _getId(long num, long buketSize)
    {
        if (num >= 0)
            return num / buketSize;
        return (num + 1) / buketSize - 1;
    }
}