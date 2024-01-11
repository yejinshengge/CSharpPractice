using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个整数 n ，对于 0 &lt;= i &lt;= n 中的每个 i ，
 * 计算其二进制表示中 1 的个数 ，返回一个长度为 n + 1 的数组 ans 作为答案。
 */
public class LeetCode_0338
{
    public static void Test()
    {
        LeetCode_0338 obj = new LeetCode_0338();
        Tools.PrintArr(obj.CountBits2(2));
        Tools.PrintArr(obj.CountBits2(5));
    }
    
    public int[] CountBits(int n)
    {
        int[] res = new int[n+1];
        for (int i = 0; i <= n; i++)
        {
            int x = i;
            while (x>0)
            {
                // 将最后一个1变成0
                x &= (x - 1);
                res[i]++;
            }
        }

        return res;
    }

    public int[] CountBits2(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            // 偶数 x 跟x/2中1的个数相同
            if (i % 2 == 0)
                dp[i] = dp[i >> 1];
            // 奇数 x 比前一个偶数x-1 多一个1
            else
                dp[i] = dp[i - 1] + 1;
        }

        return dp;
    }
}