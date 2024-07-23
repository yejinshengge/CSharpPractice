using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR007
{
    public static void Test()
    {
        LeetCode_LCR007 obj = new LeetCode_LCR007();
        Tools.PrintEnumerator(obj.ThreeSum(new []{-1,0,1,2,-1,-4}));
        Tools.PrintEnumerator(obj.ThreeSum(Array.Empty<int>()));
        Tools.PrintEnumerator(obj.ThreeSum(new []{0}));
        Tools.PrintEnumerator(obj.ThreeSum(new []{0,0,0,0}));
        Tools.PrintEnumerator(obj.ThreeSum(new []{-2,0,0,2,2}));
    }
    
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> res = new List<IList<int>>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            if(i > 0 && nums[i] == nums[i-1]) continue;
            int cur = nums[i];
            int left = i+1, right = nums.Length - 1;
            while (left < right)
            {
                if (left > i + 1 && nums[left] == nums[left - 1])
                {
                    left++;
                    continue;
                }

                if (right < nums.Length - 1 && nums[right] == nums[right + 1])
                {
                    right--;
                    continue;
                }
                if (nums[left] + nums[right] > -cur)
                    right--;
                else if (nums[left] + nums[right] < -cur)
                    left++;
                else
                {
                    res.Add(new List<int>(){cur,nums[left],nums[right]});
                    left++;
                    right--;
                }
            }
        }
        return res;
    }
}