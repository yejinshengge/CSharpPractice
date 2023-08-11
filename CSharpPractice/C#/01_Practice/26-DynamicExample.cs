namespace CSharpPractice.Class01;

public class DynamicExample {

    public static void DynamicExampleMain()
    {
        dynamic data = "这是一段字符串";
        Console.WriteLine(data);
        data = (double)data.Length;
        Console.WriteLine($"长度：{data}");
    }
}