namespace CSharpPractice.设计模式._13_适配器模式;

public class AdapterMode
{
    public static void AdapterModeMain()
    {
        Target target = new Adapter();
        target.TargetRequest();
        // 输出结果:
        // Origin请求
    }
}
// 客户端期待的接口或类
public class Target
{
    public virtual void TargetRequest()
    {
        Console.WriteLine("Target请求");
    }
}
// 需要适配的接口或类
public class Origin
{
    public virtual void OriginRequest()
    {
        Console.WriteLine("Origin请求");
    }
}
// 适配器
public class Adapter : Target
{
    private Origin _origin = new Origin();
    
    // 表面调用TargetRequest(),实际调用OriginRequest()
    public override void TargetRequest()
    {
        _origin.OriginRequest();
    }
}