using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针.数组;

/**
 * 给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使得出现次数超过两次的元素只出现两次 ，返回删除后数组的新长度。
    
    不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。
 */
public class LeetCode_0080
{
    public static void Test()
    {
        LeetCode_0080 obj = new LeetCode_0080();
        int[] nums = new[] { 0,0,1,1,1,1,2,3,3 };
        Console.WriteLine(obj.RemoveDuplicates(nums));
        Tools.PrintArr(nums);
    }
    
    public int RemoveDuplicates(int[] nums)
    {
        return _doRemoveDuplicates(nums, 2);
    }

    private int _doRemoveDuplicates(int[] nums, int k)
    {
        if (nums.Length <= k) return nums.Length;
        int index = 0;
        foreach (var num in nums)
        {
            if (index < k || nums[index - k] != num)
                nums[index++] = num;
        }

        return index;
    }
}