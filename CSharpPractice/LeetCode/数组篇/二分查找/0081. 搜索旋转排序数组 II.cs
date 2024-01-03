namespace CSharpPractice.LeetCode.数组篇;

/**
 * 已知存在一个按非降序排列的整数数组 nums ，数组中的值不必互不相同。
    
    在传递给函数之前，nums 在预先未知的某个下标 k（0 <= k < nums.length）上进行了 旋转 ，使数组变为 [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]]（下标 从 0 开始 计数）。例如， [0,1,2,4,4,4,5,6,6,7] 在下标 5 处经旋转后可能变为 [4,5,6,6,7,0,1,2,4,4] 。
    
    给你 旋转后 的数组 nums 和一个整数 target ，请你编写一个函数来判断给定的目标值是否存在于数组中。如果 nums 中存在这个目标值 target ，则返回 true ，否则返回 false 。
    
    你必须尽可能减少整个操作步骤。
 */
public class LeetCode_0081
{
    public static void Test()
    {
        LeetCode_0081 obj = new LeetCode_0081();
        Console.WriteLine(obj.Search(new []{2,5,6,0,0,1,2},0));
        Console.WriteLine(obj.Search(new []{2,5,6,0,0,1,2},3));
        Console.WriteLine(obj.Search(new []{1,0,1,1,1},0));
    }
    
    public bool Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left<= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] == target) return true;
            // 三者相同
            if (nums[left] == nums[mid] && nums[mid] == nums[right])
            {
                left++;
                right--;
            }
            // 左侧递增
            else if (nums[left] <= nums[mid])
            {
                if (nums[mid] > target && nums[left] <= target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            // 右侧递增
            else
            {
                if (nums[mid] < target && nums[right] >= target)
                    left = mid + 1;
                else
                    right = mid - 1;

            }
        }
        return false;
    }
}