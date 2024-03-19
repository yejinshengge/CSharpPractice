namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个整数数组 nums ，判断这个数组中是否存在长度为 3 的递增子序列。

   如果存在这样的三元组下标 (i, j, k) 且满足 i < j < k ，
   使得 nums[i] < nums[j] < nums[k] ，返回 true ；否则，返回 false 。
 */
public class LeetCode_0334
{
    public static void Test()
    {
        LeetCode_0334 obj = new LeetCode_0334();
        Console.WriteLine(obj.IncreasingTriplet(new []{1,2,3,4,5}));
        Console.WriteLine(obj.IncreasingTriplet(new []{5,4,3,2,1}));
        Console.WriteLine(obj.IncreasingTriplet(new []{2,1,5,0,4,6}));
        Console.WriteLine(obj.IncreasingTriplet(new []{20,100,10,12,5,13}));
    }
    
    public bool IncreasingTriplet(int[] nums)
    {
        return _lengthOfLIS(nums) >= 3;
    }

    // 最长上升子序列
    private int _lengthOfLIS(int[] nums)
    {
        // 存储堆顶的牌
        int[] top = new int[nums.Length];
        // 堆数
        int piles = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            var curNum = nums[i];
            // 二分法查找第一个比自己大的堆
            int left = 0, right = piles;
            while (left < right)
            {
                int mid = (left + right) >> 1;
                if (curNum > top[mid])
                    left = mid + 1;
                else if (curNum <= top[mid])
                    right = mid;
            }
            
            // 如果没找到,新建一个堆
            if (left == piles) piles++;
            top[left] = curNum;
        }

        return piles;
    }
}