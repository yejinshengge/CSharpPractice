using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你一个 升序排列 的数组 nums ，请你 原地 删除重复出现的元素，使每个元素 只出现一次 ，
 * 返回删除后数组的新长度。元素的 相对顺序 应该保持 一致 。然后返回 nums 中唯一元素的个数。
 */
public class LeetCode_001 {

    public static void LeetCode_001Main()
    {
        LeetCode_001 obj = new LeetCode_001();
        
        int[] nums = new int[] {1,1,2};
        var k = obj.RemoveDuplicates3(nums);
        Console.WriteLine(k);
        Util.Tools.PrintArr(nums);
    }
    
    /// <summary>
    /// 思路一:遍历数组,每遍历到一个元素,就向后查找有无重复元素,统计重复元素的长度,然后将后面的数组元素复制到前面
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RemoveDuplicates(int[] nums)
    {
        int left = 0;
        int right = 1;
        int size = nums.Length;
        
        while (right < size)
        {
            // 相邻两元素相同
            if (nums[left] == nums[right])
            {
                while (nums[left] == nums[right])
                {
                    right++;
                    if (right >= size) return left+1;
                }

                Array.Copy(nums,right,nums,left+1,size-right);
                size = size - (right-left-1);
            }

            left++;
            right = left + 1;
        }
        return size;
    }

    /// <summary>
    /// 思路二:双指针解法,如果左指针与右指针元素相同,右指针右移;如果不同,则左指针下一位替换为右指针所指元素
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RemoveDuplicates2(int[] nums)
    {
        int left = 0;
        int right = 1;

        while (right < nums.Length)
        {
            if (nums[left] != nums[right])
            {
                nums[++left] = nums[right];
            }
            right++;
        }
        return left + 1;
    }

    // __________________________复习__________________________
    
    // 双指针
    public int RemoveDuplicates3(int[] nums)
    {
        int left = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[left])
            {
                nums[++left] = nums[i];
            }
        }

        return left+1;
    }
}