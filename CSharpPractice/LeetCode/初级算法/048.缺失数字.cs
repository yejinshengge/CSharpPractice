namespace CSharpPractice.LeetCode.初级算法;

// 给定一个包含 [0, n] 中 n 个数的数组 nums ，找出 [0, n] 这个范围内没有出现在数组中的那个数。
public class LeetCode_048
{
    public static void Test()
    {
        LeetCode_048 obj = new LeetCode_048();
        Console.WriteLine(obj.MissingNumber1(new []{0}));
    }
    
    // 二分法
    public int MissingNumber(int[] nums)
    {
        Array.Sort(nums);
        int left = 0;
        int right = nums.Length - 1;

        if (nums[right] < right + 1) return right + 1;
        
        while (left < right)
        {
            int mid = (left+right) / 2;
            if (nums[mid] == mid)
                left = mid+1;
            else
                right = mid;
        }

        return left;
    }

    // 思路二:位运算
    public int MissingNumber1(int[] nums)
    {
        int xor = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            xor ^= nums[i] ^ i;
        }

        xor ^= nums.Length;
        return xor;

    }
}