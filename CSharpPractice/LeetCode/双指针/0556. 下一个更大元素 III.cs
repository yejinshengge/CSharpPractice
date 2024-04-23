namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个正整数 n ，请你找出符合条件的最小整数，其由重新排列 n 中存在的每位数字组成，
 * 并且其值大于 n 。如果不存在这样的正整数，则返回 -1 。
 * 注意 ，返回的整数应当是一个 32 位整数 ，如果存在满足题意的答案，但不是 32 位整数 ，同样返回 -1 。
 */
public class LeetCode_0556
{
    public static void Test()
    {
        LeetCode_0556 obj = new LeetCode_0556();
        Console.WriteLine(obj.NextGreaterElement(12));
        Console.WriteLine(obj.NextGreaterElement(21));
        Console.WriteLine(obj.NextGreaterElement(11));
    }
    
    public int NextGreaterElement(int n)
    {
        var nums = n.ToString().ToCharArray();
        // 从右往左，找到第一个下降的数
        int left = nums.Length - 2;
        while (left >= 0 && nums[left+1] <= nums[left])
        {
            left--;
        }

        if (left < 0) return -1;
        // 从右向左,找到第一个大于nums[left]的数
        int right = nums.Length - 1;
        while (right >=0 && nums[left] >= nums[right])
        {
            right--;
        }
        // 交换
        (nums[left], nums[right]) = (nums[right], nums[left]);
        // 交换后,left往右一定是降序，需要使其反转
        Array.Reverse(nums,left+1,nums.Length - left - 1);
        long res = long.Parse(new string(nums));
        if (res > int.MaxValue) return -1;
        return (int)res;
    }
}