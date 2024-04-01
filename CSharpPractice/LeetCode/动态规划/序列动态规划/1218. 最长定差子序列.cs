namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个整数数组 arr 和一个整数 difference，请你找出并返回 arr 中最长等差子序列的长度，
 * 该子序列中相邻元素之间的差等于 difference 。

   子序列 是指在不改变其余元素顺序的情况下，通过删除一些元素或不删除任何元素而从 arr 派生出来的序列。
 */
public class LeetCode_1218
{
    public static void Test()
    {
        LeetCode_1218 obj = new LeetCode_1218();
        Console.WriteLine(obj.LongestSubsequence(new []{1,2,3,4},1));
        Console.WriteLine(obj.LongestSubsequence(new []{1,3,5,7},1));
        Console.WriteLine(obj.LongestSubsequence(new []{1,5,7,8,5,3,4,2,1},-2));
    }
    
    public int LongestSubsequence(int[] arr, int difference)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int maxLen = 0;
        for (int i = 1; i <= arr.Length; i++)
        {
            if (dic.ContainsKey(arr[i - 1] - difference))
            {
                dic[arr[i - 1]] = dic[arr[i - 1] - difference] + 1;
            }
            else
            {
                dic[arr[i - 1]] = 1;
            }

            maxLen = Math.Max(maxLen, dic[arr[i-1]]);
        }

        return maxLen;
    }
    
    // 超时
    public int LongestSubsequence2(int[] arr, int difference) {
        int[] dp = new int[arr.Length + 1];
        int maxLen = 0;
        for (int i = 1; i <= arr.Length; i++)
        {
            dp[i] = 1;
            for (int j = 1; j < i; j++)
            {
                if(arr[i-1] - arr[j-1] == difference)
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }

            maxLen = Math.Max(maxLen, dp[i]);
        }

        return maxLen;
    }
}