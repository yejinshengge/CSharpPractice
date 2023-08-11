namespace CSharpPractice.LeetCode;

public class Offer003FindRepeatNumber
{
    public static void Offer003FindRepeatNumberMain()
    {
        Offer003FindRepeatNumber obj = new();
        int[] nums = {0, 1, 2, 0, 4, 5, 6, 7, 8, 9};
        Console.WriteLine(obj.FindRepeatNumber3(nums));
    }
    public int FindRepeatNumber(int[] nums)
    {
        HashSet<int> hashSet = new();
        for (int i = 0; i < nums.Length; i++)
        {
            if (hashSet.Contains(nums[i]))
                return nums[i];
            hashSet.Add(nums[i]);
        }
        return -1;
    }
    
    public int FindRepeatNumber2(int[] nums)
    {
        int index = 0;
        while (index < nums.Length)
        {
            // 如果当前元素与下标相同,则指针后移
            if (nums[index] == index)
            {
                index++;
                continue;
            }
            // 当前元素与其对应下标位置元素相同,说明遇到了重复值,直接返回
            if (nums[index] == nums[nums[index]])
                return nums[index];
            // 不满足以上条件则交换
            (nums[nums[index]], nums[index]) = (nums[index], nums[nums[index]]);
        }
        return -1;
    }

    public int FindRepeatNumber3(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = (left + right) / 2;
            int count = 0;
            // 查找位于此区间内的元素个数
            foreach (var num in nums)
            {
                if (num >= left && num <= mid)
                {
                    count++;
                }
            }
            // 如果数量大于区间长度,说明有重复
            if (count > mid - left + 1)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}