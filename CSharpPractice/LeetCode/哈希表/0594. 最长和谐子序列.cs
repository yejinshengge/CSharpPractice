namespace CSharpPractice.LeetCode.哈希表篇;

public class LeetCode_0594
{
    public static void Test()
    {
        LeetCode_0594 obj = new LeetCode_0594();
        Console.WriteLine(obj.FindLHS(new []{1,3,2,2,5,2,3,7}));
        Console.WriteLine(obj.FindLHS(new []{1,2,3,4}));
        Console.WriteLine(obj.FindLHS(new []{1,1,1,1}));
    }
    
    public int FindLHS(int[] nums) {
        Array.Sort(nums);
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int max = 0;
        foreach (var num in nums)
        {
            dic.TryAdd(num, 0);
            dic[num]++;
        }
        foreach (var num in nums)
        {
            if (dic.ContainsKey(num - 1))
                max = Math.Max(max, dic[num] + dic[num - 1]);
        }

        return max;
    }
}