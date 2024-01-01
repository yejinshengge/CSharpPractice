using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.排序;

/**
 * 给定一个包含红色、白色和蓝色、共 n 个元素的数组 nums ，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。
    
    我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。
    
    必须在不使用库内置的 sort 函数的情况下解决这个问题。
 */
public class LeetCode_0075
{
    public static void Test()
    {
        LeetCode_0075 obj = new LeetCode_0075();
        int[] nums = new[] { 2, 0, 2, 1, 1, 0 };
        obj.SortColors(nums);
        Tools.PrintArr(nums);
        nums = new[] { 2, 0, 1 };
        obj.SortColors(nums);
        Tools.PrintArr(nums);
    }
    
    public void SortColors(int[] nums)
    {
        int smallP = -1;
        int bigP = nums.Length;
        int num = 1;
        int index = 0;
        while (index < bigP)
        {
            if (nums[index] > num)
            {
                bigP--;
                (nums[index], nums[bigP]) = (nums[bigP], nums[index]);
            }
            else if (nums[index] < num)
            {
                smallP++;
                (nums[index], nums[smallP]) = (nums[smallP], nums[index]);
                index++;
            }
            else
            {
                index++;
            }
        }
    }
}