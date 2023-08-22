namespace CSharpPractice.LeetCode.贪心算法;

/**
给你一个整数数组 nums 和一个整数 k ，按以下方法修改该数组：

选择某个下标 i 并将 nums[i] 替换为 -nums[i] 。
重复这个过程恰好 k 次。可以多次选择同一个下标 i 。

以这种方式修改数组后，返回数组 可能的最大和 。
 */
public class LeetCode_1005
{
    public static void Test()
    {
        LeetCode_1005 obj = new LeetCode_1005();
        Console.WriteLine(obj.LargestSumAfterKNegations(new []{4,2,3},1));
        Console.WriteLine(obj.LargestSumAfterKNegations(new []{3,-1,0,2},3));
        Console.WriteLine(obj.LargestSumAfterKNegations(new []{2,-3,-1,5,-4},2));
        Console.WriteLine(obj.LargestSumAfterKNegations(new []{1},5));
        Console.WriteLine(obj.LargestSumAfterKNegations(new []{1},6));
        Console.WriteLine(obj.LargestSumAfterKNegations(new []{-1},5));
        Console.WriteLine(obj.LargestSumAfterKNegations(new []{-1},6));
    }
    
    public int LargestSumAfterKNegations(int[] nums, int k) {
        Array.Sort(nums);
        int res = 0;
        int mid = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (k > 0 && nums[i] < 0)
            {
                res += -nums[i];
                k--;
            }
            else
                res += nums[i];
            mid = Math.Min(Math.Abs(nums[i]), mid);
        }

        if (k % 2 == 0) return res;
        return res - 2*mid;
    }
}