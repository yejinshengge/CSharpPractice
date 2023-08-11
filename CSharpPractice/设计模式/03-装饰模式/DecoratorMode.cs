namespace CSharpPractice.设计模式._03_装饰模式;

public class DecoratorMode
{
    public static void DecoratorModeMain()
    {
        // 原始数据
        ConcreteComponent c = new ConcreteComponent();
        // 装饰类对象
        ConcreteDecoratorA a = new ConcreteDecoratorA();
        ConcreteDecoratorB b = new ConcreteDecoratorB();
        
        // 开始套娃(装饰)
        a.SetComponent(c);
        b.SetComponent(a);
        b.Operation();
        
        // 输出结果:
        // ConcreteComponent
        // ConcreteDecoratorA
        // ConcreteDecoratorB

    }
}


public abstract class Component
{
    public abstract void Operation();
}
// 原始组件
public class ConcreteComponent : Component
{
    public override void Operation()
    {
        Console.WriteLine("ConcreteComponent");
    }
}
// 抽象装饰类
public abstract class Decorator : Component
{
    protected Component? Component;

    public void SetComponent(Component component)
    {
        Component = component;
    }

    public override void Operation()
    {
        // 执行的是被装饰对象的Operation()
        Component?.Operation();
    }
}
// 具体装饰类
public class ConcreteDecoratorA : Decorator
{
    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("ConcreteDecoratorA");
    }
}
public class ConcreteDecoratorB : Decorator
{
    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("ConcreteDecoratorB");
    }
}
