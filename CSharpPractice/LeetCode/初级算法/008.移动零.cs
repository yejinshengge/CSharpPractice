using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。
请注意 ，必须在不复制数组的情况下原地对数组进行操作。
 */
public class LeetCode_008 {
    
    public static void LeetCode_008Main()
    {
        LeetCode_008 obj = new LeetCode_008();
        int[] arr = new[] {2,1};
        obj.MoveZeroes3(arr);
        Util.Tools.PrintArr(arr);
    }
    
    // 双指针
    public void MoveZeroes(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            // 遇到0,一位一位往后移
            if (nums[left] == 0)
            {
                int temp = left;
                while (temp < right)
                {
                    (nums[temp], nums[temp + 1]) = (nums[temp + 1], nums[temp]);
                    temp++;
                }
                right--;
            }
            else
            {
                left++;
            }
        }
    }

    // 先把非零的往前挪,最后把剩下的全置为0
    public void MoveZeroes2(int[] nums)
    {
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
                nums[index++] = nums[i];
        }

        while (index < nums.Length)
        {
            nums[index++] = 0;
        }
    }

    // 记录下0的数量,遇到非零元素,就交换到第一个0的位置
    public void MoveZeroes3(int[] nums)
    {
        int num = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                num++;
            else if (num != 0)
            {
                (nums[i - num], nums[i]) = (nums[i], nums[i - num]);
                nums[i] = 0;
            }
        }
    }
}