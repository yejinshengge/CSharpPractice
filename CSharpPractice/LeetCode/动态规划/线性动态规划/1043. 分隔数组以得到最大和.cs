namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个整数数组 arr，请你将该数组分隔为长度 最多 为 k 的一些（连续）子数组。
 * 分隔完成后，每个子数组的中的所有值都会变为该子数组中的最大值。
    
    返回将数组分隔变换后能够得到的元素最大和。本题所用到的测试用例会确保答案是一个 32 位整数。
 */
public class LeetCode_1043
{
    public static void Test()
    {
        LeetCode_1043 obj = new LeetCode_1043();
        Console.WriteLine(obj.MaxSumAfterPartitioning(new []{1,15,7,9,2,5,10},3));
        Console.WriteLine(obj.MaxSumAfterPartitioning(new []{1,4,1,5,7,3,6,1,9,9,3},4));
        Console.WriteLine(obj.MaxSumAfterPartitioning(new []{1},1));
    }
    
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        int[] dp = new int[arr.Length];
        dp[0] = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            int max = 0;
            for (int j = 1; j <= k&&j<=i+1; j++)
            {
                max = Math.Max(max, arr[i - j + 1]);
                dp[i] = Math.Max((i>=j?dp[i - j]:0) + max * j,dp[i]);
            }
            
        }
        return dp[arr.Length - 1];
    }
}