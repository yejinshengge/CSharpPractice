namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 你有两个 有序 且数组内元素互不相同的数组 nums1 和 nums2 。

    一条 合法路径 定义如下：

    选择数组 nums1 或者 nums2 开始遍历（从下标 0 处开始）。
    从左到右遍历当前数组。
    如果你遇到了 nums1 和 nums2 中都存在的值，那么你可以切换路径到另一个数组对应数字处继续遍历（但在合法路径中重复数字只会被统计一次）。
    得分 定义为合法路径中不同数字的和。

    请你返回 所有可能 合法路径 中的最大得分。由于答案可能很大，请你将它对 10^9 + 7 取余后返回。
 */
public class LeetCode_1537
{
    public static void Test()
    {
        LeetCode_1537 obj = new LeetCode_1537();
        Console.WriteLine(obj.MaxSum(new []{2,4,5,8,10},new []{4,6,8,9}));
        Console.WriteLine(obj.MaxSum(new []{1,3,5,7,9},new []{3,5,100}));
        Console.WriteLine(obj.MaxSum(new []{1,2,3,4,5},new []{6,7,8,9,10}));
    }
    
    public int MaxSum(int[] nums1, int[] nums2)
    {
        const long MOD = 1000000007;
        long sum1 = 0, sum2 = 0;
        int i = 0, j = 0;

        while (i < nums1.Length || j < nums2.Length)
        {
            // 尽可能取小的，可以取更多个
            if (i < nums1.Length && (j == nums2.Length || nums1[i] < nums2[j]))
            {
                sum1 += nums1[i];
                i++;
            }
            else if (j < nums2.Length && (i == nums1.Length || nums2[j] < nums1[i]))
            {
                sum2 += nums2[j];
                j++;
            }
            // nums1[i] == nums2[j]
            else
            {
                long maxSum = Math.Max(sum1, sum2);
                sum1 = sum2 = maxSum + nums1[i];
                i++;
                j++;
            }
            
        }

        return (int)(Math.Max(sum1, sum2) % MOD);
    }
}