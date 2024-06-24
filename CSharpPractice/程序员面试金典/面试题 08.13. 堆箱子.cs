using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_13
{
    public static void Test()
    {
        LeetCode_08_13 obj = new LeetCode_08_13();
        //Console.WriteLine(obj.PileBox(Tools.ConstructTArray("[[1,1,1],[2,2,2],[3,3,3]]")));
        //Console.WriteLine(obj.PileBox(Tools.ConstructTArray("[[1,1,1], [2,3,4], [2,6,7],[3,4,5]]")));
        Console.WriteLine(obj.PileBox(Tools.ConstructTArray("[[3, 1, 4], [10, 16, 15], [9, 10, 20], [8, 9, 8], [19, 7, 8], [10, 8, 2], [18, 16, 6], [8, 4, 9], [13, 1, 10], [18, 4, 6], [14, 8, 16], [13, 18, 2], [17, 10, 16], [4, 6, 6], [11, 17, 7], [1, 8, 7], [16, 10, 15], [18, 18, 4], [7, 2, 12], [1, 7, 3], [8, 5, 4], [15, 4, 9], [16, 7, 6], [12, 13, 20], [2, 4, 3], [12, 13, 20], [1, 2, 13], [16, 20, 11], [14, 4, 17], [16, 15, 8], [15, 18, 17], [4, 4, 8], [5, 18, 1], [16, 10, 10], [17, 19, 13], [18, 20, 13], [17, 5, 19], [5, 2, 17], [7, 13, 13], [9, 11, 12], [11, 10, 12], [10, 16, 5], [4, 3, 18], [18, 11, 18], [14, 14, 16], [18, 1, 14], [7, 5, 19], [10, 15, 11], [2, 11, 8], [6, 8, 17], [12, 1, 12], [8, 4, 17], [13, 14, 11], [17, 20, 11], [15, 10, 15], [7, 6, 19], [14, 13, 15], [11, 9, 12], [19, 14, 2], [14, 11, 8], [4, 2, 18], [12, 20, 15], [2, 12, 18], [16, 6, 9]]".Replace(" ",""))));
    }
    
    public int PileBox(int[][] box) {
        Array.Sort(box, (a, b) =>
        {
            if (a[0] != b[0])
                return a[0] - b[0];
            if (a[1] != b[1])
                return a[1] - b[1];
            return a[2] - b[2];
        });
        // 前i个箱子最高能堆出dp[i]的高度
        int[] dp = new int[box.Length+1];
        for (int i = 1; i <= box.Length; i++)
        {
            dp[i] = box[i-1][2];
        }
        for (int i = 2; i <= box.Length; i++)
        {
            for (int j = 1; j < i; j++)
            {
                if(!_check(box,j-1,i-1))
                    continue;
                dp[i] = Math.Max(dp[i], dp[j] + box[i - 1][2]);
            }
        }

        int max = 0;
        for (int i = 1; i <= box.Length; i++)
        {
            max = Math.Max(max, dp[i]);
        }
        return max;
    }

    private bool _check(int[][] box,int a,int b)
    {
        return box[b][0] > box[a][0] && box[b][1] > box[a][1] && box[b][2] > box[a][2];
    }
}