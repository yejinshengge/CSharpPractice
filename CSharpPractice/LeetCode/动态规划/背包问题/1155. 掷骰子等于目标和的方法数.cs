namespace CSharpPractice.LeetCode.动态规划.背包问题;

/**
 * 这里有 n 个一样的骰子，每个骰子上都有 k 个面，分别标号为 1 到 k 。
    
    给定三个整数 n、k 和 target，请返回投掷骰子的所有可能得到的结果（共有 kn 种方式），使得骰子面朝上的数字总和等于 target。
    
    由于答案可能很大，你需要对 109 + 7 取模。
 */
public class LeetCode_1155
{
    public static void Test()
    {
        LeetCode_1155 obj = new LeetCode_1155();
        Console.WriteLine(obj.NumRollsToTarget2(1,6,3));
        Console.WriteLine(obj.NumRollsToTarget2(2,6,7));
        Console.WriteLine(obj.NumRollsToTarget2(30,30,500));
    }
    const int MOD = 1000000007;
    public int NumRollsToTarget(int n, int k, int target)
    {
        int[,] dp = new int[n+1,target+1];
        dp[0, 0] = 1;
        // 枚举骰子
        for (int num = 1; num <= n; num++)
        {
            // 枚举目标值
            for (int tar = 0; tar <= target; tar++)
            {
                // 枚举点数
                for (int point = 1; point <= k; point++)
                {
                    if (tar - point >= 0)
                        dp[num, tar] = (dp[num, tar] + dp[num - 1, tar - point]) % MOD;
                }
            }
        }

        return dp[n, target];
    }
    
    public int NumRollsToTarget2(int n, int k, int target)
    {
        int[] dp = new int[target+1];
        dp[0] = 1;
        // 枚举骰子
        for (int num = 1; num <= n; num++)
        {
            // 枚举目标值
            for (int tar = target; tar >=0; tar--)
            {
                dp[tar] = 0;
                // 枚举点数
                for (int point = 1; point <= k; point++)
                {
                    if (tar - point >= 0)
                        dp[tar] = (dp[tar] + dp[tar - point]) % MOD;
                }
            }
        }

        return dp[target];
    }
}