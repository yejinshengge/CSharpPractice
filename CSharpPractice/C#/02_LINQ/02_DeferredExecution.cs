namespace CSharpPractice.C_._02_LINQ;


public class DeferredExecution {
    public static void DeferredExecutionMain()
    {
        // 延迟执行
        var numbers = new List<int>() {1, 2, 3};
        var res = numbers.Select(e => e * 10);
        numbers.Add(4);

        foreach (var item in res)
        {
            Console.Write(item+" ");
        }
        // 输出结果:
        // 10 20 30 40
        Console.WriteLine("");

        numbers.Add(5);
        foreach (var item in res)
        {
            Console.Write(item+" ");
        }
        // 输出结果:
        // 10 20 30 40 50
    }
    public static void Test()
    {
        
        var numbers = new List<int>() {1, 2, 3};
        int factor = 10;
        var res = numbers.Select(e => e * factor);
        factor = 20;
        
        foreach (var item in res)
        {
            Console.Write(item+" ");
        }
        // 输出结果:
        // 20 40 60
    }
}