namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR119
{
    public static void Test()
    {
        LeetCode_LCR119 obj = new LeetCode_LCR119();
        Console.WriteLine(obj.LongestConsecutive(new []{100,4,200,1,3,2}));
        Console.WriteLine(obj.LongestConsecutive(new []{0,3,7,2,5,8,4,6,0,1}));
        Console.WriteLine(obj.LongestConsecutive(Array.Empty<int>()));
        Console.WriteLine(obj.LongestConsecutive(new []{1}));
    }
    
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> all = new();
        Dictionary<int, int> fathers = new();
        Dictionary<int, int> count = new();
        
        foreach (var num in nums)
        {
            all.Add(num);
            fathers.TryAdd(num,num);
            count.TryAdd(num,1);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if(all.Contains(nums[i]-1))
                _union(fathers,count,nums[i],nums[i]-1);
            if(all.Contains(nums[i]+1))
                _union(fathers,count,nums[i],nums[i]+1);
        }

        int maxLen = 0;
        foreach (var (key, value) in count)
        {
            maxLen = Math.Max(value, maxLen);
        }

        return maxLen;
    }

    private void _union(Dictionary<int, int> fathers,Dictionary<int,int> count, int num1,int num2)
    {
        var root1 = _getFather(fathers, num1);
        var root2 = _getFather(fathers, num2);
        if (root1 != root2)
        {
            fathers[root1] = root2;
            count[root2] += count[root1];
        }
    }

    private int _getFather(Dictionary<int, int> fathers, int i)
    {
        if (fathers[i] != i)
            fathers[i] = _getFather(fathers, fathers[i]);
        return fathers[i];
    }
}