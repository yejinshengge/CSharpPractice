namespace CSharpPractice.设计模式._19_命令模式;

public class CommandMode
{
    public static void CommandModeMain()
    {
        Command command = new ConcreteCommand(new Receiver());
        Invoker invoker = new Invoker();
        
        invoker.SetCommand(command);
        invoker.ExecuteCommand();
    }
}
// 命令执行所需的类
public class Receiver
{
    public void Action()
    {
        Console.WriteLine("执行命令");
    }
}
// 命令抽象类
public abstract class Command
{
    protected Receiver Receiver;

    public Command(Receiver receiver)
    {
        Receiver = receiver;
    }
    // 执行命令
    public abstract void Execute();
}
// 具体命令
class ConcreteCommand : Command
{
    public ConcreteCommand(Receiver receiver) : base(receiver)
    { }
 
    public override void Execute()
    {
        Receiver.Action();
    }
}
// 命令发起者
class Invoker
{
    private Command _command;
 
    public void SetCommand(Command command)
    {
        _command = command;
    }
 
    public void ExecuteCommand()
    {
        _command.Execute();
    }
}