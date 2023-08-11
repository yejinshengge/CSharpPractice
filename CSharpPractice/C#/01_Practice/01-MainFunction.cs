
public class MainFunction
{
    #nullable enable
    public static void MainFun()
    {
        string s1 = "123";
        string s2 = "456";
        
        // 字符串插值
        System.Console.WriteLine($"字符串插值,第一个字符串:{s1},第二个字符串:{s2}");
        // 复合格式化
        System.Console.WriteLine("复合格式化,第一个字符串:{0},第二个字符串:{1}",s1,s2);
        // 将数字格式化为十六进制
        System.Console.WriteLine($"0x{42:x}");

        const double number = 1.618033988749895;
        double result;
        string text;

        text = $"{number}";
        result = double.Parse(text);
        System.Console.WriteLine($"{result == number}");
        text = string.Format("{0:R}", number);
        result = double.Parse(text);
        System.Console.WriteLine(result == number);
        
        System.Console.WriteLine(@"begin
                ||\//\/\/\/\|||||/\'\/\\q;
        ");
        
        // 可空修饰符
        int? age;
        age = null;

        
        string? s;
        s = null;

        //checked
        unchecked
        {
            int n = int.MaxValue;
            n = n + 1;
            System.Console.WriteLine(n);
        }

        string parseStr = "123";
        if (double.TryParse(parseStr, out double parseNum))
        {
            System.Console.WriteLine(parseNum);
        }

        // 8位和16位整数类型
        short x = 1, y = 1;
        // short z = x + y; 编译不通过
    }
}
