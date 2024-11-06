namespace CSharpPractice.C_核心技术指南._14_并发与异步;

public class Test_03 {
    // await
    public static async void Test1()
    {
        var res = await GetPrimesCntSync();
        Console.WriteLine("任务运行中");
        Console.WriteLine("结果是："+res);
    }

    static Task<int> GetPrimesCntSync()
    {
        return Task.Run(() =>
            Enumerable.Range(2, 3000000).Count(n => 
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
    }
    
    // await+循环
    public static async void Test2()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(await GetPrimesCntSync());
        }

        Console.ReadLine();
    }
}