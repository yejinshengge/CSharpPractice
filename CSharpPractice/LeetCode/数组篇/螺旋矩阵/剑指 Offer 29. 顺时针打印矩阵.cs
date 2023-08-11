using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇.螺旋矩阵;

// 输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字。
public class LeetCode_Offer029
{
    public static void Test()
    {
        LeetCode_Offer029 obj = new LeetCode_Offer029();
        Util.Tools.PrintArr(obj.SpiralOrder(new []
        {
            new []{1,2,3},
            new []{4,5,6},
            new []{7,8,9},
        }));
        Util.Tools.PrintArr(obj.SpiralOrder(new []
        {
            new []{3},
            new []{2},
        }));
    }

    public int[] SpiralOrder(int[][] matrix)
    {
        if (matrix.Length == 0) return new int[]{};
        int left = 0;
        int right = matrix[0].Length-1;

        int top = 0;
        int bottom = matrix.Length-1;
        int[] res = new int[matrix[0].Length * matrix.Length];
        int index = 0;

        while (left <= right && top <= bottom)
        {
            
            for (int i = left; i <= right; i++)
            {
                res[index++] = matrix[top][i];
            }

            for (int i = top+1; i <= bottom; i++)
            {
                res[index++] = matrix[i][right];
            }

            if (left < right && top < bottom)
            {
                for (int i = right - 1; i > left; i--)
                {
                    res[index++] = matrix[bottom][i];
                }

                for (int i = bottom; i > top; i--)
                {
                    res[index++] = matrix[i][left];
                }
            }

            left++;
            right--;
            top++;
            bottom--;
        }

        return res;
    }
}