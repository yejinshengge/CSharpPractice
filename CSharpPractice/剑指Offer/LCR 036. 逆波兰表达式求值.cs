namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR036
{
    public static void Test()
    {
        LeetCode_LCR036 obj = new LeetCode_LCR036();
        Console.WriteLine(obj.EvalRPN(new []{"2","1","+","3","*"}));
        Console.WriteLine(obj.EvalRPN(new []{"4","13","5","/","+"}));
        Console.WriteLine(obj.EvalRPN(new []{"10","6","9","3","+","-11","*","/","*","17","+","5","+"}));
    }
    
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new();
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int num))
            {
                stack.Push(num);
            }
            else
            {
                var num1 = stack.Pop();
                var num2 = stack.Pop();
                int res = 0;
                switch (token)
                {
                    case "+":
                        res = num1 + num2;
                        break;
                    case "-":
                        res = num2 - num1;
                        break;
                    case "/":
                        res = num2 / num1;
                        break;
                    case "*":
                        res = num2 * num1;
                        break;
                }
                stack.Push(res);
            }
        }

        return stack.Pop();
    }
}