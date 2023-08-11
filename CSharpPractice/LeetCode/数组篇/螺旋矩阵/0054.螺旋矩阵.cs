namespace CSharpPractice.LeetCode.数组篇.螺旋矩阵;

// 给你一个 m 行 n 列的矩阵 matrix ，请按照 顺时针螺旋顺序 ，返回矩阵中的所有元素。
public class LeetCode_0054
{
    public static void Test()
    {
        LeetCode_0054 obj = new LeetCode_0054();
        var res = obj.SpiralOrder(new[]
        {
            new[] { 1, 2, 3 },
            new[] { 4, 5, 6 },
            new[] { 7, 8, 9 },
        });
        
        Console.WriteLine(res);
    }

    public IList<int> SpiralOrder(int[][] matrix)
    {
        IList<int> res = new List<int>(matrix.Length);

        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int top = 0, bottom = rows-1, left = 0, right = cols-1;

        while (left <= right && top <= bottom)
        {
            for (int colum = left; colum <= right; colum++)
            {
                res.Add(matrix[top][colum]);
            }

            for (int row = top+1; row <= bottom; row++)
            {
                res.Add(matrix[row][right]);
            }

            if (left < right && top < bottom)
            {
                for (int colum = right-1; colum > left; colum--)
                {
                    res.Add(matrix[bottom][colum]);
                }

                for (int row = bottom; row > top ; row--)
                {
                    res.Add(matrix[row][left]);
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