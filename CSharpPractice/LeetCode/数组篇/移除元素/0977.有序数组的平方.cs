using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇.移除元素;

//给你一个按 非递减顺序 排序的整数数组 nums，返回 每个数字的平方 组成的新数组，要求也按 非递减顺序 排序。
public class LeetCode_0977
{
    public static void Test()
    {
        LeetCode_0977 obj = new LeetCode_0977();
        Util.Tools.PrintArr(obj.SortedSquares(new []{-5,-3,-2,-1}));
        Util.Tools.PrintArr(obj.SortedSquares(new []{-4,-1,0,3,10}));
        Util.Tools.PrintArr(obj.SortedSquares(new []{-7,-3,2,3,11}));
        Util.Tools.PrintArr(obj.SortedSquares(new []{0}));
    }

    // 双指针
    public int[] SortedSquares(int[] nums)
    {
        int[] arr = new int[nums.Length];
        int left = 0;
        int right = nums.Length - 1;
        int index = right;

        while (index >= 0)
        {
            if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
            {
                arr[index] = nums[left] * nums[left];
                left++;
            }
            else
            {
                arr[index] = nums[right] * nums[right];
                right--;
            }

            index--;
        }

        return arr;
    }
}