namespace CSharpPractice.设计模式._18_桥接模式;

public class BridgeMode
{
    public static void BridgeModeMain()
    {
        Abstraction ab = new RefinedAbstraction();
        
        // 设置具体的实现
        ab.SetImplementor(new ConcreteImplementorA());
        ab.Operation();
        
        ab.SetImplementor(new ConcreteImplementorB());
        ab.Operation();
        
        // 输出结果:
        // 具体实现A
        // 具体实现B

        
    }
}
// 实现
public abstract class Implementor
{
    public abstract void Operation();
}
// 具体实现
public class ConcreteImplementorA : Implementor
{
    public override void Operation()
    {
        Console.WriteLine("具体实现A");
    }
}
public class ConcreteImplementorB : Implementor
{
    public override void Operation()
    {
        Console.WriteLine("具体实现B");
    }
}
// 抽象
class Abstraction
{
    protected Implementor Implementor;
 
    public void  SetImplementor(Implementor implementor)
    {
        Implementor = implementor;
    }
 
    public virtual void Operation()
    {
        Implementor.Operation();
    }
}
// 被提炼的抽象
class RefinedAbstraction : Abstraction
{
    public override void Operation()
    {
        Implementor.Operation();
        
    }
}