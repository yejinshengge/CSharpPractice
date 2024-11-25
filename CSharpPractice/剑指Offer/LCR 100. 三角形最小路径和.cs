using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR100
{
    public static void Test()
    {
        LeetCode_LCR100 obj = new LeetCode_LCR100();
        Console.WriteLine(obj.MinimumTotal(Tools.ConstructTArray("[[2],[3,4],[6,5,7],[4,1,8,3]]")));
        Console.WriteLine(obj.MinimumTotal(Tools.ConstructTArray("[[-10]]")));
    }
    
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        if (triangle.Count==1) return triangle[0][0];
        int[] dp = new int[triangle.Count];
        dp[0] = triangle[0][0];
        int res = int.MaxValue;
        for (int i = 1; i < triangle.Count; i++)
        {
            int pre = 0;
            for (int j = 0; j < triangle[i].Count; j++)
            {
                int num = int.MaxValue;
                if (j < triangle[i - 1].Count)
                    num = Math.Min(dp[j], num);
                if (j - 1 >= 0)
                    num = Math.Min(pre, num);
                pre = dp[j];
                dp[j] = num + triangle[i][j];
                if (i == triangle.Count - 1)
                    res = Math.Min(res, dp[j]);
            }
        }

        return res;
    }
}