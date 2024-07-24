namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR008
{
    public static void Test()
    {
        LeetCode_LCR008 obj = new LeetCode_LCR008();
        Console.WriteLine(obj.MinSubArrayLen(7,new []{2,3,1,2,4,3}));
        Console.WriteLine(obj.MinSubArrayLen(4,new []{1,4,4}));
        Console.WriteLine(obj.MinSubArrayLen(11,new []{1,1,1,1,1,1,1,1}));
    }
    
    public int MinSubArrayLen1(int target, int[] nums)
    {
        int left = 0, right = 0;
        int sum = 0;
        int minLen = int.MaxValue;
        while (left <= right && right < nums.Length)
        {
            if (left == right) sum = nums[left];
            if (sum >= target)
            {
                minLen = Math.Min(minLen, right - left + 1);
                sum -= nums[left];
                left++;
            }
            else
            {
                right++;
                if(right < nums.Length)
                    sum += nums[right];
            }
            
        }

        return minLen == int.MaxValue ? 0:minLen;
    }

    public int MinSubArrayLen(int target, int[] nums)
    {
        int[] sum = new int[nums.Length+1];
        for (int i = 1; i <= nums.Length; i++)
        {
            sum[i] = sum[i - 1] + nums[i-1];
        }

        int minLen = int.MaxValue;
        for (int i = 1; i <= nums.Length; i++)
        {
            int realTarget = target + sum[i-1];

            int left = i, right = nums.Length;
            while (left < right)
            {
                int mid = (left + right) >> 1;
                if (sum[mid] >= realTarget)
                    right = mid;
                else
                    left = mid + 1;
            }

            if (sum[left] >= realTarget)
                minLen = Math.Min(minLen, left - i + 1);
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }
}