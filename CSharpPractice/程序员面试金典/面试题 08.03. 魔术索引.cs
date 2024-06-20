namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_03
{
    public static void Test()
    {
        LeetCode_08_03 obj = new LeetCode_08_03();
        Console.WriteLine(obj.FindMagicIndex(new []{0, 2, 3, 4, 5}));
        Console.WriteLine(obj.FindMagicIndex(new []{1, 1, 1}));
    }
    
    public int FindMagicIndex1(int[] nums)
    {
        return _find(nums, 0, nums.Length - 1);
    }

    private int _find(int[] nums, int left, int right)
    {
        if (left > right) return -1;
        int mid = (left - right) / 2 + right;
        var leftAnswer = _find(nums,left,mid-1);
        if (leftAnswer != -1)
            return leftAnswer;
        if (nums[mid] == mid)
            return mid;
        return _find(nums,mid+1,right);
    }
    
    public int FindMagicIndex(int[] nums)
    {
        for (int i = 0; i < nums.Length;)
        {
            if (i == nums[i])
                return i;
            i = Math.Max(i + 1, nums[i]);
        }

        return -1;
    }
}