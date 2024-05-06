namespace CSharpPractice.LeetCode.二分;

public class LeetCode_0209
{
    public static void Test()
    {
        LeetCode_0209 obj = new LeetCode_0209();
        Console.WriteLine(obj.MinSubArrayLen(7,new []{2,3,1,2,4,3}));
        Console.WriteLine(obj.MinSubArrayLen(4,new []{1,4,4}));
        Console.WriteLine(obj.MinSubArrayLen(11,new []{1,1,1,1,1,1,1,1}));
        Console.WriteLine(obj.MinSubArrayLen(15,new []{1,2,3,4,5}));
    }
    
    public int MinSubArrayLen(int target, int[] nums)
    {
        int[] sum = new int[nums.Length+1];
        for (int i = 1; i < sum.Length; i++)
        {
            sum[i] = sum[i - 1] + nums[i-1];
        }

        int res = int.MaxValue;
        for (int i = 0; i < sum.Length; i++)
        {
            int left = 0, right = i;
            while (left < right)
            {
                int mid = left + right + 1 >> 1;
                if (sum[i] - sum[mid] >= target)
                    left = mid;
                else
                    right = mid - 1;
            }

            if (sum[i] - sum[left] >= target) res = Math.Min(res, i - left);
        }

        return res == int.MaxValue ? 0:res;
    }
}