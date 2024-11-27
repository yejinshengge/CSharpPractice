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
        int sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        if (sum % 2 != 0) return false;
        sum = sum / 2;
        bool[,] dp = new bool[nums.Length+1,sum+1];
        for (int i = 0; i <= nums.Length; i++)
        {
            dp[i,0] = true;
        }
        for (int i = 1; i <= nums.Length; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                dp[i, j] = dp[i - 1, j];
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