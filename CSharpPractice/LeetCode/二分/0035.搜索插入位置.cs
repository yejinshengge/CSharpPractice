namespace CSharpPractice.LeetCode.数组篇;

// 给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。
// 如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
// 请必须使用时间复杂度为 O(log n) 的算法。

public class LeetCode_0035
{
    public static void Test()
    {
        LeetCode_0035 obj = new LeetCode_0035();
        Console.WriteLine(obj.SearchInsert(new []{1,3,5,6},5));
        Console.WriteLine(obj.SearchInsert(new []{1,3,5,6},2));
        Console.WriteLine(obj.SearchInsert(new []{1,3,5,6},7));
        Console.WriteLine(obj.SearchInsert(new []{1},2));
        Console.WriteLine(obj.SearchInsert(new []{1},1));
    }

    // 二分法,左闭右开
    public int SearchInsert(int[] nums, int target)
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
                return mid;
        }

        return right;
    }
}