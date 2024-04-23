namespace CSharpPractice.LeetCode.哈希表篇;

/**
 * 给你一个整数数组 nums 和一个整数 k，请你在数组中找出 不同的 k-diff 数对，并返回不同的 k-diff 数对 的数目。

    k-diff 数对定义为一个整数对 (nums[i], nums[j]) ，并满足下述全部条件：

    0 <= i, j < nums.length
    i != j
    |nums[i] - nums[j]| == k
    注意，|val| 表示 val 的绝对值。
 */
public class LeetCode_0532
{
    public static void Test()
    {
        LeetCode_0532 obj = new LeetCode_0532();
        Console.WriteLine(obj.FindPairs(new []{3, 1, 4, 1, 5},2));
        Console.WriteLine(obj.FindPairs(new []{1, 2, 3, 4, 5},1));
        Console.WriteLine(obj.FindPairs(new []{1, 3, 1, 5, 4},0));
    }
    
    public int FindPairs(int[] nums, int k)
    {
        HashSet<int> visited = new HashSet<int>();
        HashSet<int> res = new HashSet<int>();
        
        foreach (var num in nums)
        {
            if (visited.Contains(num - k))
                res.Add(num - k);
            if (visited.Contains(num + k))
                res.Add(num);
            visited.Add(num);
        }

        return res.Count;
    }
}