namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR090
{
    public static void Test()
    {
        LeetCode_LCR090 obj = new LeetCode_LCR090();
        Console.WriteLine(obj.Rob(new []{2,3,2}));
        Console.WriteLine(obj.Rob(new []{1,2,3,1}));
        Console.WriteLine(obj.Rob(new []{1}));
    }
    
    public int Rob(int[] nums) {
        int dp1 = 0;
        int dp2 = nums[0];
        for (var i = 2; i <= nums.Length; i++)
        {
            int tmp = dp2;
            if(i != nums.Length)
                dp2 = Math.Max(dp1 + nums[i - 1], dp2);
            dp1 = tmp;
        }

        int res1 = dp2;
        dp1 = 0;
        dp2 = 0;
        for (var i = 2; i <= nums.Length; i++)
        {
            int tmp = dp2;
            dp2 = Math.Max(dp1 + nums[i - 1], dp2);
            dp1 = tmp;
        }
        return Math.Max(dp2,res1);
    }
}