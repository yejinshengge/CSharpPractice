using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个由 n 个数对组成的数对数组 pairs ，其中 pairs[i] = [lefti, righti] 且 lefti &lt; righti 。
    
    现在，我们定义一种 跟随 关系，当且仅当 b &lt; c 时，数对 p2 = [c, d] 才可以跟在 p1 = [a, b] 后面。我们用这种形式来构造 数对链 。
    
    找出并返回能够形成的 最长数对链的长度 。
    
    你不需要用到所有的数对，你可以以任何顺序选择其中的一些数对来构造。
 */
public class LeetCode_0646
{
    public static void Test()
    {
        LeetCode_0646 obj = new LeetCode_0646();
        Console.WriteLine(obj.FindLongestChain(Tools.ConstructTArray("[[1,2], [2,3], [3,4]]")));
        Console.WriteLine(obj.FindLongestChain(Tools.ConstructTArray("[[1,2],[7,8],[4,5]]")));
        Console.WriteLine(obj.FindLongestChain(Tools.ConstructTArray("[[1,2]]")));
        Console.WriteLine(obj.FindLongestChain(Tools.ConstructTArray("[[3,10],[3,7],[7,10],[7,9],[-1,7],[-9,5],[2,8]]")));
    }
    
    public int FindLongestChain(int[][] pairs) {
        Array.Sort(pairs, (e1, e2) =>
        {
            if(e1[0] != e2[0])
                return e1[0] - e2[0];
            return e1[1] - e2[1];
        });
        //Tools.PrintArr(pairs);
        int[] dp = new int[pairs.Length];
        int maxLen = 0;
        for (int i = 0; i < pairs.Length; i++)
        {
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (pairs[i][0] > pairs[j][1])
                    dp[i] = Math.Max(dp[j] + 1, dp[i]);
            }

            maxLen = Math.Max(maxLen, dp[i]);
        }

        return maxLen;
    }
}