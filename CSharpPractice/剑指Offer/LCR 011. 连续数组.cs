namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR011
{
    public static void Test()
    {
        LeetCode_LCR011 obj = new LeetCode_LCR011();
        Console.WriteLine(obj.FindMaxLength(new []{0,1}));
        Console.WriteLine(obj.FindMaxLength(new []{0,1,0}));
    }
    
    public int FindMaxLength1(int[] nums)
    {
        int[] zero = new int[nums.Length + 1];
        int[] one = new int[nums.Length + 1];

        for (int i = 1; i <= nums.Length; i++)
        {
            zero[i] = zero[i - 1] + (nums[i - 1] == 0 ? 1 : 0);
            one[i] = one[i - 1] + (nums[i - 1] == 1 ? 1 : 0);
        }

        int res = 0;
        for (int i = 0; i < zero.Length; i++)
        {
            for (int j = i+1; j < zero.Length; j++)
            {
                if (zero[j] - zero[i] == one[j] - one[i])
                    res = Math.Max(res, j - i);
            }
        }

        return res;
    }

    public int FindMaxLength(int[] nums)
    {
        Dictionary<int, int> dic = new();
        dic[0] = -1;

        int sum = 0;
        int res = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i] == 0 ? -1 : 1;
            if (dic.TryGetValue(sum, out var index))
                res = Math.Max(res, i - index);
            else
                dic[sum] = i;
        }

        return res;
    }
}