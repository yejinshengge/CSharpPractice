namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR010
{
    public static void Test()
    {
        LeetCode_LCR010 obj = new LeetCode_LCR010();
        Console.WriteLine(obj.SubarraySum(new []{1,1,1},2));
        Console.WriteLine(obj.SubarraySum(new []{1,2,3},3));
    }
    
    public int SubarraySum1(int[] nums, int k)
    {
        // 计算前缀和
        int[] sum = new int[nums.Length + 1];
        for (int i = 1; i <= nums.Length; i++)
        {
            sum[i] = sum[i - 1] + nums[i - 1];
        }
        // 利用前缀和计算子数组的和
        int res = 0;
        for (int i = 0; i < sum.Length; i++)
        {
            for (int j = i+1; j < sum.Length; j++)
            {
                if (sum[j] - sum[i] == k)
                    res++;
            }
        }

        return res;
    }

    public int SubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        dic[0] = 1;
        // sum相当于记录前缀和
        int sum = 0;
        int count = 0;
        foreach (var num in nums)
        {
            sum += num;
            // 如果存在sum-k,则说明存在子数组和为k
            dic.TryGetValue(sum - k, out var cnt);
            count += cnt;
            // 记录和为sum的子数组个数
            dic.TryAdd(sum, 0);
            dic[sum]++;
        }

        return count;
    }
}