namespace CSharpPractice.LeetCode.动态规划;

/**
假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
 */
public class LeetCode_0070
{
    public static void Test()
    {
        LeetCode_0070 obj = new LeetCode_0070();
        Console.WriteLine(obj.ClimbStairs(4));
    }
    
    public int ClimbStairs(int n) {
        if (n == 0) return 0;
        if (n == 1) return 1;
        int dp1 = 1;
        int dp2 = 2;
        for (int i = 2; i < n; i++)
        {
            int sum = dp1 + dp2;
            dp1 = dp2;
            dp2 = sum;
        }

        return dp2;
    }
}