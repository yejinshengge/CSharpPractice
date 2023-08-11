namespace CSharpPractice.设计模式._21_中介者模式;

public class MediatorMode
{
    public static void MediatorModeMain()
    {
        ConcreteMediator mediator = new ConcreteMediator();

        // 让组件认识中介者
        ConcreteComponent1 component1 = new ConcreteComponent1(mediator);
        ConcreteComponent2 component2 = new ConcreteComponent2(mediator);
        
        // 让中介者认识组件
        mediator.Component1 = component1;
        mediator.Component2 = component2;
        
        component1.Send("吃了吗您内");// 组件2接收到消息：吃了吗您内
        component2.Send("吃了");// 组件1接收到消息：吃了
    }
}
// 抽象中介者类
public abstract class Mediator
{
    public abstract void Send(string message, Component component);
}
// 抽象组件
public abstract class Component
{
    protected Mediator Mediator;

    public Component(Mediator mediator)
    {
        Mediator = mediator;
    }
    // 通过中介者发送消息
    public abstract void Send(string message);
    // 通过中介者接收消息
    public abstract void Notify(string message);
}
// 具体中介者类
public class ConcreteMediator : Mediator
{
    public ConcreteComponent1 Component1 { get; set; }
    public ConcreteComponent2 Component2 { get; set; }
    public override void Send(string message, Component component)
    {
        if(component != Component1) Component1.Notify(message);
        else Component2.Notify(message);
    }
}
// 具体组件
public class ConcreteComponent1 : Component
{
    public ConcreteComponent1(Mediator mediator) : base(mediator)
    {
    }

    public override void Send(string message)
    {
        Mediator.Send(message,this);
    }

    public override void Notify(string message)
    {
        Console.WriteLine("组件1接收到消息："+message);
    }
}
public class ConcreteComponent2 : Component
{
    public ConcreteComponent2(Mediator mediator) : base(mediator)
    {
    }

    public override void Send(string message)
    {
        Mediator.Send(message,this);
    }

    public override void Notify(string message)
    {
        Console.WriteLine("组件2接收到消息："+message);
    }
}