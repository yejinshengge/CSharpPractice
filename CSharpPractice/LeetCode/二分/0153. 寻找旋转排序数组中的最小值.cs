namespace CSharpPractice.LeetCode.二分;

public class LeetCode_0153
{
    public static void Test()
    {
        LeetCode_0153 obj = new LeetCode_0153();
        Console.WriteLine(obj.FindMin(new []{3,4,5,1,2}));
        Console.WriteLine(obj.FindMin(new []{4,5,6,7,0,1,2}));
        Console.WriteLine(obj.FindMin(new []{11,13,15,17}));
        Console.WriteLine(obj.FindMin(new []{11}));
        Console.WriteLine(obj.FindMin(new []{5,1,2,3,4}));
        Console.WriteLine(obj.FindMin(new []{3,1,2}));
    }
    
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + right >> 1;
            if (nums[right] < nums[mid])
                left = mid + 1;
            else
                right = mid;
        }

        return nums[left];
    }
}