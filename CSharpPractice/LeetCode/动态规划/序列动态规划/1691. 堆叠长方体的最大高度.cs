using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你 n 个长方体 cuboids ，其中第 i 个长方体的长宽高表示为 cuboids[i] = [widthi, lengthi, heighti]（下标从 0 开始）。请你从 cuboids 选出一个 子集 ，并将它们堆叠起来。

如果 widthi <= widthj 且 lengthi <= lengthj 且 heighti <= heightj ，你就可以将长方体 i 堆叠在长方体 j 上。你可以通过旋转把长方体的长宽高重新排列，以将它放在另一个长方体上。

返回 堆叠长方体 cuboids 可以得到的 最大高度 。
 */
public class LeetCode_1691
{
    public static void Test()
    {
        LeetCode_1691 obj = new LeetCode_1691();
        Console.WriteLine(obj.MaxHeight(Tools.ConstructTArray("[[50,45,20],[95,37,53],[45,23,12]]")));
        Console.WriteLine(obj.MaxHeight(Tools.ConstructTArray("[[38,25,45],[76,35,3]]")));
        Console.WriteLine(obj.MaxHeight(Tools.ConstructTArray("[[7,11,17],[7,17,11],[11,7,17],[11,17,7],[17,7,11],[17,11,7]]")));
    }
    
    public int MaxHeight(int[][] cuboids) {
        for (int i = 0; i < cuboids.Length; i++)
        {
            Array.Sort(cuboids[i]);
        }
        Array.Sort(cuboids, (e1, e2) => e1[0]+e1[1]+e1[2] - (e2[0]+e2[1]+e2[2]));
        int maxHeight = 0;
        int[] dp = new int[cuboids.Length+1];
        for (int i = 1; i <= cuboids.Length; i++)
        {
            dp[i] = cuboids[i-1][2];
            for (int j = 1; j < i; j++)
            {
                // 可以堆叠
                if (cuboids[i-1][0] >= cuboids[j-1][0]
                    && cuboids[i-1][1] >= cuboids[j-1][1] 
                    && cuboids[i-1][2] >= cuboids[j-1][2])
                {
                    dp[i] = Math.Max(dp[j] + cuboids[i-1][2],dp[i]);
                }
                
            }

            maxHeight = Math.Max(maxHeight, dp[i]);
        }

        return maxHeight;
    }
}