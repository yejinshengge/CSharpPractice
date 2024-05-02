namespace CSharpPractice.LeetCode.数组篇;

/**
整数数组 nums 按升序排列，数组中的值 互不相同 。

在传递给函数之前，nums 在预先未知的某个下标 k（0 <= k < nums.length）上进行了 旋转，使数组变为 [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]]（下标 从 0 开始 计数）。例如， [0,1,2,4,5,6,7] 在下标 3 处经旋转后可能变为 [4,5,6,7,0,1,2] 。

给你 旋转后 的数组 nums 和一个整数 target ，如果 nums 中存在这个目标值 target ，则返回它的下标，否则返回 -1 。

你必须设计一个时间复杂度为 O(log n) 的算法解决此问题。
 */
public class LeetCode_0033
{
    public static void Test()
    {
        LeetCode_0033 obj = new LeetCode_0033();
        // Console.WriteLine(obj.Search(new []{4,5,6,7,0,1,2},0));
        // Console.WriteLine(obj.Search(new []{4,5,6,7,0,1,2},3));
        // Console.WriteLine(obj.Search(new []{1},0));
        Console.WriteLine(obj.Search(new []{5,1,3},3));
    }
    
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 1) return nums[0] == target ? 0 : -1;
        int left = 0, right = nums.Length - 1;
        while (left<=right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] == target) return mid;
            if (nums[left] <= nums[mid])
            {
                if (nums[left] <= target && nums[mid] > target)
                    right = mid-1;
                else
                    left = mid+1;
            }
            else
            {
                if (nums[mid] < target && nums[right] >= target)
                    left = mid+1;
                else
                    right = mid-1;
            }
        }

        return -1;
    }
}