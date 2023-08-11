namespace CSharpPractice.设计模式._17_单例模式;

public class SingletonMode
{
    public static void SingletonModeMain()
    {
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();

        Console.WriteLine(s1 == s2);
    }
}

public class Singleton
{
    // 持有一个自己的实例
    private static Singleton _instance;
    
    // 构造函数私有化防止外部创建实例
    private Singleton()
    {
        
    }

    // 获取唯一实例
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }
}
// 饿汉式单例类,加sealed关键字防止派生增加实例
public sealed class Singleton2
{
    // 持有一个自己的实例
    private static readonly Singleton2 _instance = new Singleton2();
    
    // 构造函数私有化防止外部创建实例
    private Singleton2()
    {
        
    }

    // 获取唯一实例
    public static Singleton2 GetInstance()
    {
        return _instance;
    }
}