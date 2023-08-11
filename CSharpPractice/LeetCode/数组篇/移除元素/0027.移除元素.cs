using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇.移除元素;

/**
给你一个数组 nums和一个值 val，你需要 原地 移除所有数值等于val的元素，并返回移除后数组的新长度。
不要使用额外的数组空间，你必须仅使用 O(1) 额外空间并 原地 修改输入数组。
元素的顺序可以改变。你不需要考虑数组中超出新长度后面的元素。

 */
public class LeetCode_0027
{
    public static void Test()
    {
        LeetCode_0027 obj = new LeetCode_0027();
        int[] arr = new[] {1};
        Console.WriteLine(obj.RemoveElement2(arr,1));
        Util.Tools.PrintArr(arr);
    }
    
    // 双指针,从两头向中间,会打乱顺序
    public int RemoveElement(int[] nums, int val)
    {
        int index = 0, len = nums.Length;
        while (index < len)
        {
            if (nums[index] == val)
            {
                (nums[index], nums[len - 1]) = (nums[len - 1], nums[index]);
                len--;
            }
            else
            {
                index++;
            }
            
        }

        return len;
    }

    public int RemoveElement2(int[] nums, int val)
    {
        int left = 0,right = 0;

        while (right < nums.Length)
        {
            if (nums[right] == val)
                right++;
            else
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right++;
            }
        }

        return left;
    }
}