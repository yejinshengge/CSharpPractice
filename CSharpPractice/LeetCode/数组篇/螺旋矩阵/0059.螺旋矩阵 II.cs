namespace CSharpPractice.LeetCode.数组篇.螺旋矩阵;

// 给你一个正整数 n ，生成一个包含 1 到 n^2 所有元素，且元素按顺时针顺序螺旋排列的 n x n 正方形矩阵 matrix 。
public class LeetCode_0059
{
    public static void Test()
    {
        LeetCode_0059 obj = new LeetCode_0059();
        var matrix = obj.GenerateMatrix(3);
        
        Console.WriteLine(matrix);
    }

    public int[][] GenerateMatrix(int n)
    {
        int[][] arr = new int[n][];
        for (int i = 0; i < n; i++)
        {
            arr[i] = new int[n];
        }
        
        int num = 1;
        int start = 0;
        int offset = 1;
        int loop = n / 2;

        while (loop-- > 0)
        {
            
            // 上
            for (int i = start; i < n-offset; i++)
            {
                arr[start][i] = num++;
            }
            
            // 右
            for (int i = start; i < n-offset; i++)
            {
                arr[i][n - start - 1] = num++;
            }
            
            // 下
            for (int i = n - start-1; i >= offset ; i--)
            {
                arr[n - start - 1][i] = num++;
            }
            
            // 左
            for (int i = n-start-1; i >= offset ; i--)
            {
                arr[i][start] = num++;
            }

            start++;
            offset++;

        }

        if (n % 2 != 0)
        {
            int mid = n / 2;
            arr[mid][mid] = num;
        }
        return arr;
    }
}