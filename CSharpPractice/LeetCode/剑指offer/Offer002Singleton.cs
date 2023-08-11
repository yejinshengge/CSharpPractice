namespace CSharpPractice.LeetCode.剑指offer;

public sealed class Singleton1
{
    private static object _syncObj = new object();
    private static Singleton1 _instance;

    public static Singleton1 Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_syncObj)
                {
                    if (_instance == null)
                        _instance = new Singleton1();
                }
            }
            return _instance;
        }
    }
    
    
    private Singleton1(){}
}

public sealed class Singleton2
{
    public static Singleton2 Instance { get; } = new Singleton2();

    private Singleton2(){}
}

public sealed class Singleton3
{
    private Singleton3(){}
    public Singleton3 Instance => Nested.Instance;
    private class Nested
    {
        internal static readonly Singleton3 Instance = new Singleton3();
    }
}