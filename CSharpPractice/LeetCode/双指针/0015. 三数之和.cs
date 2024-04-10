using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0015
{
    public static void Test()
    {
        LeetCode_0015 obj = new LeetCode_0015();
        Tools.PrintEnumerator(obj.ThreeSum(new []{-1,0,1,2,-1,-4}));
        Tools.PrintEnumerator(obj.ThreeSum(new []{0,1,1}));
        Tools.PrintEnumerator(obj.ThreeSum(new []{0,0,0}));
    }
    
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            // 与上次枚举的元素一样
            if(i > 0 && nums[i] == nums[i-1]) continue;

            int k = nums.Length-1;
            for (int j = i+1; j < nums.Length; j++)
            {
                // 与上次枚举不一样
                if(j > i+1 && nums[j] == nums[j-1])continue;
                // 找满足条件的组合
                while (j < k && nums[i] + nums[j] + nums[k] > 0)
                {
                    k--;
                }
                // 没找到，直接进行下一轮
                if(j == k) break;
                // 找到了
                if (nums[i] + nums[j] + nums[k] == 0)
                {
                    List<int> list = new List<int>();
                    list.Add(nums[i]);
                    list.Add(nums[j]);
                    list.Add(nums[k]);
                    res.Add(list);
                }
            }
        }

        return res;
    }
}