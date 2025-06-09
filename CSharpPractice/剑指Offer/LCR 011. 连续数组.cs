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
        // 计算0和1个数的前缀和
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
                // 判断区间中的0和1数量是否相同
                if (zero[j] - zero[i] == one[j] - one[i])
                    res = Math.Max(res, j - i);
            }
        }

        return res;
    }

    public int FindMaxLength(int[] nums)
    {
        Dictionary<int, int> dic = new();
        // 设置成-1是为了处理开头就满足的情况
        dic[0] = -1;

        int sum = 0;
        int res = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // 把0换成-1
            sum += nums[i] == 0 ? -1 : 1;
            // 遇到相同的前缀和,说明存在数量相同的1和-1
            if (dic.TryGetValue(sum, out var index))
                res = Math.Max(res, i - index);
            else
                dic[sum] = i;
        }

        return res;
    }
}