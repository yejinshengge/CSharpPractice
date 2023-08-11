using System.Diagnostics;

namespace CSharpPractice.C_;

public class ThreadPractice
{
    public static void ThreadPracticeMain()
    {
        Test5();
    }

    #region Start

    private static void Test1()
    {
        Thread thread = new Thread(Print);
        thread.Start();

        for (int i = 0; i < 1000; i++)
        {
            Console.Write("B");
        }
    }

    private static void Print()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("A");
        }
    }

    #endregion

    #region Sleep

    private static void Test2()
    {
        Thread thread = new Thread(SleepTest);
        thread.Start();
        // 主线程睡眠1000毫秒
        Thread.Sleep(1000);
        Console.WriteLine("Main Thread Wake");
    }

    private static void SleepTest()
    {
        Console.WriteLine("Child Thread Start");
        // 线程睡眠3000毫秒
        Thread.Sleep(3000);
        Console.WriteLine("Child Thread Wake");
    }

    #endregion

    #region Join

    private static Thread thread1, thread2;

    private static void Test3()
    {
        thread1 = new Thread(JointTest1);
        thread1.Start();
        thread2 = new Thread(JointTest2);
        thread2.Start();
    }

    private static void JointTest1()
    {
        Console.WriteLine("Child Thread 1 Start");
        Thread.Sleep(3000);
        thread2.Join();
        Console.WriteLine("Child Thread 1 Awake");
    }

    private static void JointTest2()
    {
        Console.WriteLine("Child Thread 2 Start");
        Thread.Sleep(5000);
        Console.WriteLine("Child Thread 2 Awake");
    }

    #endregion

    #region 本地状态

    private static void Test4()
    {
        Thread thread = new Thread(Print2);
        thread.Start();
        Print2();
    }

    private static void Print2()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write("A");
        }
    }

    #endregion

    #region 共享状态

    // private bool _flag;
    //
    // public static void Test5()
    // {
    //     // 类实例
    //     ThreadPractice obj = new ThreadPractice();
    //     Thread thread = new Thread(obj.SharedStateTest);
    //     thread.Start();
    //     obj.SharedStateTest();
    // }
    //
    // private void SharedStateTest()
    // {
    //     if (!_flag)
    //     {
    //         _flag = true;
    //         Console.WriteLine("flag is false");
    //     }
    // }

    #endregion

    #region 锁

    private bool _flag;
    private readonly object _locker = new();

    public static void Test5()
    {
        // 类实例
        ThreadPractice obj = new ThreadPractice();
        Thread thread = new Thread(obj.SharedStateTest);
        thread.Start();
        obj.SharedStateTest();
    }

    private void SharedStateTest()
    {
        // 加锁
        lock (_locker)
        {
            if (!_flag)
            {
                Console.WriteLine("flag is false");
                _flag = true;
            }
        }
    }

    #endregion

    #region 传递参数

    public static void Test6()
    {
        // Thread thread = new Thread(() => PrintParam("Hello world"));
        // thread.Start();

        Thread thread = new Thread(PrintParam);
        thread.Start("Hello world");
    }

    private static void PrintParam(object? param)
    {
        Console.WriteLine(param as string);
    }

    #endregion

    #region 前台线程与后台线程

    public static void Test7()
    {
        Thread thread = new Thread(() => Console.ReadLine());
        // thread.IsBackground = false;
        thread.Start();
    }

    #endregion

    #region 信号发送

    public static void Test8()
    {
        // 信号
        var signal = new ManualResetEvent(false);

        new Thread(() =>
        {
            Console.WriteLine("等待信号....");
            // 等待信号
            signal.WaitOne();
            // 释放资源
            signal.Dispose();
            Console.WriteLine("已取得信号....");
        }).Start();

        Thread.Sleep(2000);
        // 打开信号
        signal.Set();
    }

    #endregion

    #region 线程池

    public static void Test9()
    {
        ThreadPool.QueueUserWorkItem(e => Console.WriteLine("Hello World"));
        Thread.Sleep(2000);
    }

    #endregion

    #region 异常处理

    public static void Test10()
    {
        try
        {
            new Thread(() => throw new NullReferenceException()).Start();
        }
        catch (Exception e)
        {
            Console.WriteLine("发生异常");
        }
    }
    public static void Test11()
    {
        new Thread(() =>
        {
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception e)
            {
                Console.WriteLine("发生异常");
            }
        }).Start();
        
    }
    #endregion
    
}