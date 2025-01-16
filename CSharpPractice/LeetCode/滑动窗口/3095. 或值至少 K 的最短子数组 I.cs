namespace CSharpPractice.LeetCode.数组篇.滑动窗口;

public class LeetCode_3095
{
    public static void Test()
    {
        LeetCode_3095 obj = new LeetCode_3095();
        Console.WriteLine(obj.MinimumSubarrayLength(new []{1,2,3},2));
        Console.WriteLine(obj.MinimumSubarrayLength(new []{2,1,8},10));
        Console.WriteLine(obj.MinimumSubarrayLength(new []{1,2},0));
        Console.WriteLine(obj.MinimumSubarrayLength(new []{1,2,11,15,13,32},34));
    }
    
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        int[] bits = new int[7];
        int minLen = int.MaxValue;
        for (int left = 0,right = 0; right < nums.Length; right++)
        {
            for (int i = 0; i < 7; i++)
            {
                bits[i] += (nums[right] >> i) & 1;
            }

            while (left <= right && _cal(bits) >= k)
            {
                minLen = Math.Min(minLen, right - left + 1);
                for (int i = 0; i < 7; i++)
                {
                    bits[i] -= (nums[left] >> i) & 1;
                }
                left++;
            }
            
        }

        return minLen == int.MaxValue ? -1 : minLen;
    }

    private int _cal(int[] bits)
    {
        int res = 0;
        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i] > 0)
                res |= 1 << i;
        }

        return res;
    }
}