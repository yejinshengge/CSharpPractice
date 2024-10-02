namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR076
{
    public static void Test()
    {
        LeetCode_LCR076 obj = new LeetCode_LCR076();
        Console.WriteLine(obj.FindKthLargest(new []{3,2,1,5,6,4},2));
        Console.WriteLine(obj.FindKthLargest(new []{3,2,3,1,2,4,5,5,6},4));
    }
    
    public int FindKthLargest(int[] nums, int k)
    {
        int target = nums.Length - k;
        int start = 0, end = nums.Length - 1;
        int index = _partition(nums, start, end);
        while (target!= index)
        {
            if (target < index)
                end = index-1;
            else if (target > index)
                start = index+1;
            index =  _partition(nums, start, end);
        }
        return nums[target];
    }

    private int _partition(int[] nums, int left, int right)
    {
        int smallP = left - 1;
        int bigP = right;
        int random = new Random().Next(left, right);
        (nums[right], nums[random]) = (nums[random], nums[right]);

        while (left < bigP)
        {
            if (nums[left] > nums[right])
            {
                (nums[left], nums[bigP - 1]) = (nums[bigP - 1], nums[left]);
                bigP--;
            }
            else if (nums[left] < nums[right])
            {
                (nums[left], nums[smallP + 1]) = (nums[smallP + 1], nums[left]);
                smallP++;
                left++;
            }
            else
                left++;
        }

        (nums[bigP], nums[right]) = (nums[right], nums[bigP]);

        return smallP + 1;
    }
}