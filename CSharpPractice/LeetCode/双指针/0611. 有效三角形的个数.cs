namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0611
{
    public static void Test()
    {
        LeetCode_0611 obj = new LeetCode_0611();
        Console.WriteLine(obj.TriangleNumber(new []{2,2,3,4}));
        Console.WriteLine(obj.TriangleNumber(new []{4,2,3,4}));
    }
    
    public int TriangleNumber(int[] nums)
    {
        if (nums.Length < 3) return 0;
        Array.Sort(nums);
        int count = 0;

        for (int i = nums.Length-1; i > 1; i--)
        {
            if(nums[i-2] + nums[i-1] <= nums[i]) continue;
            int left = 0, right = i - 1;
            while (left < right)
            {
                if (nums[left] + nums[right] > nums[i])
                {
                    count += right - left;
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }

        return count;
    }
}