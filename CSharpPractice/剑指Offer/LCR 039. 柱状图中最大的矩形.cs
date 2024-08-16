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
                var top = stack.Peek();
                if (heights[top] <= heights[curIndex])
                {
                    stack.Push(curIndex);
                    curIndex++;
                }
                else
                {
                    stack.Pop();
                    int topHeight = heights[top];
                    int leftSmall = stack.Count > 0 ? stack.Peek() : -1;
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
        return _calMaxArea(heights, 0, heights.Length - 1);
    }

    private int _calMaxArea(int[] heights, int left, int right)
    {
        if (left > right) 
            return 0;
        if (left == right)
            return heights[left];
        int minIndex = left;
        for (int i = left+1; i <= right; i++)
        {
            minIndex = heights[i] < heights[minIndex] ? i : minIndex;
        }

        int areaLeft = _calMaxArea(heights, left, minIndex - 1);
        int areaRight = _calMaxArea(heights, minIndex+1, right);
        int curArea = (right - left + 1) * heights[minIndex];
        return Math.Max(Math.Max(areaLeft, areaRight), curArea);
    }
}