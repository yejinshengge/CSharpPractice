namespace CSharpPractice.LeetCode.二分;

public class LeetCode_0162
{
    public static void Test()
    {
        LeetCode_0162 obj = new LeetCode_0162();
        Console.WriteLine(obj.FindPeakElement(new []{1,2,3,1}));
        Console.WriteLine(obj.FindPeakElement(new []{1,2,1,3,5,6,4}));
    }
    
    public int FindPeakElement(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + right >> 1;
            if (nums[mid] > nums[mid + 1])
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}