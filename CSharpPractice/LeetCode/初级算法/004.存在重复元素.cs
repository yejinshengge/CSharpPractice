namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你一个整数数组 nums 。如果任一值在数组中出现 至少两次 ，返回 true ；如果数组中每个元素互不相同，返回 false 。
 */
public class LeetCode_004 {

    public static void LeetCode_004Main()
    {
        LeetCode_004 obj = new LeetCode_004();
        int[] arr = new[] {1,2,3,4};
        Console.WriteLine(obj.ContainsDuplicate1(arr));
    }
    
    // 思路一:用哈希表
    public bool ContainsDuplicate1(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (set.Contains(nums[i]))
                return true;
            set.Add(nums[i]);
        }

        return false;
    }
    
}