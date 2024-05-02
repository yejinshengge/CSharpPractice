namespace CSharpPractice.LeetCode.数组篇.滑动窗口;

/**
给定一个含有n个正整数的数组和一个正整数 target 。
找出该数组中满足其和 ≥ target 的长度最小的 连续子数组[numsl, numsl+1, ..., numsr-1, numsr] ，并返回其长度。如果不存在符合条件的子数组，返回 0 。
 */
public class LeetCode_0209
{
    public static void Test()
    {
        LeetCode_0209 obj = new LeetCode_0209();
        Console.WriteLine(obj.MinSubArrayLen(7,new int[]{2,3,1,2,4,3}));
        Console.WriteLine(obj.MinSubArrayLen(4,new int[]{1,4,4}));
        Console.WriteLine(obj.MinSubArrayLen(11,new int[]{1,1,1,1,1,1,1,1}));
        Console.WriteLine(obj.MinSubArrayLen(11,new int[]{1}));
    }

    // 滑动窗口
    public int MinSubArrayLen(int target, int[] nums)
    {
        int left = 0, right = 0;
        int min = int.MaxValue;
        int sum = 0;

        while (right <= nums.Length && left <= right)
        {
            if (sum < target)
            {
                if(right == nums.Length) break;
                sum += nums[right];
                right++;
            }
            else
            {
                min = Math.Min(min, right - left);
                sum -= nums[left];
                left++;
            }
        }

        return min == int.MaxValue ? 0 : min;
    }
}