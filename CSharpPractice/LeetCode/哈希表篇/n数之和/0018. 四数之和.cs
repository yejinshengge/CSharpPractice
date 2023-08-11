namespace CSharpPractice.LeetCode.哈希表篇.四数相加;

/**
给你一个由 n 个整数组成的数组nums ，和一个目标值 target 。请你找出并返回满足下述全部条件且不重复的四元组
[nums[a], nums[b], nums[c], nums[d]]（若两个四元组元素一一对应，则认为两个四元组重复）：
0 <= a, b, c, d< n
a、b、c 和 d 互不相同
nums[a] + nums[b] + nums[c] + nums[d] == target
你可以按 任意顺序 返回答案 

 */
public class LeetCode_0018
{
    public static void Test()
    {
        LeetCode_0018 obj = new LeetCode_0018();
        Console.WriteLine(Math.Log10(long.MaxValue));
        var res1 = obj.FourSum(new[] { 1, 0, -1, 0, -2, 2 }, 0);
    }
    
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        int len = nums.Length;
        
        for (int i = 0; i < len-3; i++)
        {
            // 过滤重复项
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            // 剪枝
            if (nums[i] + nums[i + 1] > target - nums[i + 2] - nums[i + 3]) break;
            if(nums[i] + nums[len-1] < target - nums[len-2] - nums[len-3]) continue;

            for (int j = i+1; j < len-2; j++)
            {
                // 过滤重复项
                if(j > i+1 && nums[j] == nums[j-1]) continue;
                // 剪枝
                if (nums[i] + nums[j]  > target - nums[j + 1] - nums[j + 2]) break;
                if(nums[i] + nums[j]  < target - nums[len-1] - nums[len-2]) continue;
                
                // 双指针
                int left = j + 1;
                int right = len - 1;
                while (left < right)
                {
                    long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];
                    if (sum == target)
                    {
                        res.Add(new List<int>(){nums[i],nums[j] , nums[left] , nums[right]});
                        // 过滤重复项
                        while (left<right && nums[left] == nums[left+1])
                        {
                            left++;
                        }
                        left++;
                        while (left<right && nums[right] == nums[right-1])
                        {
                            right--;
                        }
                        right--;
                    }
                    else if (sum > target)
                        right--;
                    else
                        left++;
                }
            }
        }
        
        return res;
    }
}