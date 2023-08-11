namespace CSharpPractice.设计模式._12_状态模式;

public class StateMode
{
    public static void StateModeMain()
    {
        Context context = new Context(new StateA());
        context.Request();
        context.Request();
        context.Request();
        context.Request();
        
        // 输出结果:
        // 当前状态：StateA
        // 当前状态：StateB
        // 当前状态：StateA
        // 当前状态：StateB

    }
}

// 抽象状态类
public abstract class State
{
    public abstract void Handle(Context context);
}
// 状态管理类
public class Context
{
    public State CurrentState { get; set; }
    // 初始化时指定初始状态
    public Context(State state)
    {
        CurrentState = state;
    }
    // 处理当前状态逻辑
    public void Request()
    {
        CurrentState.Handle(this);
    }
}
// 状态A
public class StateA : State
{
    public override void Handle(Context context)
    {
        Console.WriteLine("当前状态：StateA");
        // 下一个状态为状态B
        context.CurrentState = new StateB();
    }
}
// 状态B
public class StateB : State
{
    public override void Handle(Context context)
    {
        Console.WriteLine("当前状态：StateB");
        // 下一个状态为状态A
        context.CurrentState = new StateA();
    }
}