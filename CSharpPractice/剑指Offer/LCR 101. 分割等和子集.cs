namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR101
{
    public static void Test()
    {
        LeetCode_LCR101 obj = new LeetCode_LCR101();
        Console.WriteLine(obj.CanPartition(new []{1,5,11,5}));
        Console.WriteLine(obj.CanPartition(new []{1,2,3,5}));
        Console.WriteLine(obj.CanPartition(new []{1}));
        Console.WriteLine(obj.CanPartition(new []{1,2,3}));
        Console.WriteLine(obj.CanPartition(new []{1,99}));
        Console.WriteLine(obj.CanPartition(new []{2,2,3,5}));
        Console.WriteLine(obj.CanPartition(new []{1,5,10,6}));
    }
    
    public bool CanPartition2(int[] nums)
    {
        // 求出总和的一半作为目标值
        int sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        if (sum % 2 != 0) return false;
        sum = sum / 2;
        // dp[i,j]表示前i个元素是否能组成和为j的子集
        bool[,] dp = new bool[nums.Length+1,sum+1];
        // 初始化dp[i,0]，因为dp[i,0]表示前i个元素是否能组成和为0的子集，显然是可以的
        for (int i = 0; i <= nums.Length; i++)
        {
            dp[i,0] = true;
        }
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                // 不选当前元素
                dp[i, j] = dp[i - 1, j];
                // 选当前元素
                if (j >= nums[i - 1])
                    dp[i, j] |= dp[i - 1, j - nums[i - 1]];
            }
        }

        return dp[nums.Length, sum];
    }
    
    public bool CanPartition(int[] nums)
    {
        int sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        if (sum % 2 != 0) return false;
        sum = sum / 2;
        bool[] dp = new bool[sum+1];
        dp[0] = true;
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = sum; j >= nums[i - 1]; j--)
            {
                dp[j] |= dp[j - nums[i - 1]];
            }
        }

        return dp[sum];
    }
}