using System.Text;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR002
{
    public static void Test()
    {
        LeetCode_LCR002 obj = new LeetCode_LCR002();
        // Console.WriteLine(obj.AddBinary("11","10"));
        // Console.WriteLine(obj.AddBinary("1010","1011"));
        Console.WriteLine(obj.AddBinary("1","111"));
    }
    
    public string AddBinary(string a, string b)
    {
        Stack<int> stack = new Stack<int>();
        int flag = 0, numA = 0, numB = 0;
        for (int i = a.Length-1,j = b.Length-1; i >= 0 || j>=0; i--,j--)
        {
            numA = 0;
            numB = 0;
            if (i >= 0)
                numA = a[i] - '0';
            if (j >= 0)
                numB = b[j] - '0';
            stack.Push((numA+numB+flag)%2);
            flag = (numA + numB + flag) / 2;
        }
        if(flag > 0)
            stack.Push(flag);

        StringBuilder sb = new StringBuilder(stack.Count);
        while (stack.Count > 0)
        {
            sb.Append(stack.Pop());
        }

        return sb.ToString();
    }
}