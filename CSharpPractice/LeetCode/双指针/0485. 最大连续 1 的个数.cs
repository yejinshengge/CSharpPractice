namespace CSharpPractice.LeetCode.双指针;
// 给定一个二进制数组 nums ， 计算其中最大连续 1 的个数。
public class LeetCode_0485
{
    public static void Test()
    {
        LeetCode_0485 obj = new LeetCode_0485();
        Console.WriteLine(obj.FindMaxConsecutiveOnes(new []{1,1,0,1,1,1}));
        Console.WriteLine(obj.FindMaxConsecutiveOnes(new []{1,0,1,1,0,1}));
    }
    
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int max = 0;
        int left = 0, right = 0;
        while (right < nums.Length)
        {
            if (nums[right] == 1)
                right++;
            else
            {
                max = Math.Max(right - left,max);
                right++;
                left = right;
            }
        }
        max = Math.Max(right - left,max);
        return max;
    }
}