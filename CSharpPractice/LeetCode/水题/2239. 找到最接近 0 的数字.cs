namespace CSharpPractice.LeetCode.二分;

public class LeetCode_2239
{
    public static void Test()
    {
        LeetCode_2239 obj = new LeetCode_2239();
        Console.WriteLine(obj.FindClosestNumber(new []{-4,-2,1,4,8}));
        Console.WriteLine(obj.FindClosestNumber(new []{2,-1,1}));
        Console.WriteLine(obj.FindClosestNumber(new []{4,2,1,-1,-4,-8}));
    }
    
    public int FindClosestNumber(int[] nums)
    {
        int diff = int.MaxValue;
        int maxNum = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (Math.Abs(nums[i]) < diff || (Math.Abs(nums[i]) == diff && nums[i] > maxNum))
            {
                diff = Math.Abs(nums[i]);
                maxNum = nums[i];
            }
        }

        return maxNum;
    }
}