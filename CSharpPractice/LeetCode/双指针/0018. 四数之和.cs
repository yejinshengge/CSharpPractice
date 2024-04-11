using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个由 n 个整数组成的数组 nums ，和一个目标值 target 。请你找出并返回满足下述全部条件且不重复的四元组 [nums[a], nums[b], nums[c], nums[d]] （若两个四元组元素一一对应，则认为两个四元组重复）：

    0 <= a, b, c, d < n
    a、b、c 和 d 互不相同
    nums[a] + nums[b] + nums[c] + nums[d] == target
    你可以按 任意顺序 返回答案 。
 */
public class LeetCode_0018
{
    public static void Test()
    {
        LeetCode_0018 obj = new LeetCode_0018();
        Tools.PrintEnumerator(obj.FourSum(new []{1,0,-1,0,-2,2},0));
        Tools.PrintEnumerator(obj.FourSum(new []{2,2,2,2,2},8));
        Tools.PrintEnumerator(obj.FourSum(new []{1000000000,1000000000,1000000000,1000000000},-294967296));
    }
    
    public IList<IList<int>> FourSum(int[] nums, int target) {
        Array.Sort(nums);
        List<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i < nums.Length-3; i++)
        {
            if(i > 0 && nums[i] == nums[i-1]) continue;
            if((long)nums[i] + nums[i+1] + nums[i+2] + nums[i+3] > target) break;
            if((long)nums[i] + nums[^1] + nums[^2] + nums[^3] < target) continue;
            
            for (int j = i+1; j < nums.Length-2; j++)
            {
                if(j > i+1 && nums[j] == nums[j-1]) continue;
                if((long)nums[i] + nums[j] + nums[j+1] + nums[j+2] > target) break;
                if((long)nums[i] + nums[j] + nums[^1] + nums[^2] < target) continue;
                
                int k = j + 1, l = nums.Length - 1;
                while (k < l)
                {
                    if (k > j + 1 && nums[k] == nums[k - 1])
                    {
                        k++;
                        continue;
                    }
                    
                    if (l < nums.Length - 1 && nums[l] == nums[l+1])
                    {
                        l--;
                        continue;
                    }
                    long sum = (long)nums[i] + nums[j] + nums[k] + nums[l];
                    if (sum == target)
                    {
                        List<int> num = new List<int>();
                        num.Add(nums[i]);
                        num.Add(nums[j]);
                        num.Add(nums[k]);
                        num.Add(nums[l]);
                        res.Add(num);
                        k++;
                        l--;
                    }
                    else if (sum < target)
                    {
                        k++;
                    }
                    else
                    {
                        l--;
                    }
                        
                }
            }
        }

        return res;
    }
}