namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR089
{
    public static void Test()
    {
        LeetCode_LCR089 obj = new LeetCode_LCR089();
        Console.WriteLine(obj.Rob(new []{1,2,3,1}));
        Console.WriteLine(obj.Rob(new []{2,7,9,3,1}));
        Console.WriteLine(obj.Rob(new []{2}));
    }
    
    public int Rob(int[] nums)
    {
        int dp1 = 0;
        int dp2 = nums[0];
        for (var i = 2; i <= nums.Length; i++)
        {
            int tmp = dp2;
            dp2 = Math.Max(dp1 + nums[i - 1], dp2);
            dp1 = tmp;
        }

        return dp2;
    }
}