using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个由 无重复 正整数组成的集合 nums ，请你找出并返回其中最大的整除子集 answer ，子集中每一元素对 (answer[i], answer[j]) 都应当满足：
    answer[i] % answer[j] == 0 ，或
    answer[j] % answer[i] == 0
    如果存在多个有效解子集，返回其中任何一个均可。
 */
public class LeetCode_0368
{
    public static void Test()
    {
        LeetCode_0368 obj = new LeetCode_0368();
        Tools.PrintEnumerator(obj.LargestDivisibleSubset(new []{1,2,3}));
        Tools.PrintEnumerator(obj.LargestDivisibleSubset(new []{1,2,4,8}));
    }
    
    public IList<int> LargestDivisibleSubset(int[] nums) {
        Array.Sort(nums);
        List<int> res = new List<int>();
        int[] dp = new int[nums.Length];
        int[] map = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            int maxLen = 1, index = 0;
            for (int j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0)
                {
                    if (dp[j] + 1 > maxLen)
                    {
                        maxLen = dp[j] + 1;
                        index = j;
                    }
                }
            }

            dp[i] = maxLen;
            map[i] = index;
        }
        // 找到最大长度
        int realMaxLen = 0, realMaxIndex = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (dp[i] > realMaxLen)
            {
                realMaxLen = dp[i];
                realMaxIndex = i;
            }
        }
        // 利用map数组恢复子集
        while (realMaxLen > 0)
        {
            res.Add(nums[realMaxIndex]);
            realMaxIndex = map[realMaxIndex];
            realMaxLen--;
        }
        return res;
    }
}