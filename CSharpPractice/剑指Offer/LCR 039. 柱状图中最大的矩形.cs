using System.Collections;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR039
{
    public static void Test()
    {
        LeetCode_LCR039 obj = new LeetCode_LCR039();
        Console.WriteLine(obj.LargestRectangleArea(new []{2,1,5,6,2,3}));
        Console.WriteLine(obj.LargestRectangleArea(new []{2,4}));
        Console.WriteLine(obj.LargestRectangleArea(new []{2}));
    }
    
    public int LargestRectangleArea1(int[] heights)
    {
        // 单调栈
        Stack<int> stack = new();
        int curIndex = 0;
        int maxArea = 0;
        while (curIndex < heights.Length)
        {
            if (stack.Count == 0)
            {
                stack.Push(curIndex);
                curIndex++;
            }
            else
            {
                // 确保栈中的元素单调递增
                var top = stack.Peek();
                // 遇到更高的柱子直接入栈
                if (heights[top] <= heights[curIndex])
                {
                    stack.Push(curIndex);
                    curIndex++;
                }
                else
                {
                    // 遇到更矮的柱子，则出栈
                    stack.Pop();
                    int topHeight = heights[top];
                    // 找到左侧第一个比当前柱子矮的柱子
                    int leftSmall = stack.Count > 0 ? stack.Peek() : -1;
                    // 计算当前柱子能形成的最大矩形面积
                    int area = (curIndex - leftSmall - 1) * topHeight;
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }

        while (stack.Count > 0)
        {
            int top = stack.Pop();
            int topHeight = heights[top];
            int leftSmall = stack.Count > 0 ? stack.Peek() : -1;
            int area = (curIndex - leftSmall - 1) * topHeight;
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }

    public int LargestRectangleArea(int[] heights)
    {
        // 分治法
        return _calMaxArea(heights, 0, heights.Length - 1);
    }

    private int _calMaxArea(int[] heights, int left, int right)
    {
        if (left > right) 
            return 0;
        if (left == right)
            return heights[left];
        // 找到最小高度
        int minIndex = left;
        for (int i = left+1; i <= right; i++)
        {
            minIndex = heights[i] < heights[minIndex] ? i : minIndex;
        }

        // 找出左右最大面积
        int areaLeft = _calMaxArea(heights, left, minIndex - 1);
        int areaRight = _calMaxArea(heights, minIndex+1, right);
        // 按最矮的柱子算当前矩形面积
        int curArea = (right - left + 1) * heights[minIndex];
        // 返回最大面积
        return Math.Max(Math.Max(areaLeft, areaRight), curArea);
    }
}