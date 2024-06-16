using System.Text;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_05_02
{
    public static void Test()
    {
        LeetCode_05_02 obj = new LeetCode_05_02();
        Console.WriteLine(obj.PrintBin(0.625));
        Console.WriteLine(obj.PrintBin(0.1));
    }
    
    public string PrintBin(double num)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("0.");
        while (num != 0)
        {
            int i = (int)(num * 2);
            num = num * 2 - i;
            sb.Append(i);
            if (sb.Length > 32)
                return "ERROR";
        }

        return sb.ToString();
    }
}