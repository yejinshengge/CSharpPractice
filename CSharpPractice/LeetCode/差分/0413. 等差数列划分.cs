namespace CSharpPractice.LeetCode.差分;

/**
 * 如果一个数列 至少有三个元素 ，并且任意两个相邻元素之差相同，则称该数列为等差数列。

    例如，[1,3,5,7,9]、[7,7,7,7] 和 [3,-1,-5,-9] 都是等差数列。
    给你一个整数数组 nums ，返回数组 nums 中所有为等差数组的 子数组 个数。

    子数组 是数组中的一个连续序列。
 */
public class LeetCode_0413
{
    public static void Test()
    {
        LeetCode_0413 obj = new LeetCode_0413();
        Console.WriteLine(obj.NumberOfArithmeticSlices(new []{1,2,3,4,5}));
    }
    
    public int NumberOfArithmeticSlices(int[] nums)
    {
        if (nums.Length < 3) return 0;
        int d = nums[1] - nums[0];
        int num = 0;
        int res = 0;
        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i] - nums[i - 1] == d)
                num++;
            else
            {
                d = nums[i] - nums[i - 1];
                num = 0;
            }

            res += num;
        }

        return res;
    }
}