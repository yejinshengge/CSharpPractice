namespace CSharpPractice.LeetCode.数组篇.前缀和;

public class LeetCode_560
{
    public static void Test()
    {
        LeetCode_560 obj = new LeetCode_560();
        Console.WriteLine(obj.SubarraySum(new []{1,1,1},2));
        Console.WriteLine(obj.SubarraySum(new []{1,2,3},3));
    }
    
    public int SubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> dic = new(){[0] = 1};
        int res = 0;
        int prefixSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum += nums[i];
            if (dic.ContainsKey(prefixSum - k))
                res += dic[prefixSum - k];
            dic.TryAdd(prefixSum, 0);
            dic[prefixSum]++;
        }

        return res;
    }
}