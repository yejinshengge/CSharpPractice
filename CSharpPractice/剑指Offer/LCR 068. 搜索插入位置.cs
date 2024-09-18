namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR068
{
    public static void Test()
    {
        LeetCode_LCR068 obj = new LeetCode_LCR068();
        Console.WriteLine(obj.SearchInsert(new []{1,3,5,6},5));
        Console.WriteLine(obj.SearchInsert(new []{1,3,5,6},2));
        Console.WriteLine(obj.SearchInsert(new []{1,3,5,6},7));
        Console.WriteLine(obj.SearchInsert(new []{1,3,5,6},0));
        Console.WriteLine(obj.SearchInsert(new []{1},0));
    }
    
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length;
        while (left < right)
        {
            int mid = (left + right) >> 1;
            if (nums[mid] == target)
                return mid;
            if (nums[mid] > target)
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}