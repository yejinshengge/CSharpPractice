namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR040
{
    public static void Test()
    {
        LeetCode_LCR040 obj = new LeetCode_LCR040();
        Console.WriteLine(obj.MaximalRectangle(new []{"10100","10111","11111","10010"}));
        Console.WriteLine(obj.MaximalRectangle(new []{"0"}));
        Console.WriteLine(obj.MaximalRectangle(new []{"1"}));
        Console.WriteLine(obj.MaximalRectangle(new []{"00"}));
    }
    
    public int MaximalRectangle(string[] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;
        int[] heights = new int[matrix[0].Length];
        int maxArea = 0;
        foreach (var str in matrix)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                    heights[i] = 0;
                else
                    heights[i]++;
            }

            maxArea = Math.Max(maxArea, _calMaxArea(heights));
        }

        return maxArea;
    }

    private int _calMaxArea(int[] heights)
    {
        Stack<int> stack = new();
        int maxArea = 0;
        int curIndex = 0;
        while(curIndex < heights.Length)
        {
            if(stack.Count == 0)
                stack.Push(curIndex++);
            else
            {
                var top = heights[stack.Peek()];
                int cur = heights[curIndex];
                if (top <= cur)
                {
                    stack.Push(curIndex++);
                }
                else
                {
                    stack.Pop();
                    var smallIndex = stack.Count > 0 ? stack.Peek():-1;
                    maxArea = Math.Max(maxArea, (curIndex - smallIndex - 1) * top);
                }
            }
        }

        while (stack.Count > 0)
        {
            var top = heights[stack.Pop()];
            var smallIndex = stack.Count > 0 ? stack.Peek():-1;
            maxArea = Math.Max(maxArea, (curIndex - smallIndex - 1) * top);
        }

        return maxArea;
    }
}