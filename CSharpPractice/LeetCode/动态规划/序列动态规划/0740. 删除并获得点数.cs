namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个整数数组 nums ，你可以对它进行一些操作。

    每次操作中，选择任意一个 nums[i] ，删除它并获得 nums[i] 的点数。
    之后，你必须删除 所有 等于 nums[i] - 1 和 nums[i] + 1 的元素。

    开始你拥有 0 个点数。返回你能通过这些操作获得的最大点数。


 */
public class LeetCode_0740
{
    public static void Test()
    {
        LeetCode_0740 obj = new LeetCode_0740();
        Console.WriteLine(obj.DeleteAndEarn(new []{3,4,2}));
        Console.WriteLine(obj.DeleteAndEarn(new []{2,2,3,3,3,4}));
    }
    
    public int DeleteAndEarn(int[] nums)
    {
        int maxVal = 0;
        foreach (var num in nums)
        {
            maxVal = Math.Max(maxVal, num);
        }

        int[] sum = new int[maxVal+1];
        foreach (var num in nums)
        {
            sum[num] += num;
        }

        int[] dp = new int[maxVal + 1];
        dp[1] = sum[1];
        for (int i = 2; i <= maxVal; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + sum[i]);
        }

        return dp[maxVal];
    }
}