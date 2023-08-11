using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇;

/**
给你一个按照非递减顺序排列的整数数组 nums，和一个目标值 target。请你找出给定目标值在数组中的开始位置和结束位置。
如果数组中不存在目标值 target，返回[-1, -1]。
你必须设计并实现时间复杂度为O(log n)的算法解决此问题。

 */
public class LeetCode_0034
{
    public static void Test()
    {
        LeetCode_0034 obj = new LeetCode_0034();
        Util.Tools.PrintArr(obj.SearchRange2(new []{5,7,7,8,8,10},8));
        Util.Tools.PrintArr(obj.SearchRange(new []{5,7,7,8,8,10},8));
        Util.Tools.PrintArr(obj.SearchRange2(new []{5,7,7,8,8,10},6));
        Util.Tools.PrintArr(obj.SearchRange(new []{5,7,7,8,8,10},6));
        Util.Tools.PrintArr(obj.SearchRange2(new []{2,2},2));
        Util.Tools.PrintArr(obj.SearchRange(new []{2,2},2));      
        Util.Tools.PrintArr(obj.SearchRange2(new []{2,2},3));
        Util.Tools.PrintArr(obj.SearchRange(new []{2,2},3));   
        Util.Tools.PrintArr(obj.SearchRange2(new []{2},2));
        Util.Tools.PrintArr(obj.SearchRange(new []{2},2));
        Util.Tools.PrintArr(obj.SearchRange2(new int[]{},0));
        Util.Tools.PrintArr(obj.SearchRange(new int[]{},0));
    }

    // 二分法找到后,再寻找边界
    public int[] SearchRange(int[] nums, int target)
    {
        int left = 0, right = nums.Length;
        while (left < right)
        {
            int mid = (right - left) / 2 + left;
            if (nums[mid] > target)
                right = mid;
            else if (nums[mid] < target)
                left = mid + 1;
            else
            {
                left = mid - 1;
                right = mid + 1;
                while (left >= 0)
                {
                    if (nums[left] == target)
                        left--;
                    else
                        break;
                }

                while (right < nums.Length)
                {
                    if (nums[right] == target)
                        right++;
                    else
                        break;
                }

                return new[] { left + 1, right - 1 };
            }

        }
        return new[] { -1, -1 };
    }
    
    // 思路二:用两次二分法
    public int[] SearchRange2(int[] nums, int target)
    {
        int left = Dichotomy(nums, target, true);
        int right = Dichotomy(nums, target, false);
        if (right < left || right == -1 || left == -1) return new[] { -1, -1 };
        
        return new[] { left, right };
    }

    private int Dichotomy(int[] nums,int target,bool isLeft)
    {
        int left = 0, right = nums.Length - 1;
        int last = -1;
        while (left <= right)
        {
            int mid = (right - left) / 2 + left;
            // 寻找左边界
            if (isLeft)
            {
                if (nums[mid] >= target)
                {
                    right = mid - 1;
                    last = mid;
                }
                else
                    left = mid + 1;
            }
            // 寻找右边界
            else
            {
                if (nums[mid] <= target)
                {
                    left = mid + 1;
                    last = mid;
                }
                else
                    right = mid - 1;
            }
        }

        return last;
    }
}