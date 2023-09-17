namespace CSharpPractice.LeetCode.单调栈;

/**
给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。

求在该柱状图中，能够勾勒出来的矩形的最大面积。
 */
public class LeetCode_0084
{
    public static void Test()
    {
        LeetCode_0084 obj = new LeetCode_0084();
        Console.WriteLine(obj.LargestRectangleArea(new []{2,1,5,6,2,3}));
        Console.WriteLine(obj.LargestRectangleArea(new []{4,2}));
        Console.WriteLine(obj.LargestRectangleArea(new []{2}));
    }
    
    public int LargestRectangleArea(int[] heights)
    {
        List<int> height = new List<int>(heights.Length + 2);
        height.Add(0);
        height.AddRange(heights);
        height.Add(0);
        Stack<int> stack = new Stack<int>();
        int res = 0;
        stack.Push(0);
        for (int i = 1; i < height.Count; i++)
        {
            while (stack.Count > 0 && height[stack.Peek()] > height[i])
            {
                var top = stack.Pop();
                if (stack.Count > 0)
                {
                    int h = height[top];
                    int w = i - stack.Peek() - 1;
                    res = Math.Max(h * w,res);
                }
            }
            stack.Push(i);
        }

        return res;
    }
}