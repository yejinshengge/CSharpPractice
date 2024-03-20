using System.Text;

namespace CSharpPractice.LeetCode.模拟;

/**
 * 给你一个整数 columnNumber ，返回它在 Excel 表中相对应的列名称。
 */
public class LeetCode_0168
{
    public static void Test()
    {
        LeetCode_0168 obj = new LeetCode_0168();
        Console.WriteLine(obj.ConvertToTitle(1));
        Console.WriteLine(obj.ConvertToTitle(28));
        Console.WriteLine(obj.ConvertToTitle(701));
        Console.WriteLine(obj.ConvertToTitle(2147483647));
    }
    
    public string ConvertToTitle(int columnNumber)
    {
        StringBuilder tab = new StringBuilder();
        while (columnNumber > 0)
        {
            columnNumber--;
            tab.Append((char)('A' + columnNumber % 26));
            columnNumber /= 26;
        }

        StringBuilder res = new StringBuilder();
        for (int i = tab.Length-1; i >= 0; i--)
        {
            res.Append(tab[i]);
        }

        return res.ToString();
    }
}