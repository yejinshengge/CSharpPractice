namespace CSharpPractice.LeetCode.哈希表篇.四数相加;
/**
给你一个整数数组 nums ，判断是否存在三元组 [nums[i], nums[j], nums[k]] 
满足 i != j、i != k 且 j != k ，同时还满足 nums[i] + nums[j] + nums[k] == 0 。
请你返回所有和为 0 且不重复的三元组。
 */
public class LeetCode_0015
{
    public static void Test()
    {
        LeetCode_0015 obj = new LeetCode_0015();
        var res1 = obj.ThreeSum2(new[] { -1, 0, 1, 2, -1, -4 });
        var res2 = obj.ThreeSum2(new[] {0,1,1 });
        var res3 = obj.ThreeSum2(new[] {0,0,0});
    }
    // 思路一:先将元素全加入字典,再遍历寻找和为0的组合
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            dic.Add(nums[i],i);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                var sum = nums[i] + nums[j];
                if(dic.ContainsKey(-sum)&&dic[-sum] != i && dic[-sum] != j)
                    res.Add(new List<int>(){i,j,dic[-sum]});
            }
        }

        return res;
    }
    
    // 思路二:双指针
    public IList<IList<int>> ThreeSum2(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        
        for (int i = 0; i < nums.Length; i++)
        {
            if(i>0&&nums[i] == nums[i-1])
                continue;
            int k = nums.Length - 1;
            for (int j = i+1; j < nums.Length; j++)
            {
                if(j > i+1 && nums[j] == nums[j-1])
                    continue;
                
                while (j<k&&nums[j] + nums[k]>-nums[i])
                {
                    k--;
                }
                if(j==k) break;
                if(nums[j] + nums[k] == -nums[i])
                    res.Add(new List<int>(){nums[i],nums[j],nums[k]});
            }
        }

        return res;
    }
}