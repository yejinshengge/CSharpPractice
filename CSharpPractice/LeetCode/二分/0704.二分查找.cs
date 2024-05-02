namespace CSharpPractice.LeetCode.数组篇;

// 给定一个n个元素有序的（升序）整型数组nums 和一个目标值target ，写一个函数搜索nums中的 target，如果目标值存在返回下标，否则返回 -1。
// https://leetcode.cn/problems/binary-search/
public class LeetCode_0704
{
    public static void Test()
    {
        LeetCode_0704 obj = new LeetCode_0704();
        Console.WriteLine(obj.Search(new []{-1,0,3,5,9,12},2));
    }

    // 思路一:二分法
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left<=right)
        {
            int mid = (right + left) / 2;
            if (nums[mid] > target)
                right = mid - 1;
            else if (nums[mid] < target)
                left = mid + 1;
            else
                return mid;
        }

        return -1;
    }
}