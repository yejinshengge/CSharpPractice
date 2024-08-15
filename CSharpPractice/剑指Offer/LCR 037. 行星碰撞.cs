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
            while (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < -asteroid)
            {
                stack.Pop();
            }

            if (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() == -asteroid)
                stack.Pop();
            else if(stack.Count == 0 || stack.Peek() < 0 || asteroid > 0)
                stack.Push(asteroid);
            
        }
        
        return stack.Reverse().ToArray();
    }
}