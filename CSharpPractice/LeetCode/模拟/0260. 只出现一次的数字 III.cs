using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.模拟;

/**
 * 给你一个整数数组 nums，其中恰好有两个元素只出现一次，其余所有元素均出现两次。 找出只出现一次的那两个元素。你可以按 任意顺序 返回答案。

你必须设计并实现线性时间复杂度的算法且仅使用常量额外空间来解决此问题。
 */
public class LeetCode_0260
{
    public static void Test()
    {
        LeetCode_0260 obj = new LeetCode_0260();
        Tools.PrintArr(obj.SingleNumber(new []{1,2,1,3,2,5}));
    }
    
    public int[] SingleNumber(int[] nums)
    {
        if (nums.Length == 2) return nums;
        Array.Sort(nums);
        List<int> res = new List<int>();
        int left = 0, right = 1;
        while (left < nums.Length)
        {
            if (right >= nums.Length)
            {
                res.Add(nums[left]);
                break;
            }
            if (nums[right] != nums[left])
            {
                res.Add(nums[left]);
                left--;
                right--;
            }

            left += 2;
            right += 2;
        }
        return res.ToArray();
    }
}