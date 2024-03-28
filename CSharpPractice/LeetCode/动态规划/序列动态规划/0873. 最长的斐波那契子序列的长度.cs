namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 如果序列 X_1, X_2, ..., X_n 满足下列条件，就说它是 斐波那契式 的：

    n >= 3
    对于所有 i + 2 <= n，都有 X_i + X_{i+1} = X_{i+2}
    给定一个严格递增的正整数数组形成序列 arr ，找到 arr 中最长的斐波那契式的子序列的长度。如果一个不存在，返回  0 。

    （回想一下，子序列是从原序列 arr 中派生出来的，它从 arr 中删掉任意数量的元素（也可以不删），而不改变其余元素的顺序。
    例如， [3, 5, 8] 是 [3, 4, 5, 6, 7, 8] 的一个子序列）
 */
public class LeetCode_0873
{
    public static void Test()
    {
        LeetCode_0873 obj = new LeetCode_0873();
        Console.WriteLine(obj.LenLongestFibSubseq(new []{1,2,3,4,5,6,7,8}));
        Console.WriteLine(obj.LenLongestFibSubseq(new []{1,3,7,11,12,14,18}));
        Console.WriteLine(obj.LenLongestFibSubseq(new []{1,5,6,7,10,12,17,24,41,65}));
    }
    
    public int LenLongestFibSubseq(int[] arr)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>(arr.Length);
        int[,] dp = new int[arr.Length + 1,arr.Length + 1];
        int maxLen = 0;
        for (int i = 1; i <= arr.Length; i++)
        {
            dic[arr[i-1]] = i;
            for (int j = i-1; j >= 1 && arr[j-1]*2 > arr[i-1]; j--)
            {
                int diff = arr[i - 1] - arr[j - 1];
                if (dic.TryGetValue(diff, out var index))
                    dp[i,j] = Math.Max(dp[j,index] + 1, 3);
                maxLen = Math.Max(maxLen, dp[i, j]);
            }
        }

        return maxLen;
    }
}