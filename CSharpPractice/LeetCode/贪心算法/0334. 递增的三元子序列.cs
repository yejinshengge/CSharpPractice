namespace CSharpPractice.LeetCode.贪心算法;

public class LeetCode_0334
{
    public static void Test()
    {
        LeetCode_0334 obj = new LeetCode_0334();
        Console.WriteLine(obj.IncreasingTriplet(new []{1,2,3,4,5}));
        Console.WriteLine(obj.IncreasingTriplet(new []{5,4,3,2,1}));
        Console.WriteLine(obj.IncreasingTriplet(new []{2,1,5,0,4,6}));
    }
    
    public bool IncreasingTriplet(int[] nums)
    {
        int oneLIS = int.MaxValue;
        int twoLIS = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > twoLIS) return true;
            if (nums[i] > oneLIS && nums[i] < twoLIS) twoLIS = nums[i];
            else if (nums[i] < oneLIS) oneLIS = nums[i];
        }
        return false;
    }
}