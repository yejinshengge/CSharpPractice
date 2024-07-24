namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR009
{
    public static void Test()
    {
        LeetCode_LCR009 obj = new LeetCode_LCR009();
        Console.WriteLine(obj.NumSubarrayProductLessThanK(new []{10,5,2,6},100));
        Console.WriteLine(obj.NumSubarrayProductLessThanK(new []{1,2,3},0));
    }
    
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        int left = 0, product = 1, sum = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            product *= nums[right];
            while (left <= right && product >= k)
            {
                product /= nums[left++];
            }

            sum += left <= right ? right - left + 1:0;
        }

        return sum;
    }
}