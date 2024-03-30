namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给定一个整数数组 arr ，返回 arr 的 最大湍流子数组的长度 。

    如果比较符号在子数组中的每个相邻元素对之间翻转，则该子数组是 湍流子数组 。
 */
public class LeetCode_0978
{
    public static void Test()
    {
        LeetCode_0978 obj = new LeetCode_0978();
        Console.WriteLine(obj.MaxTurbulenceSize2(new []{9,4,2,10,7,8,8,1,9}));
        Console.WriteLine(obj.MaxTurbulenceSize2(new []{4,8,12,16}));
        Console.WriteLine(obj.MaxTurbulenceSize2(new []{100}));
    }
    
    public int MaxTurbulenceSize(int[] arr)
    {
        int[,] dp = new int[arr.Length + 1, 2];
        dp[0, 1] = 1;
        dp[0, 0] = 1;
        int max = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            dp[i, 1] = 1;
            dp[i, 0] = 1;
            if (arr[i] > arr[i - 1])
                dp[i, 0] = dp[i - 1, 1] + 1;
            
            else if (arr[i] < arr[i - 1])
                dp[i, 1] = dp[i - 1, 0] + 1;

            max = Math.Max(Math.Max(dp[i, 0], dp[i, 1]), max);
        }

        return max;
    }
    
    public int MaxTurbulenceSize2(int[] arr)
    {
        int up = 1;
        int down = 1;
        int max = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            int preUp = up;
            int preDown = down;
            up = 1;
            down = 1;
            if (arr[i] > arr[i - 1])
                down = preUp + 1;
            
            else if (arr[i] < arr[i - 1])
                up = preDown + 1;

            max = Math.Max(Math.Max(down, up), max);
        }

        return max;
    }
}