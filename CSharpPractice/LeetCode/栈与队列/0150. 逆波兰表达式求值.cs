namespace CSharpPractice.LeetCode.栈与队列;

/**
给你一个字符串数组 tokens ，表示一个根据 逆波兰表示法 表示的算术表达式。
请你计算该表达式。返回一个表示表达式值的整数。
 */
public class LeetCode_0150
{
    public static void Test()
    {
        LeetCode_0150 obj = new LeetCode_0150();
        Console.WriteLine(obj.EvalRPN(new string[]{"2","1","+","3","*"}));
        Console.WriteLine(obj.EvalRPN(new string[]{"4","13","5","/","+"}));
        Console.WriteLine(obj.EvalRPN(new string[]{"10","6","9","3","+","-11","*","/","*","17","+","5","+"}));
    }

    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();
        HashSet<string> flag = new HashSet<string>()
        {
            "+", "-", "*", "/"
        };
        int res = 0;
        int num1 = 0;
        int num2 = 0;
        for (int i = 0; i < tokens.Length; i++)
        {
            if (flag.Contains(tokens[i]))
            {
                num1 = stack.Pop();
                num2 = stack.Pop();
                switch (tokens[i])
                {
                    case "+":
                        res = num1 + num2;
                        break;
                    case "-":
                        res = num2 - num1;
                        break;
                    case "*":
                        res = num1 * num2;
                        break;
                    case "/":
                        res = num2 / num1;
                        break;
                }
                stack.Push(res);
            }
            else
            {
                stack.Push(int.Parse(tokens[i]));
            }
        }

        return stack.Pop();
    }
}