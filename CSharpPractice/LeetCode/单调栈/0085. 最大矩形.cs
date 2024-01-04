using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.单调栈;

/**
 * 给定一个仅包含 0 和 1 、大小为 rows x cols 的二维二进制矩阵，找出只包含 1 的最大矩形，并返回其面积。
 */
public class LeetCode_0085
{
    public static void Test()
    {
        LeetCode_0085 obj = new LeetCode_0085();
        Console.WriteLine(obj.MaximalRectangle(Tools.ConstructCharArray("[[1,0,1,0,0],[1,0,1,1,1],[1,1,1,1,1],[1,0,0,1,0]]")));
        Console.WriteLine(obj.MaximalRectangle(Tools.ConstructCharArray("[[0]]")));
        Console.WriteLine(obj.MaximalRectangle(Tools.ConstructCharArray("[[1]]")));
    }
    
    public int MaximalRectangle(char[][] matrix)
    {
        int[] height = new int[matrix[0].Length];
        int maxArea = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == '1')
                    height[j] += 1;
                else
                    height[j] = 0;
            }

            maxArea = Math.Max(_doMaximalRectangle(height), maxArea);
        }

        return maxArea;
    }

    private int _doMaximalRectangle(int[] height)
    {
        int maxArea = 0;
        Stack<int> heightIndex = new Stack<int>();
        int curIndex = 0;
        while (curIndex < height.Length)
        {
            if (heightIndex.Count == 0)
            {
                heightIndex.Push(curIndex);
                curIndex++;
            }
            else
            {
                int topIndex = heightIndex.Peek();
                // 遇到了较矮的柱子,计算面积
                if (height[curIndex] < height[topIndex])
                {
                    // 当前最高柱子的高度
                    int topHeight = height[heightIndex.Pop()];
                    // 左侧较矮的柱子下标
                    int leftSmaller = heightIndex.Count > 0 ? heightIndex.Peek() : -1;
                    // 右侧较矮的柱子下标
                    int rightSmaller = curIndex;
                    // 面积
                    int area = (rightSmaller - leftSmaller - 1) * topHeight;
                    maxArea = Math.Max(area, maxArea);
                }
                // 遇到了较高的柱子,直接入栈
                else
                {
                    heightIndex.Push(curIndex);
                    curIndex++;
                }
            }
        }
        // 剩余的柱子右侧没有比自己矮的柱子
        while (heightIndex.Count > 0)
        {
            var topIndex = heightIndex.Pop();
            var leftSmaller = heightIndex.Count > 0 ? heightIndex.Peek() : -1;
            var rightSmaller = height.Length;
            int area = (rightSmaller - leftSmaller - 1) * height[topIndex];
            maxArea = Math.Max(area, maxArea);
        }

        return maxArea;
    }
}