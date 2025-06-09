namespace CSharpPractice.剑指Offer;

public class LeetCode_CLR012
{
    public static void Test()
    {
        LeetCode_CLR012 obj = new LeetCode_CLR012();
        Console.WriteLine(obj.PivotIndex(new[] { 1, 7, 3, 6, 5, 6 }));
        Console.WriteLine(obj.PivotIndex(new[] { 1, 2, 3 }));
        Console.WriteLine(obj.PivotIndex(new[] { 2, 1, -1 }));
    }
    
    public int PivotIndex1(int[] nums)
    {
        // 前缀和
        int[] sum = new int[nums.Length + 1];
        for (int i = 1; i <= nums.Length; i++)
        {
            sum[i] = sum[i - 1] + nums[i - 1];
        }
        // 找到第一个左右相等的下标
        for (int i = 1; i <= nums.Length; i++)
        {
            if (sum[i - 1] == sum[nums.Length] - sum[i])
                return i-1;
        }

        return -1;
    }
    
    public int PivotIndex(int[] nums)
    {
        // 计算总和
        int total = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            total += nums[i];
        }
        // 计算左边的和与剩余的和相等
        int left = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            left += nums[i];
            if (left - nums[i] == total - left)
                return i;
        }

        return -1;
    }
}