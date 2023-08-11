using System.Timers;
using Timer = System.Timers.Timer;

namespace CSharpPractice.C_;

public class TaskPractice
{
    public static void TaskPracticeMain()
    {
    }

    #region 启动任务

    public static void Test1()
    {
        var task = Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Hello World");
        });

        task.Wait();
    }

    #endregion

    #region 长任务

    public static void Test2()
    {
        Task.Factory.StartNew(() => Thread.Sleep(2000), 
            TaskCreationOptions.LongRunning);
    }

    #endregion

    #region 返回值

    public static void Test3()
    {
        Task<int> task = Task.Run(() =>
        {
            Thread.Sleep(2000);
            return 3;
        });

        Console.WriteLine("等待任务返回值....");
        Console.WriteLine(task.Result);
    }

    #endregion

    #region 异常处理

    public static void Test4()
    {
        var task = Task.Run(() => throw new NullReferenceException());
        try
        {
            task.Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine("发生异常");
        }
    }

    #endregion

    #region 任务延续

    public static void Test5()
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine("Hello World");
            Thread.Sleep(2000);
            return "Goodbye World";
        });

        // var taskAwaiter = task.GetAwaiter();
        // taskAwaiter.OnCompleted(() =>
        // {
        //     Console.WriteLine(taskAwaiter.GetResult());
        // });

        task.ContinueWith(e =>
        {
            Console.WriteLine(e.Result);
        });
        Console.ReadLine();
    }

    #endregion

    #region TaskCompletionSource

    public static void Test6()
    {
        var tcs = new TaskCompletionSource<int>();
        
        new Thread(() =>
        {
            Thread.Sleep(3000);
            tcs.SetResult(123);
        }){IsBackground = true}.Start();

        var task = tcs.Task;
        Console.WriteLine(task.Result);
        
    }

    public static Task<int> GetAnswer()
    {
        var tcs = new TaskCompletionSource<int>();
        var timer = new Timer(5000){AutoReset = false};
        timer.Elapsed += delegate
        {
            timer.Dispose();
            tcs.SetResult(42);
        };
        timer.Start();
        return tcs.Task;
    }

    public static void Test7()
    {
        var taskAwaiter = GetAnswer().GetAwaiter();
        taskAwaiter.OnCompleted(()=> Console.WriteLine(taskAwaiter.GetResult()));

        Console.ReadLine();
    }
    #endregion

    #region Delay

    public static void Test8()
    {
        Task.Delay(3000).ContinueWith(e => Console.WriteLine("Hello World"));
        Task.Delay(3000).GetAwaiter().OnCompleted(() => Console.WriteLine("Hello World"));

        Console.ReadLine();
    }

    #endregion

    #region 异步编程

    public static async Task Test9()
    {
        var taskAwaiter = GetPrimeNumAsync(2, 100000).GetAwaiter();
        taskAwaiter.OnCompleted(()=> Console.WriteLine(taskAwaiter.GetResult()));

        Console.ReadLine();

        var res = await GetPrimeNumAsync(2, 100000);
        Console.WriteLine(res);

        Func<Task> func = async () =>
        {
            await Task.Delay(2000);
            Console.WriteLine("Hello World");
        };
        
        Func<Task<int>> func2 = async () =>
        {
            await Task.Delay(2000);
            Console.WriteLine("Hello World");
            return 123;
        };
        
    }

    // 求出指定范围内的素数
    private static Task<int> GetPrimeNumAsync(int from,int to)
    {
        return Task.Run(() =>
        {
            int res = 0;
            for (int i = from; i <= to; i++)
            {
                bool flag = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag) res++;
            }

            return res;
        });
    }

    #endregion

    #region 异步流

    public static async IAsyncEnumerable<int> RangeAsync(int start,int count,int delay)
    {
        for (int i = start; i < start+count; i++)
        {
            await Task.Delay(delay);
            yield return i;
        }
    }

    public static async void Test10()
    {
        await foreach(var num in RangeAsync(0,100,500))
            Console.WriteLine(num);

        Console.WriteLine("Hello World");
    }

    public static void Test11()
    {
        Test10();
        Console.ReadLine();
    }
    #endregion
}