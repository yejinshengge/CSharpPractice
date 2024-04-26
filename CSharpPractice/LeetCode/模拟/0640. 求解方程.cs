namespace CSharpPractice.LeetCode.模拟;

public class LeetCode_0640
{
    public static void Test()
    {
        LeetCode_0640 obj = new LeetCode_0640();
        Console.WriteLine(obj.SolveEquation("x+5-3+x=6+x-2"));
        Console.WriteLine(obj.SolveEquation("x=x"));
        Console.WriteLine(obj.SolveEquation("2x=x"));
        Console.WriteLine(obj.SolveEquation("0x=0"));
        Console.WriteLine(obj.SolveEquation("1+1=x"));
    }
    
    public string SolveEquation(string equation)
    {
        equation += "+";
        int curNum = 0,xCoe = 0,totalNum = 0;
        int flag1 = 1,flag2 = 1;
        bool isValid = false;
        for (int i = 0; i < equation.Length; i++)
        {
            if (equation[i] == '+' || equation[i] == '-'||equation[i] == '=')
            {
                isValid = false;
                totalNum += flag1 * flag2 * curNum;
                curNum = 0;
                if(equation[i] == '+' || equation[i] == '-')
                    flag1 = equation[i] == '+' ? 1:-1;
                else
                {
                    flag1 = 1;
                    flag2 = -1;
                }
                continue;
            }

            if (equation[i] >= '0' && equation[i] <= '9')
            {
                curNum = curNum * 10 + (equation[i] - '0');
                isValid = true;
            }
            else
            {
                xCoe += flag1 * flag2 * (isValid?curNum:1);
                curNum = 0;
                isValid = false;
            }
        }

        if (xCoe == 0)
            return totalNum == 0 ? "Infinite solutions" : "No solution";
        return "x="+-totalNum / xCoe;
    }
}