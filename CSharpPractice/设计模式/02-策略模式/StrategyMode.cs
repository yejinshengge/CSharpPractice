namespace CSharpPractice.设计模式._02_策略模式;

public class StrategyMode
{
    
}

public class Context
{
    private readonly IOperation _operation;

    // public Context(IOperation operation)
    // {
    //     _operation = operation;
    // }

    public Context(string type)
    {
        switch (type)
        {
            case "A":
                _operation = new OperationA();
                break;
            case "B":
                _operation = new OperationB();
                break;
            case "C":
                _operation = new OperationC();
                break;
        }
    }
    public void Operate()
    {
        _operation.Operate();
    }
}

public interface IOperation
{
    public void Operate();
}

public class OperationA:IOperation
{
    public void Operate()
    {
        Console.WriteLine("OperationA");
    }
}
public class OperationB:IOperation
{
    public void Operate()
    {
        Console.WriteLine("OperationB");
    }
}
public class OperationC:IOperation
{
    public void Operate()
    {
        Console.WriteLine("OperationC");
    }
}