namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0581
{
    public static void Test()
    {
        LeetCode_0581 obj = new LeetCode_0581();
        Console.WriteLine(obj.FindUnsortedSubarray(new []{2,6,4,8,10,9,15}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{1,2,3,4}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{0}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{4,5,3,2,1}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{5,4,3,2,1}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{1,3,2,2,2}));
    }

    public int FindUnsortedSubarray(int[] nums)
    {
        int left = nums.Length - 1, right = 0;
        int max = int.MinValue, min = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            // 找到最后一个错位的最大值
            if (nums[i] >= max)
                max = nums[i];
            else
                right = i;
            // 找到第一个错位的最小值
            if (nums[nums.Length - i - 1] <= min)
                min = nums[nums.Length - i - 1];
            else
                left = nums.Length - i - 1;
        }

        return right > left ? right - left + 1 : 0;
    }
}