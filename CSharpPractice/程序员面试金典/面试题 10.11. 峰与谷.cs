using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_10_11
{
    public static void Test()
    {
        LeetCode_10_11 obj = new LeetCode_10_11();
        var arr = new[] { 5, 3, 1, 2, 3 };
        obj.WiggleSort(arr);
        Tools.PrintArr(arr);
    }
    
    public void WiggleSort(int[] nums) {
        for (int i = 1; i < nums.Length; i++)
        {
            if (i % 2 == 0 ? nums[i] > nums[i - 1] :
                 nums[i] < nums[i - 1])
                (nums[i], nums[i - 1]) = (nums[i - 1], nums[i]);
        }
    }
}