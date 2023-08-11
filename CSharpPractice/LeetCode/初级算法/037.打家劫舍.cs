namespace CSharpPractice.LeetCode.初级算法;

/**
 * 你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，
 * 如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。
 * 给定一个代表每个房屋存放金额的非负整数数组，计算你 不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。
 */
public class LeetCode_037
{
    public static void Test()
    {
        LeetCode_037 obj = new LeetCode_037();
        Console.WriteLine(obj.Rob3(new []{2,7,9,3,1}));
    }
    
    // 思路一:暴力递归,超时
    public int Rob(int[] nums)
    {
        return Process(nums, 0);
    }

    private int Process(int[] nums, int index)
    {
        if (index >= nums.Length) return 0;
        return Math.Max(nums[index] + Process(nums, index + 2), Process(nums, index + 1));
    }

    // 思路二:动态规划
    public int Rob2(int[] nums)
    {
        // 0没偷,1偷了
        int[,] dp = new int[nums.Length,2];
        dp[0, 0] = 0;
        dp[0, 1] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            // 第i天没偷,前一天可以偷也可以不偷
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
            // 第i天偷了,前一天必没偷
            dp[i, 1] = dp[i - 1, 0] + nums[i];
        }

        return Math.Max(dp[nums.Length - 1, 0], dp[nums.Length - 1, 1]);
    }

    // 动态规划优化
    public int Rob3(int[] nums)
    {
        int unStolen = 0;
        int stolen = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            // 今天没偷,前一天可以偷也可以不偷
            int unStolenToday = Math.Max(unStolen, stolen);
            // 今天偷了,昨天必没偷
            stolen = unStolen + nums[i];
            unStolen = unStolenToday;
        }

        return Math.Max(stolen, unStolen);
    }
}