namespace CSharpPractice.LeetCode.初级算法;

/**
给定一个只包括 '('，')'，'{'，'}'，'['，']'的字符串 s ，判断字符串是否有效。

有效字符串需满足：

左括号必须用相同类型的右括号闭合。
左括号必须以正确的顺序闭合。
每个右括号都有一个对应的相同类型的左括号。

 */
public class LeetCode_047
{
    public static void Test()
    {
        LeetCode_047 obj = new LeetCode_047();
        Console.WriteLine(obj.IsValid("([)]"));
    }

    // 思路一:栈
    public bool IsValid(string s)
    {
        Dictionary<char, char> dic = new Dictionary<char, char>()
        {
            [')'] = '(',
            ['}'] = '{',
            [']'] = '['
        };

        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Count > 0)
            {
                if (dic.ContainsKey(s[i]) && stack.Peek() == dic[s[i]])
                {
                    stack.Pop();
                    continue;
                }
            }
            stack.Push(s[i]);
            
        }

        return stack.Count == 0;
    }

}