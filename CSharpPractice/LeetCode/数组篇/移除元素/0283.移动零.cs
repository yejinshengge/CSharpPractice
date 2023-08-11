using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇.移除元素;
/**
给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。
请注意 ，必须在不复制数组的情况下原地对数组进行操作。
 */
public class LeetCode_0283
{
    public static void Test()
    {
        LeetCode_0283 obj = new LeetCode_0283();
        int[] arr = new[] {0};
        obj.MoveZeroes(arr);
        Util.Tools.PrintArr(arr);
        
    }

    // 思路一:双指针
    public void MoveZeroes(int[] nums)
    {
        int left = 0, right = 0;

        while (right < nums.Length)
        {
            if (nums[right] == 0)
            {
                right++;
            }
            else
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right++;
            }
        }
    }
}