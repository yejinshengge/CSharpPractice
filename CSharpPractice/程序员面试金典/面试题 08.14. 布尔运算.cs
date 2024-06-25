namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_14
{
    public static void Test()
    {
        LeetCode_08_14 obj = new LeetCode_08_14();
        Console.WriteLine(obj.CountEval("1^0|0|1",0));
        Console.WriteLine(obj.CountEval("0&0&0&1^1|0",1));
    }
    
    public int CountEval(string s, int result)
    {
        var length = s.Length;
        // 区间i,j结果为k的组合数量
        int[,,] dp = new int[length,length, 2];

        for (int i = 0; i < length; i+=2)
        {
            dp[i, i, s[i] - '0'] = 1;
        }
        
        // 枚举区间长度,一数字加一符号
        for (int len = 2; len <= length; len+=2)
        {
            // 枚举区间起点,一数字
            for (int i = 0; i < length - len; i+=2)
            {
                // 区间终点
                int j = i + len;
                // 枚举分割点,一符号
                for (int k = i+1; k < j; k+=2)
                {
                    var flag = s[k];
                    switch (flag)
                    {
                        case '&':
                            // 0&0 1&0 0&1
                            dp[i, j, 0] += dp[i, k - 1, 0] * dp[k + 1,j, 0] + dp[i, k - 1, 1] * dp[k + 1,j, 0] +
                                          dp[i, k - 1, 0] * dp[k + 1,j, 1];
                            // 1&1
                            dp[i, j, 1] += dp[i, k - 1, 1] * dp[k + 1,j, 1];
                            break;
                        case '|':
                            // 0|0
                            dp[i, j, 0] += dp[i, k - 1, 0] * dp[k + 1,j, 0];
                            // 1|1 1|0 0|1
                            dp[i, j, 1] += dp[i, k - 1, 1] * dp[k + 1,j, 1] + dp[i, k - 1, 1] * dp[k + 1,j, 0] +
                                          dp[i, k - 1, 0] * dp[k + 1,j, 1];
                            break;
                        case '^':
                            // 1^1 0^0
                            dp[i, j, 0] += dp[i, k - 1, 0] * dp[k + 1,j, 0]+dp[i, k - 1, 1] * dp[k + 1,j, 1];
                            // 1^0 0^1
                            dp[i, j, 1] += dp[i, k - 1, 1] * dp[k + 1,j, 0]+dp[i, k - 1, 0] * dp[k + 1,j, 1];
                            break;
                    }
                }
            }
        }

        return dp[0, length-1, result];
    }
}