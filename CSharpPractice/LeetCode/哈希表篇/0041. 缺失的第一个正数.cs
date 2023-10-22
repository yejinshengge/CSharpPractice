namespace CSharpPractice.LeetCode.哈希表篇;

/**
给你一个未排序的整数数组 nums ，请你找出其中没有出现的最小的正整数。

请你实现时间复杂度为 O(n) 并且只使用常数级别额外空间的解决方案。
 */
public class LeetCode_0041
{
    public static void Test()
    {
        LeetCode_0041 obj = new LeetCode_0041();
        Console.WriteLine(obj.FirstMissingPositive(new []{1,2,0}));
        Console.WriteLine(obj.FirstMissingPositive(new []{3,4,-1,1}));
        Console.WriteLine(obj.FirstMissingPositive(new []{7,8,9,11,12}));
    }
    
    public int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            while (nums[i] >0 && nums[i] <= n && nums[i] != nums[nums[i]-1])
            {
                (nums[i], nums[nums[i]-1]) = (nums[nums[i]-1], nums[i]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i+1)
                return i+1;
        }

        return n + 1;
    }
}