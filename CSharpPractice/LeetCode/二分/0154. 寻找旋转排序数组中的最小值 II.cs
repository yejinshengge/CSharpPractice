namespace CSharpPractice.LeetCode.二分;

public class LeetCode_0154
{
    public static void Test()
    {
        LeetCode_0154 obj = new LeetCode_0154();
        Console.WriteLine(obj.FindMin(new []{1,3,5}));
        Console.WriteLine(obj.FindMin(new []{2,2,2,0,1}));
        Console.WriteLine(obj.FindMin(new []{0,1,2,2,2,2}));
        Console.WriteLine(obj.FindMin(new []{3,0,1,2,2,2,2}));
        Console.WriteLine(obj.FindMin(new []{1,2,3,0,0,0,0}));
    }
    
    public int FindMin(int[] nums) {
        int low = 0;
        int high = nums.Length - 1;
        while (low < high) {
            int pivot = low + (high - low) / 2;
            if (nums[pivot] < nums[high]) {
                high = pivot;
            } else if (nums[pivot] > nums[high]) {
                low = pivot + 1;
            } else {
                high -= 1;
            }
        }
        return nums[low];
    }
}