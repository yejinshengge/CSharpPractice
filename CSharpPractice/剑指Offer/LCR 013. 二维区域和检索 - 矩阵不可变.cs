using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR013
{
    public static void Test()
    {
        LeetCode_LCR013 obj = new LeetCode_LCR013();
        NumMatrix ma = new NumMatrix(Tools.ConstructTArray(
            "[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]"));
        Console.WriteLine(ma.SumRegion(2,1,4,3));
        Console.WriteLine(ma.SumRegion(1,1,2,2));
        Console.WriteLine(ma.SumRegion(1,2,2,4));
        
        NumMatrix ma2 = new NumMatrix(Tools.ConstructTArray(
            "[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]"));
        Console.WriteLine(ma2.SumRegion(2, 1, 4, 3));
        Console.WriteLine(ma2.SumRegion(1, 1, 2, 2));
        Console.WriteLine(ma2.SumRegion(1, 2, 2, 4));
    }
    
    public class NumMatrix
    {
        private int[][] _matrix;
        private int[][] _sum;
        public NumMatrix(int[][] matrix)
        {
            _matrix = matrix;
            _sum = new int[matrix.Length + 1][];
            for (int i = 0; i <= matrix.Length; i++)
            {
                _sum[i] = new int[matrix[0].Length + 1];
                if(i == 0) continue;
                for (int j = 1; j <= matrix[0].Length; j++)
                {
                    _sum[i][j] = _sum[i][j - 1] + _sum[i - 1][j] - _sum[i - 1][j - 1]+_matrix[i-1][j-1];
                }
            }
        }
    
        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return _sum[row2 + 1][col2 + 1] - _sum[row2 + 1][col1] - _sum[row1][col2 + 1] + _sum[row1][col1];
        }
    }
}