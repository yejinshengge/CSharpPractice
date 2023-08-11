using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇.移除元素;

/**
给你一个 升序排列 的数组 nums ，请你 原地 删除重复出现的元素，使每个元素 只出现一次 ，返回删除后数组的新长度。
元素的 相对顺序 应该保持 一致 。然后返回 nums 中唯一元素的个数。
考虑 nums 的唯一元素的数量为 k ，你需要做以下事情确保你的题解可以被通过：
更改数组 nums ，使 nums 的前 k 个元素包含唯一元素，并按照它们最初在 nums 中出现的顺序排列。nums的其余元素与 nums 的大小不重要。
返回 k。

 */
public class LeetCode_0026
{
    public static void Test()
    {
        LeetCode_0026 obj = new LeetCode_0026();
        int[] arr = new[] {1};
        Console.WriteLine(obj.RemoveDuplicates(arr));
        Util.Tools.PrintArr(arr);
    }

    // 思路一:双指针
    public int RemoveDuplicates(int[] nums)
    {
        int left = 0, right = 0;
        while (right < nums.Length)
        {
            if (nums[left] == nums[right])
            {
                right++;
            }
            else
            {
                left++;
                (nums[left], nums[right]) = (nums[right], nums[left]);
                right++;
            }
        }

        return left+1;
    }
}