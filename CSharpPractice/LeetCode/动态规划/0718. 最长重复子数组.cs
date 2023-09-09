namespace CSharpPractice.LeetCode.动态规划;

/**
 * 给两个整数数组 nums1 和 nums2 ，返回 两个数组中 公共的 、长度最长的子数组的长度 。
 */
public class LeetCode_0718
{
    public static void Test()
    {
        LeetCode_0718 obj = new LeetCode_0718();
        Console.WriteLine(obj.FindLength(new []{1,2,3,2,1},new []{3,2,1,4,7}));
        Console.WriteLine(obj.FindLength(new []{0,0,0,0,0},new []{0,0,0,0,0}));
        Console.WriteLine(obj.FindLength(new []{1,0,0,0,1,0,0,1,0,0},new []{0,1,1,1,0,1,1,1,0,0}));
    }
    
    public int FindLength(int[] nums1, int[] nums2)
    {
        int[] dp = new int[nums2.Length+1];

        int res = 0;
        for (int i = 1; i <= nums1.Length; i++)
        {
            for (int j = nums2.Length; j >=1; j--)
            {
                if (nums1[i - 1] == nums2[j - 1])
                {
                    dp[j] = dp[j - 1] + 1;
                }
                else dp[j] = 0;
                res = Math.Max(res, dp[j]);
            }

        }

        return res;
    }
}