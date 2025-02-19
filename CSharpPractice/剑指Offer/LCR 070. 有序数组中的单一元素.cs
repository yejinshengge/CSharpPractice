namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR070
{
    public static void Test()
    {
        LeetCode_LCR070 obj = new LeetCode_LCR070();
        Console.WriteLine(obj.SingleNonDuplicate(new []{1,1,2,3,3,4,4,8,8}));
        Console.WriteLine(obj.SingleNonDuplicate(new []{1,1,2,2,3,3,4,4,8}));
    }
    
    public int SingleNonDuplicate(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        // <= 适用于查找区间/边界
        // <> 适用于查找具体值
        while (left < right)
        {
            int mid = (left + right) >> 1;
            // 当前下标为奇数,向前挪一位变成偶数
            if (mid % 2 == 1) mid--;
            // 当前位和后一位能凑一对,说明规律没被打破
            if (nums[mid] == nums[mid + 1])
                left = mid + 2;
            else
                right = mid;
        }

        return nums[left];
    }
}