namespace CSharpPractice.LeetCode.单调栈;

/**
 * 给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
 */
public class LeetCode_0042
{
    public static void Test()
    {
        LeetCode_0042 obj = new LeetCode_0042();
        Console.WriteLine(obj.Trap(new []{0,1,0,2,1,0,1,3,2,1,2,1}));
        Console.WriteLine(obj.Trap(new []{4,2,0,3,2,5}));
        Console.WriteLine(obj.Trap(new []{1}));
    }
    
    public int Trap(int[] height)
    {
        Stack<int> stack = new Stack<int>();
        int res = 0;
        stack.Push(0);
        for (int i = 1; i < height.Length; i++)
        {
            while (stack.Count > 0 && height[stack.Peek()] <= height[i])
            {
                var top = stack.Pop();
                if (stack.Count > 0)
                {
                    int h = Math.Min(height[i], height[stack.Peek()]) - height[top];
                    int w = i - stack.Peek() - 1;
                    res += h * w;
                }
            }
            stack.Push(i);
        }

        return res;
    }
}