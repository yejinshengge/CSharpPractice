using System.Collections;

namespace CSharpPractice.设计模式._22_享元模式;

public class FlyweightMode
{
    public static void FlyweightModeMain()
    {
        FlyweightFactory factory = new FlyweightFactory();
        Context context1 = new Context(1, factory.GetFlyweight("X"));
        Context context2 = new Context(2, factory.GetFlyweight("Y"));
        Context context3 = new Context(3, factory.GetFlyweight("Z"));
        
        context1.Operation();
        context2.Operation();
        context3.Operation();
        
        // 输出结果:
        // 外在状态:1 共享状态:1 2
        // 外在状态:2 共享状态:3 4
        // 外在状态:3 共享状态:5 6

    }
}


// 享元类
public class Flyweight
{
    public int Shared1 { get; }
    public int Shared2 { get; }

    public Flyweight(int shared1, int shared2)
    {
        Shared1 = shared1;
        Shared2 = shared2;
    }
}
// 享元工厂
public class FlyweightFactory
{
    private readonly Dictionary<string,Flyweight> _flyweights = new();
    
    public FlyweightFactory()
    {
        // 初始化时生成三个实例
        _flyweights.Add("X",new Flyweight(1,2));
        _flyweights.Add("Y",new Flyweight(3,4));
        _flyweights.Add("Z",new Flyweight(5,6));
    }

    public Flyweight GetFlyweight(string key)
    {
        return _flyweights[key];
    }
}
// 包含享元的上下文类
public class Context
{
    // 外在状态
    public int Unique;
    // 享元队先后
    private Flyweight _shared;

    public Context(int unique,Flyweight shared)
    {
        Unique = unique;
        _shared = shared;
    }

    public void Operation()
    {
        Console.WriteLine($"外在状态:{Unique} 共享状态:{_shared.Shared1} {_shared.Shared2}");
    }
}