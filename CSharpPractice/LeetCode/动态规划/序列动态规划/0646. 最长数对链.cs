using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个由 n 个数对组成的数对数组 pairs ，其中 pairs[i] = [lefti, righti] 且 lefti < righti 。

    现在，我们定义一种 跟随 关系，当且仅当 b < c 时，数对 p2 = [c, d] 才可以跟在 p1 = [a, b] 后面。我们用这种形式来构造 数对链 。

    找出并返回能够形成的 最长数对链的长度 。

    你不需要用到所有的数对，你可以以任何顺序选择其中的一些数对来构造。
 */
public class LeetCode_0646
{
    public static void Test()
    {
        LeetCode_0646 obj = new LeetCode_0646();
        Console.WriteLine(obj.FindLongestChain(new []{new []{1,2},new []{2,3},new []{3,4}}));
        Console.WriteLine(obj.FindLongestChain(new []{new []{1,2},new []{7,8},new []{4,5}}));
        Console.WriteLine(obj.FindLongestChain(Tools.ConstructTArray("[[-10,-8],[8,9],[-5,0],[6,10],[-6,-4],[1,7],[9,10],[-4,7]]")));
        
    }
    
    public int FindLongestChain(int[][] pairs) {
        Array.Sort(pairs, (a1, a2) =>
        {
            if (a1[0] != a2[0])
                return a1[0] - a2[0];
            return a1[1] - a2[1];
        });
        
        int[] dp = new int[pairs.Length+1];
        for (int i = 1; i <= pairs.Length; i++)
        {
            for (int j = 1; j < i; j++)
            {
                if (pairs[j - 1][1] < pairs[i - 1][0])
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }

        }

        return dp[pairs.Length]+1;
    }
}