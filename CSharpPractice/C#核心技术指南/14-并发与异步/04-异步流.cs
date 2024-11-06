namespace CSharpPractice.C_核心技术指南._14_并发与异步;

public class Test_04 {
    public static void Test1()
    {
        Task.Run(() => AsyncForeach())
            .GetAwaiter().GetResult();
        Console.ReadLine();
    }

    public static async void AsyncForeach()
    {
        await foreach (var num in RangeAsync(0, 10, 500))
        {
            Console.Write(num+" ");
        }
        foreach (var num in await RangeTaskAsync(0, 10, 500))
        {
            Console.Write(num+" ");
        }
    }
    public static async IAsyncEnumerable<int> RangeAsync(int start,int count,int delay)
    {
        for (int i = start; i < start+count; i++)
        {
            await Task.Delay(delay);
            yield return i;
        }
    }
    
    public static async Task<IEnumerable<int>> RangeTaskAsync(int start,int count,int delay)
    {
        List<int> data = new List<int>();
        for (int i = start; i < start+count; i++)
        {
            await Task.Delay(delay);
            data.Add(i);
        }
        return data;
    }
}