namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 对于一个整数数组 nums，逆序对是一对满足 0 <= i < j < nums.length 且 nums[i] > nums[j]的整数对 [i, j] 。

    给你两个整数 n 和 k，找出所有包含从 1 到 n 的数字，且恰好拥有 k 个 逆序对 的不同的数组的个数。
    由于答案可能很大，只需要返回对 109 + 7 取余的结果。
 */
public class LeetCode_0629
{
    public static void Test()
    {
        LeetCode_0629 obj = new LeetCode_0629();
        Console.WriteLine(obj.KInversePairs(3,0));
        Console.WriteLine(obj.KInversePairs(3,1));
        Console.WriteLine(obj.KInversePairs(1000,1000));
    }
    
    public int KInversePairs(int n, int k)
    {
        const int MOD = 1000000007;
        int[,] dp = new int[n + 1, k + 1];

        dp[0, 0] = 1;
        for (int i = 1; i <= n; i++)
        {
            dp[i, 0] = 1;
            for (int j = 0; j <= k; j++)
            {
                dp[i, j] = dp[i - 1, j];
                if (j >= 1)
                    dp[i, j] = (dp[i, j] + dp[i, j - 1])%MOD;
                if( j >= i)
                    dp[i, j] = (dp[i, j] - dp[i - 1, j - i] + MOD)%MOD;
            }
        }

        return dp[n, k];
    }
}