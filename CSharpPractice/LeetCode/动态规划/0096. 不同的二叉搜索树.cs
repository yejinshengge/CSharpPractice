namespace CSharpPractice.LeetCode.动态规划;

/**
 * 给你一个整数 n ，求恰由 n 个节点组成且节点值从 1 到 n 互不相同的 二叉搜索树 有多少种？返回满足题意的二叉搜索树的种数。
 */
public class LeetCode_0096
{
    public static void Test()
    {
        LeetCode_0096 obj = new LeetCode_0096();
        Console.WriteLine(obj.NumTrees(1));
        Console.WriteLine(obj.NumTrees(2));
        Console.WriteLine(obj.NumTrees(3));
        Console.WriteLine(obj.NumTrees(4));
        Console.WriteLine(obj.NumTrees(5));
    }
    
    public int NumTrees(int n)
    {
        int[] dp = new int[n+1];
        dp[0] = 1;
        dp[1] = 1;
        for (int j = 2; j <= n; j++)
        {
            for (int i = 0; i < j; i++)
            {
                dp[j] += dp[i] * dp[j - i-1];
            }
        }

        return dp[n];
    }
}