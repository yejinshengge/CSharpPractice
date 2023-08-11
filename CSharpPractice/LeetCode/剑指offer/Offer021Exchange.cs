namespace CSharpPractice.LeetCode;

public class Offer021Exchange
{
    public int[] Exchange(int[] nums)
    {
        if (nums == null || nums.Length <= 1)
            return nums;
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            // 奇数,左指针右移
            if (nums[left] % 2 == 1)
            {
                left++;
            }
            // 偶数,交换,右指针左移
            else
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                right--;
            }
        }
        return nums;
    }

    public static void Offer021ExchangeMain()
    {
        Offer021Exchange obj = new();
        int[] nums = {1, 2, 3, 4};
        obj.Exchange(nums);
        Console.WriteLine(nums);
    }
}