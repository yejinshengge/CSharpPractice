namespace CSharpPractice.LeetCode.动态规划;

// 给你一个 只包含正整数 的 非空 数组 nums 。请你判断是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。
public class LeetCode_0416
{
    public static void Test()
    {
        LeetCode_0416 obj = new LeetCode_0416();
        Console.WriteLine(obj.CanPartition(new []{1,5,11,5}));
        Console.WriteLine(obj.CanPartition(new []{1,2,3,5}));
    }
    
    public bool CanPartition(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        if (sum % 2 != 0) return false;
        sum /= 2;
        
        int[] dp = new int[sum+1];
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = sum; j >= nums[i]; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - nums[i]] + nums[i]);
            }
        }

        if (dp[sum] == sum) return true;
        return false;
    }
}