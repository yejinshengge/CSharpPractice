namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

public class LeetCode_0045
{
    public static void Test()
    {
        LeetCode_0045 obj = new LeetCode_0045();
        Console.WriteLine(obj.Jump(new []{2,3,1,1,4}));
        Console.WriteLine(obj.Jump(new []{2,3,0,1,4}));
    }
    
    public int Jump(int[] nums)
    {
        int[] dp = new int[nums.Length];

        for (int i = 1,j=0; i < nums.Length; i++)
        {
            while (nums[j] + j < i)
            {
                j++;
            }

            dp[i] = dp[j] + 1;
        }

        return dp[nums.Length - 1];
    }
}