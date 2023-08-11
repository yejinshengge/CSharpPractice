namespace CSharpPractice.LeetCode;

/**
 * 在一个 n * m 的二维数组中，每一行都按照从左到右递增的顺序排序，
 * 每一列都按照从上到下递增的顺序排序。请完成一个高效的函数，
 * 输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。
 */
public class Offer004FindNumberIn2DArray
{
    public static void Offer004FindNumberIn2DArrayMain()
    {
        Offer004FindNumberIn2DArray obj = new();
        obj.Test();
    }
    public bool FindNumberIn2DArray(int[][] matrix, int target)
    {
        return matrix.Any(t => t.Any(t1 => t1 == target));
    }
    public bool FindNumberIn2DArray2(int[][] matrix, int target)
    {
        if (matrix.Length == 0)
            return false;
        if (matrix[0].Length == 0)
            return false;
        int m = matrix.Length;
        int row = 0, col = matrix[0].Length - 1;
        while (row < m && col >= 0)
        {
            // 右上角元素大于目标值,排除该列
            if (matrix[row][col] > target)
            {
                col--;
            }
            // 右上角元素小于目标值,排除该行
            else if(matrix[row][col] < target)
            {
                row++;
            }
            else
            {
                return true;
            }
            
        }
        return false;
    }

    private void Test()
    {
        List<int[][]> matrix = new();
        List<int> target = new();
        List<bool> result = new();
        int[][] param1 =
        {
            new[] {1, 4, 7, 11, 15},
            new[] {2, 5, 8, 12, 19},
            new[] {3, 6, 9, 16, 22},
            new[] {10, 13, 14, 17, 24},
            new[] {18, 21, 23, 26, 30}
        };
        matrix.Add(param1);
        target.Add(9);
        result.Add(true);
        
        matrix.Add(param1);
        target.Add(20);
        result.Add(false);

        int[][] param2 = {};
        matrix.Add(param2);
        target.Add(9);
        result.Add(false);

        for (int i = 0; i < matrix.Count; i++)
        {
            if (result[i] == FindNumberIn2DArray2(matrix[i], target[i]))
            {
                Console.WriteLine($"第{i}条,成功");
            }
            else
            {
                Console.WriteLine($"第{i}条,失败");
            }
        }
    }
}