using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个整数数组 nums 和一个整数 k ，找出三个长度为 k 、互不重叠、且全部数字和（3 * k 项）最大的子数组，并返回这三个子数组。

    以下标的数组形式返回结果，数组中的每一项分别指示每个子数组的起始位置（下标从 0 开始）。如果有多个结果，返回字典序最小的一个。

 */
public class LeetCode_0689
{
    public static void Test()
    {
        LeetCode_0689 obj = new LeetCode_0689();
        Tools.PrintArr(obj.MaxSumOfThreeSubarrays(new []{1,2,1,2,6,7,5,1},2));
        Tools.PrintArr(obj.MaxSumOfThreeSubarrays(new []{1,2,1,2,1,2,1,2,1},2));
    }
    
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        // 前i个数,凑成j个最大子数组的和
        int[,] dp = new int[nums.Length+1,4];
        // 前i项和
        int[] pre = new int[nums.Length + 1];

        for (int i = 1; i <= nums.Length; i++)
        {
            // 计算前i项和
            pre[i] = pre[i - 1] + nums[i - 1];
            for (int j = 1; j <= 3; j++)
            {
                // 如果条件允许选当前元素
                if (k * j <= i)
                    dp[i, j] = Math.Max(dp[i, j], pre[i] - pre[i - k] + dp[i - k, j - 1]);
                // 如果条件允许选前一个元素
                if (k * j <= i - 1)
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
            }
        }

        int[] res = new int[3];
        int dpIndex = nums.Length-1;
        int resIndex = 2;

        while (resIndex >= 0)
        {
            // 数组和无变化,说明没有选新的元素
            if(dp[dpIndex,resIndex+1] == dp[dpIndex+1,resIndex+1]) dpIndex--;
            else
            {
                // dpIndex+1是选中的元素,需要往前数k个位置,才是起始位置
                res[resIndex] = dpIndex + 1 - k;
                resIndex--;
                dpIndex = dpIndex - k;
            }
        }

        return res;
    }
}