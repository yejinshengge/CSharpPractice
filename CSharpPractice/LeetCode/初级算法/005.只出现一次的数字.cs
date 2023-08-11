namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你一个 非空 整数数组 nums ，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。
 * 你必须设计并实现线性时间复杂度的算法来解决此问题，且该算法只使用常量额外空间。
 */
public class LeetCode_005 {
    public static void LeetCode_005Main()
    {
        LeetCode_005 obj = new LeetCode_005();
        int[] arr = new[] {4, 1, 2, 1, 2};
        Console.WriteLine(obj.SingleNumber1(arr));

    }
    
    // 思路一:通过位运算「异或」解决
    public int SingleNumber1(int[] nums)
    {
        int res = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            res = res ^ nums[i];
        }
        return res;
    }
}