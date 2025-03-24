using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR107
{
    public static void Test()
    {
        LeetCode_LCR107 obj = new LeetCode_LCR107();
        Tools.PrintArr(obj.UpdateMatrix(Tools.ConstructTArray("[[0,0,0],[0,1,0],[0,0,0]]")));
        Tools.PrintArr(obj.UpdateMatrix(Tools.ConstructTArray("[[0,0,0],[0,1,0],[1,1,1]]")));
        Tools.PrintArr(obj.UpdateMatrix(Tools.ConstructTArray("[[0]]")));
        Tools.PrintArr(obj.UpdateMatrix(Tools.ConstructTArray("[[1,1,0,1,1]]")));
    }
    
    public int[][] UpdateMatrix(int[][] mat)
    {
        int[][] res = new int[mat.Length][];
        Queue<int[]> queue = new Queue<int[]>();
        // 将所有0入队
        for (var i = 0; i < res.Length; i++)
        {
            res[i] = new int[mat[i].Length];
            for (int j = 0; j < res[0].Length; j++)
            {
                if (mat[i][j] != 0)
                    res[i][j] = int.MaxValue;
                else
                    queue.Enqueue(new []{i,j});
            }
        }

        int[][] dirs = new[] { new int[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 } };
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            int distance = res[node[0]][node[1]];
            // 搜寻所有方向
            foreach (var dir in dirs)
            {
                int row = node[0] + dir[0];
                int col = node[1] + dir[1];
                if (row >= 0 && row < mat.Length && col >= 0 && col < mat[0].Length)
                {
                    // 更新最短距离
                    if (res[row][col] > distance + 1)
                    {
                        res[row][col] = distance + 1;
                        queue.Enqueue(new []{row,col});
                    }
                }
            }
        }

        return res;
    }
}