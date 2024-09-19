namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR070
{
    public static void Test()
    {
        LeetCode_LCR070 obj = new LeetCode_LCR070();
        Console.WriteLine(obj.SingleNonDuplicate(new []{1,1,2,3,3,4,4,8,8}));
        Console.WriteLine(obj.SingleNonDuplicate(new []{1,1,2,2,3,3,4,4,8}));
    }
    
    public int SingleNonDuplicate(int[] nums)
    {
        int left = 0, right = nums.Length / 2;
        while (left<=right)
        {
            int mid = (left + right) >> 1;
            int index = mid * 2;
            if (index < nums.Length - 1 && nums[index] != nums[index + 1])
            {
                if (mid == 0 || nums[index - 2] == nums[index - 1])
                    return nums[index];
                right = mid - 1;
            }
            else
                left = mid + 1;
        }

        return nums[^1];
    }
}