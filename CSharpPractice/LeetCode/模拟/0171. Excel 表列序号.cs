namespace CSharpPractice.LeetCode.模拟;

// 给你一个字符串 columnTitle ，表示 Excel 表格中的列名称。返回 该列名称对应的列序号 。
public class LeetCode_0171
{
    public static void Test()
    {
        LeetCode_0171 obj = new LeetCode_0171();
        Console.WriteLine(obj.TitleToNumber("A"));
        Console.WriteLine(obj.TitleToNumber("AB"));
        Console.WriteLine(obj.TitleToNumber("ZY"));
    }
    
    public int TitleToNumber(string columnTitle)
    {
        int res = 0;
        int len = columnTitle.Length;
        for (int i = len-1; i >=0; i--)
        {
            res += (columnTitle[i] - 'A' + 1) * (int)Math.Pow(26, len - i-1);
        }

        return res;
    }
}