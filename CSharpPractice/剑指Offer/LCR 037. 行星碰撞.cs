using System.Collections;
using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR037
{
    public static void Test()
    {
        LeetCode_LCR037 obj = new LeetCode_LCR037();
        Tools.PrintArr(obj.AsteroidCollision(new []{5,10,-5}));
        Tools.PrintArr(obj.AsteroidCollision(new []{8,-8}));
        Tools.PrintArr(obj.AsteroidCollision(new []{10,2,-5}));
        Tools.PrintArr(obj.AsteroidCollision(new []{-2,-1,1,2}));
    }
    
    public int[] AsteroidCollision(int[] asteroids)
    {
        Stack<int> stack = new();

        foreach (var asteroid in asteroids)
        {
            // 栈顶行星向右，当前行星向左，且栈顶行星小于当前行星，则栈顶行星爆炸
            while (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < -asteroid)
            {
                stack.Pop();
            }

            // 栈顶行星向右，当前行星向左，且栈顶行星等于当前行星，则栈顶行星爆炸
            if (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() == -asteroid)
                stack.Pop();
            // 栈为空，或者栈顶行星向左，或者当前行星向右，则当前行星入栈
            else if(stack.Count == 0 || stack.Peek() < 0 || asteroid > 0)
                stack.Push(asteroid);
            
        }
        
        return stack.Reverse().ToArray();
    }


}