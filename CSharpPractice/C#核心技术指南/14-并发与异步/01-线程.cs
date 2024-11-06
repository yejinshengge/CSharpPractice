using System.Diagnostics;

namespace CSharpPractice.C_核心技术指南._14_并发与异步;

public class Test_01
{
    // 创建线程
    public static void Test1()
    {
        Thread th = new Thread(PrintY);
        th.Start();
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("X");
        }
    }
    
    // 等待线程结束
    public static void Test2()
    {
        Thread th = new Thread(PrintY);
        th.Start();
        th.Join();
        Console.WriteLine("线程结束");
    }

    public static void PrintY()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("Y");
        }
    }
    // 状态共享
    public static void Test3()
    {
        Test_01 obj = new Test_01();
        Thread th = new Thread(obj.Go);
        th.Start();
        obj.Go();
    }

    private bool _flag = false;
    private void Go()
    {
        if (!_flag)
        {
            Console.WriteLine("Done");
            _flag = true;
        }
    }
    
    // 排他锁
    private readonly object _locker = new object();
    public static void Test4()
    {
        Test_01 obj = new Test_01();
        Thread th = new Thread(obj.Go2);
        th.Start();
        obj.Go2();
    }
    
    private void Go2()
    {
        lock (_locker)
        {
            if (!_flag)
            {
                Console.WriteLine("Done");
                _flag = true;
            }
        }
    }
    
    // Lamda表达式变量捕获
    public static void Test5()
    {
        for (int i = 0; i < 10; i++)
        {
            new Thread(()=>Console.Write(i)).Start();
        }
        Console.WriteLine();
        for (int i = 0; i < 10; i++)
        {
            int tmp = i;
            new Thread(()=>Console.Write(tmp)).Start();
        }
    }
    // 后台线程
    public static void Test6()
    {
        Thread th = new Thread(()=>Console.ReadLine());
        th.IsBackground = true;
        th.Start();
    }
    // 线程优先级
    public static void Test7()
    {
        Thread th = new Thread(()=>Console.ReadLine());
        th.Priority = ThreadPriority.Highest;
        th.Start();

        using var process = Process.GetCurrentProcess();
        process.PriorityClass = ProcessPriorityClass.High;
    }
    
    // 信号发送
    static ManualResetEvent _signal = new ManualResetEvent(false);
    public static void Test8()
    {
        Thread th = new Thread(()=>
        {
            Console.WriteLine("等待信号....");
            _signal.WaitOne();
            _signal.Dispose();
            Console.WriteLine("获得信号！");
        });
        th.Start();
        Thread.Sleep(2000);
        _signal.Set();
    }
}