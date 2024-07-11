using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇.前缀和;

public class LeetCode_1314
{
    public static void Test()
    {
        LeetCode_1314 obj = new LeetCode_1314();
        Tools.PrintArr(obj.MatrixBlockSum(Tools.ConstructTArray("[[1,2,3],[4,5,6],[7,8,9]]"),1));
        Tools.PrintArr(obj.MatrixBlockSum(Tools.ConstructTArray("[[1,2,3],[4,5,6],[7,8,9]]"),2));
    }

    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        int[][] prefixSum = new int[mat.Length][];
        for (int i = 0; i < mat.Length; i++)
        {
            prefixSum[i] = new int[mat[i].Length];
            for (int j = 0; j < mat[i].Length; j++)
            {
                prefixSum[i][j] = mat[i][j];
                if (i - 1 >= 0)
                    prefixSum[i][j] += prefixSum[i - 1][j];
                if (j - 1 >= 0)
                    prefixSum[i][j] += prefixSum[i][j - 1];
                if (i - 1 >= 0 && j - 1 >= 0)
                    prefixSum[i][j] -= prefixSum[i - 1][j - 1];
            }
        }

        int[][] res = new int[mat.Length][];
        for (int i = mat.Length - 1; i >= 0; i--)
        {
            res[i] = new int[mat[i].Length];
            for (int j = mat[i].Length - 1; j >= 0; j--)
            {
                int row = Math.Min(mat.Length - 1, i + k);
                int col = Math.Min(mat[i].Length - 1, j + k);
                res[i][j] = prefixSum[row][col];
                if (i - k - 1 >= 0)
                    res[i][j] -= prefixSum[i - k-1][col];
                if(j - k - 1 >=0)
                    res[i][j] -= prefixSum[row][j-k-1];
                if(i - k - 1>= 0 && j - k - 1>=0)
                    res[i][j] += prefixSum[i-k-1][j-k-1];
            }
        }
        return res;
    }
}