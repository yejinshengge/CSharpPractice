namespace CSharpPractice.LeetCode.双指针;

/**
 * 给定一个长度为 n 的 0 索引整数数组 nums。初始位置为 nums[0]。

    每个元素 nums[i] 表示从索引 i 向前跳转的最大长度。换句话说，如果你在 nums[i] 处，你可以跳转到任意 nums[i + j] 处:

    0 <= j <= nums[i] 
    i + j < n
    返回到达 nums[n - 1] 的最小跳跃次数。生成的测试用例可以到达 nums[n - 1]。
 */
public class LeetCode_0045
{
    public static void Test()
    {
        LeetCode_0045 obj = new LeetCode_0045();
        Console.WriteLine(obj.Jump(new []{2,3,1,1,4}));
        Console.WriteLine(obj.Jump(new []{2,3,0,1,4}));
    }
    
    public int Jump(int[] nums)
    {
        int maxPos = 0;
        int end = 0;
        int res = 0;
        for (int i = 0; i < nums.Length-1; i++)
        {
            maxPos = Math.Max(nums[i] + i, maxPos);
            if (i == end)
            {
                end = maxPos;
                res++;
            }
        }

        return res;
    }
}