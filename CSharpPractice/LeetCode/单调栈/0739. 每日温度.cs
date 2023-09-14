using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.单调栈;

/**
 * 给定一个整数数组 temperatures ，表示每天的温度，返回一个数组 answer ，
 * 其中 answer[i] 是指对于第 i 天，下一个更高温度出现在几天后。
 * 如果气温在这之后都不会升高，请在该位置用 0 来代替。
 */
public class LeetCode_0739
{
    public static void Test()
    {
        LeetCode_0739 obj = new LeetCode_0739();
        Tools.PrintArr(obj.DailyTemperatures(new []{73,74,75,71,69,72,76,73}));
        Tools.PrintArr(obj.DailyTemperatures(new []{30,40,50,60}));
        Tools.PrintArr(obj.DailyTemperatures(new []{30,60,90}));
    }
    
    public int[] DailyTemperatures(int[] temperatures)
    {
        Stack<int> stack = new Stack<int>();
        int[] res = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                var index = stack.Pop();
                var dis = i - index;
                res[index] = dis;
            }
            stack.Push(i);
        }
        return res;
    }
}