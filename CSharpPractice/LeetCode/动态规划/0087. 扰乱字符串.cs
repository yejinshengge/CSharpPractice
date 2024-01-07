namespace CSharpPractice.LeetCode.动态规划;

/**
 * 使用下面描述的算法可以扰乱字符串 s 得到字符串 t ：
    如果字符串的长度为 1 ，算法停止
    如果字符串的长度 &gt; 1 ，执行下述步骤：
    在一个随机下标处将字符串分割成两个非空的子字符串。即，如果已知字符串 s ，则可以将其分成两个子字符串 x 和 y ，且满足 s = x + y 。
    随机 决定是要「交换两个子字符串」还是要「保持这两个子字符串的顺序不变」。即，在执行这一步骤之后，s 可能是 s = x + y 或者 s = y + x 。
    在 x 和 y 这两个子字符串上继续从步骤 1 开始递归执行此算法。
    给你两个 长度相等 的字符串 s1 和 s2，判断 s2 是否是 s1 的扰乱字符串。如果是，返回 true ；否则，返回 false 。
 */
public class LeetCode_0087
{
    public static void Test()
    {
        LeetCode_0087 obj = new LeetCode_0087();
        Console.WriteLine(obj.IsScramble("great","rgeat"));
        Console.WriteLine(obj.IsScramble("abcde","caebd"));
        Console.WriteLine(obj.IsScramble("a","a"));
    }
    
    public bool IsScramble(string s1, string s2)
    {
        int len = s1.Length;
        bool[,,] dp = new bool[len,len,len+1];
        // 初始化单个字符的情况
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                dp[i, j, 1] = s1[i] == s2[j];
            }
        }
        // 枚举长度
        for (int curLen = 2; curLen <= len; curLen++)
        {
            // 枚举S1的起始位置
            for (int s1Start = 0; s1Start <= len - curLen; s1Start++)
            {
                // 枚举S2的起始位置
                for (int s2Start = 0; s2Start <= len-curLen; s2Start++)
                {
                    // 枚举划分位置
                    for (int par = 1; par <= curLen-1; par++)
                    {
                        if (dp[s1Start, s2Start, par] && dp[s1Start + par, s2Start + par, curLen - par])
                        {
                            dp[s1Start, s2Start, curLen] = true;
                            break;
                        }

                        if (dp[s1Start, s2Start + curLen - par, par] && dp[s1Start+par, s2Start, curLen - par])
                        {
                            dp[s1Start, s2Start, curLen] = true;
                            break;
                        }
                    }
                }
            }
        }

        return dp[0, 0, len];
    }
}