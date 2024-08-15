using System.Collections;
using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR038
{
    public static void Test()
    {
        LeetCode_LCR038 obj = new LeetCode_LCR038();
        Tools.PrintArr(obj.DailyTemperatures(new []{73,74,75,71,69,72,76,73}));
        Tools.PrintArr(obj.DailyTemperatures(new []{30,40,50,60}));
        Tools.PrintArr(obj.DailyTemperatures(new []{30,60,90}));
    }
    
    public int[] DailyTemperatures(int[] temperatures)
    {
        Stack<int> stack = new();
        int[] res = new int[temperatures.Length];
        for (var i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                var index = stack.Pop();
                res[index] = i - index;
            }
            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            var index = stack.Pop();
            res[index] = 0;
        }

        return res;
    }
}