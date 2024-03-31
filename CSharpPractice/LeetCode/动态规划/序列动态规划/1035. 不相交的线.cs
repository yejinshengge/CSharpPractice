namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 在两条独立的水平线上按给定的顺序写下 nums1 和 nums2 中的整数。

    现在，可以绘制一些连接两个数字 nums1[i] 和 nums2[j] 的直线，这些直线需要同时满足：

     nums1[i] == nums2[j]
    且绘制的直线不与任何其他连线（非水平线）相交。
    请注意，连线即使在端点也不能相交：每个数字只能属于一条连线。

    以这种方法绘制线条，并返回可以绘制的最大连线数。
 */
public class LeetCode_1035
{
    public static void Test()
    {
        LeetCode_1035 obj = new LeetCode_1035();
        Console.WriteLine(obj.MaxUncrossedLines(new []{1,4,2},new []{1,2,4}));
        Console.WriteLine(obj.MaxUncrossedLines(new []{2,5,1,2,5},new []{10,5,2,1,5,2}));
        Console.WriteLine(obj.MaxUncrossedLines(new []{1,3,7,1,7,5},new []{1,9,2,5,1}));
    }
    
    public int MaxUncrossedLines(int[] nums1, int[] nums2)
    {
        var nums1Length = nums1.Length;
        var nums2Length = nums2.Length;
        
        int[,] dp = new int[nums1Length + 1, nums2Length + 1];

        for (int i = 1; i <= nums1Length; i++)
        {
            for (int j = 1; j <= nums2Length; j++)
            {
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                if (nums1[i - 1] == nums2[j - 1])
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - 1] + 1);
            }
        }

        return dp[nums1Length, nums2Length];
    }
}