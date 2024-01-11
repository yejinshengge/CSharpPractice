namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个整数数组 nums ，请你找出数组中乘积最大的非空连续子数组（该子数组中至少包含一个数字），并返回该子数组所对应的乘积。
    
    测试用例的答案是一个 32-位 整数。
    
    子数组 是数组的连续子序列。
 */
public class LeetCode_0152
{
    public static void Test()
    {
        LeetCode_0152 obj = new LeetCode_0152();
        Console.WriteLine(obj.MaxProduct(new []{2,3,-2,4}));
        Console.WriteLine(obj.MaxProduct(new []{-2,0,-1}));
        Console.WriteLine(obj.MaxProduct(new []{0,2}));
    }
    
    public int MaxProduct(int[] nums)
    {
        int res = nums[0],minDp = nums[0],maxDp = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int max = maxDp;
            int min = minDp;

            maxDp = Math.Max(max * nums[i], Math.Max(nums[i], min * nums[i]));
            minDp = Math.Min(max * nums[i], Math.Min(nums[i], min * nums[i]));
            res = Math.Max(res, maxDp);
        }

        return res;
    }
}