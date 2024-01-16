namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * Alice 和 Bob 用几堆石子在做游戏。一共有偶数堆石子，排成一行；每堆都有 正 整数颗石子，数目为 piles[i] 。
    
    游戏以谁手中的石子最多来决出胜负。石子的 总数 是 奇数 ，所以没有平局。
    
    Alice 和 Bob 轮流进行，Alice 先开始 。 每回合，玩家从行的 开始 或 结束 处取走整堆石头。 这种情况一直持续到没有更多的石子堆为止，此时手中 石子最多 的玩家 获胜 。
    
    假设 Alice 和 Bob 都发挥出最佳水平，当 Alice 赢得比赛时返回 true ，当 Bob 赢得比赛时返回 false 。
 */
public class LeetCode_0877
{
    public static void Test()
    {
        LeetCode_0877 obj = new LeetCode_0877();
        Console.WriteLine(obj.StoneGame(new []{5,3,4,5}));
        Console.WriteLine(obj.StoneGame(new []{3,7,2,3}));
    }
    
    public bool StoneGame(int[] piles)
    {
        int[,] dp = new int[piles.Length+2,piles.Length+2];
        // 枚举区间长度
        for (int len = 1; len <= piles.Length; len++)
        {
            // 枚举左端点
            for (int left = 1; left <= piles.Length-len+1; left++)
            {
                // 右端点
                int right = left + len-1;
                dp[left, right] = Math.Max(piles[left-1] - dp[left + 1, right], 
                    piles[right-1] - dp[left, right - 1]);
            }
        }

        return dp[1, piles.Length] > 0;
    }
}