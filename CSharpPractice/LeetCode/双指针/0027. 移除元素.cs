namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个数组 nums 和一个值 val，你需要 原地 移除所有数值等于 val 的元素，并返回移除后数组的新长度。

不要使用额外的数组空间，你必须仅使用 O(1) 额外空间并 原地 修改输入数组。

元素的顺序可以改变。你不需要考虑数组中超出新长度后面的元素。
 */
public class LeetCode_0027
{
    public static void Test()
    {
        LeetCode_0027 obj = new LeetCode_0027();
        Console.WriteLine(obj.RemoveElement(Array.Empty<int>(),1));
        Console.WriteLine(obj.RemoveElement(new []{1},1));
    }
    
    public int RemoveElement(int[] nums, int val)
    {
        int left = 0, right = nums.Length;
        while (left < right)
        {
            if (nums[left] == val)
            {
                (nums[left], nums[right-1]) = (nums[right-1], nums[left]);
                right--;
            }
            else
            {
                left++;
            }
        }

        return left;
    }
}