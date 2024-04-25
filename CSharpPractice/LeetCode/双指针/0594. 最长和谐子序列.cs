namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0594
{
    public static void Test()
    {
        LeetCode_0594 obj = new LeetCode_0594();
        Console.WriteLine(obj.FindLHS(new []{1,3,2,2,5,2,3,7}));
        Console.WriteLine(obj.FindLHS(new []{1,2,3,4}));
        Console.WriteLine(obj.FindLHS(new []{1,1,1,1}));
    }
    
    public int FindLHS(int[] nums) {
        Array.Sort(nums);
        int max = 0;
        for (int left = 0,right = 0; right < nums.Length; right++)
        {
            while (left < right && nums[right] - nums[left] > 1)
                left++;
            if (nums[right] - nums[left] == 1) 
                max = Math.Max(max, right - left+1);
        }

        return max;
    }
}