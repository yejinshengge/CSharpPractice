namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个整数数组 nums ，返回 nums 中所有 等差子序列 的数目。

    如果一个序列中 至少有三个元素 ，并且任意两个相邻元素之差相同，则称该序列为等差序列。

    例如，[1, 3, 5, 7, 9]、[7, 7, 7, 7] 和 [3, -1, -5, -9] 都是等差序列。
    再例如，[1, 1, 2, 5, 7] 不是等差序列。
    数组中的子序列是从数组中删除一些元素（也可能不删除）得到的一个序列。

    例如，[2,5,10] 是 [1,2,1,2,4,1,5,10] 的一个子序列。
    题目数据保证答案是一个 32-bit 整数。
 */
public class LeetCode_0446
{
    public static void Test()
    {
        LeetCode_0446 obj = new LeetCode_0446();
        Console.WriteLine(obj.NumberOfArithmeticSlices(new []{2,4,6,8,10}));
        Console.WriteLine(obj.NumberOfArithmeticSlices(new []{7,7,7,7,7}));
    }
    
    public int NumberOfArithmeticSlices(int[] nums)
    {
        List<Dictionary<long, int>> dp = new List<Dictionary<long, int>>();

        var len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            dp.Add(new Dictionary<long, int>());
            for (int j = 0; j < i; j++)
            {
                long key = (long)nums[i] - nums[j];
                dp[j].TryGetValue(key, out int val);
                if (!dp[i].ContainsKey(key))
                    dp[i][key] = 0;
                dp[i][key] += val + 1;
            }
        }
        
        int total = 0;
        for (int i = 0; i < len; i++)
        {
            foreach (var val in dp[i].Values)
            {
                total += val;
            }
        }

        int twoLenCnt = len * (len - 1) / 2;
        return total - twoLenCnt;
    }
}