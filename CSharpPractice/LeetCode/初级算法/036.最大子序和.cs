namespace CSharpPractice.LeetCode.初级算法;

// 给你一个整数数组 nums ，请你找出一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
// 子数组 是数组中的一个连续部分。
public class LeetCode_036
{
    public static void Test()
    {
        LeetCode_036 obj = new LeetCode_036();
        Console.WriteLine(obj.MaxSubArray2(new []{5,4,-1,7,8}));
    }

    // 思路一:动态规划
    public int MaxSubArray(int[] nums)
    {
        int[] arr = new int[nums.Length];
        arr[0] = nums[0];
        int max = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            arr[i] = Math.Max(arr[i - 1], 0) + nums[i];
            max = Math.Max(max, arr[i]);
        }

        return max;
    }

    // 优化
    public int MaxSubArray2(int[] nums)
    {
        int pre = nums[0];
        int max = pre;

        for (int i = 1; i < nums.Length; i++)
        {
            pre = Math.Max(pre, 0) + nums[i];
            max = Math.Max(max, pre);
        }

        return max;
    }
}