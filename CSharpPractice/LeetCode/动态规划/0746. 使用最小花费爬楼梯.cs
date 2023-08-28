namespace CSharpPractice.LeetCode.动态规划;

/**
给你一个整数数组 cost ，其中 cost[i] 是从楼梯第 i 个台阶向上爬需要支付的费用。
一旦你支付此费用，即可选择向上爬一个或者两个台阶。
你可以选择从下标为 0 或下标为 1 的台阶开始爬楼梯。
请你计算并返回达到楼梯顶部的最低花费。
 */
public class LeetCode_0746
{
    public static void Test()
    {
        LeetCode_0746 obj = new LeetCode_0746();
        Console.WriteLine(obj.MinCostClimbingStairs(new []{1,100,1,1,1,100,1,1,100,1}));
    }
    
    public int MinCostClimbingStairs(int[] cost)
    {
        int dp1 = 0;
        int dp2 = 0;
        for (int i = 2; i <= cost.Length; i++)
        {
            int tmp = Math.Min(dp1+cost[i-2], dp2+cost[i-1]);
            dp1 = dp2;
            dp2 = tmp;
        }
        return dp2;
    }
}