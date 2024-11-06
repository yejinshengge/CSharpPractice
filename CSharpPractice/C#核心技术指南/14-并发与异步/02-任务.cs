using Timer = System.Timers.Timer;

namespace CSharpPractice.C_核心技术指南._14_并发与异步;

public class Test_02 {
    // 任务
    public static void Test1()
    {
        Task.Run(() => Console.WriteLine("任务运行"));
        Console.ReadLine();
    }
    // wait
    public static void Test2()
    {
        var task = Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("任务完成");
        });
        Console.WriteLine(task.IsCompleted);
        task.Wait();
    }
    
    // 长任务
    public static void Test3()
    {
        var task = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("任务完成");
        },TaskCreationOptions.LongRunning);
    }
    // 带返回值的任务
    public static void Test4()
    {
        var task = Task.Run(() =>
            Enumerable.Range(2, 3000000).Count(n => 
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        Console.WriteLine("任务运行中");
        Console.WriteLine("结果是："+task.Result);
    }
    
    // 任务的延续
    public static void Test5()
    {
        var task = Task.Run(() =>
            Enumerable.Range(2, 3000000).Count(n => 
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        // var awaiter = task.GetAwaiter();
        // awaiter.OnCompleted(() =>
        // {
        //     int result = awaiter.GetResult();
        //     Console.WriteLine("任务完成，结果是："+result);
        // });
        task.ContinueWith(t =>
        {
            Console.WriteLine("任务完成，结果是："+t.Result);
        });
        Console.ReadLine();
    }
    
    // TaskCompletionSource
    public static void Test6()
    {
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
        new Thread(() =>
        {
            Thread.Sleep(2000);
            tcs.SetResult(42);
        }){IsBackground = true}.Start();
        
        Task<int> task = tcs.Task;
        Console.WriteLine(task.Result);
    }
    // 不绑定线程的任务
    public static void Test7()
    {
        var taskAwaiter = GetAnswerToLife().GetAwaiter();
        taskAwaiter.OnCompleted(() =>
        {
            Console.WriteLine("任务完成，结果是："+taskAwaiter.GetResult());
        });
        Console.ReadLine();
    }
    
    private static Task<int> GetAnswerToLife()
    {
        var tcs = new TaskCompletionSource<int>();
        var timer = new Timer(5000) { AutoReset = false };
        timer.Elapsed += (sender, args) =>
        {
            timer.Dispose();
            tcs.SetResult(42);
        };
        timer.Start();
        return tcs.Task;
    }
    // 通用Delay
    public static void Test8()
    {
        Console.WriteLine("开始");
        Delay(2000).GetAwaiter().OnCompleted(() =>
        {
            Console.WriteLine("结束");
        });
        // 等价于
        Task.Delay(2000).GetAwaiter().OnCompleted(()=>
        {
            Console.WriteLine("结束2");
        });
        Console.ReadLine();
    }
    
    public static Task Delay(int milliseconds)
    {
        var tcs = new TaskCompletionSource<object>();
        var timer = new Timer(milliseconds) { AutoReset = false };
        timer.Elapsed += (sender, args) =>
        {
            timer.Dispose();
            tcs.SetResult(null);
        };
        timer.Start();
        return tcs.Task;
    }
}