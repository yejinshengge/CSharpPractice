namespace CSharpPractice.LeetCode.贪心算法;

/**
    给你一个非负整数数组 nums ，你最初位于数组的 第一个下标 。数组中的每个元素代表你在该位置可以跳跃的最大长度。
    判断你是否能够到达最后一个下标，如果可以，返回 true ；否则，返回 false 。
 */
public class LeetCode_0055
{
    public static void Test()
    {
        LeetCode_0055 obj = new LeetCode_0055();
        Console.WriteLine(obj.CanJump(new []{2,3,1,1,4}));
        Console.WriteLine(obj.CanJump(new []{3,2,1,0,4}));
        Console.WriteLine(obj.CanJump(new []{0}));
    }
    
    public bool CanJump(int[] nums)
    {
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            max = Math.Max(max, nums[i] + i);
            if (max >= nums.Length - 1)
                return true;
            if (max == i)
                return false;
        }

        return false;
    }
}