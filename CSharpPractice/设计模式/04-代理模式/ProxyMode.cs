namespace CSharpPractice.设计模式._04_代理模式;

public class ProxyMode
{
    public static void ProxyModeMain()
    {
        Proxy proxy = new Proxy();
        proxy.Request();
        // 输出结果:
        // 真实的请求
    }
}

public interface ISubject
{
    public void Request();
}
// 真实实体
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("真实的请求");
    }
}
// 代理
public class Proxy : ISubject
{
    private RealSubject? _realSubject;
    
    public void Request()
    {
        if (_realSubject == null)
        {
            _realSubject = new RealSubject();
        }
        _realSubject.Request();
    }
}