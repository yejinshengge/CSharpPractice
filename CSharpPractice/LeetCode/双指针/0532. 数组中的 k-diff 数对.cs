namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0532
{
    public static void Test()
    {
        LeetCode_0532 obj = new LeetCode_0532();
        Console.WriteLine(obj.FindPairs(new []{3, 1, 4, 1, 5},2));
        Console.WriteLine(obj.FindPairs(new []{1, 2, 3, 4, 5},1));
        Console.WriteLine(obj.FindPairs(new []{1, 3, 1, 5, 4},0));
    }
    
    public int FindPairs(int[] nums, int k) {
        Array.Sort(nums);
        int res = 0;
        for (int left = 0,right = 1; left < nums.Length; left++)
        {
            // 重复值right已经处理
            if (left == 0 || nums[left] != nums[left - 1])
            {
                // 寻找符合条件的右指针
                while (right < nums.Length && (right <= left || nums[right] < nums[left] + k))
                    right++;
                if (right < nums.Length && nums[right] == nums[left] + k)
                    res++;
            }
        }

        return res;
    }
}