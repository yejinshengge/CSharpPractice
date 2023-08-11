namespace CSharpPractice.设计模式._20_职责链模式;

public class ChainOfResponsibilityMode
{
    public static void ChainOfResponsibilityModeMain()
    {
        Handler handler1 = new ConcreteHandler1();
        Handler handler2 = new ConcreteHandler2();
        
        handler1.SetSuccessor(handler2);
        
        handler1.HandleRequest(1);// handler1处理
        handler1.HandleRequest(11);// handler2处理
        
        // 输出结果:
        // ConcreteHandler1处理请求：1
        // ConcreteHandler2处理请求：11

    }
}
// 处理者接口
public abstract class Handler
{
    // 继任者
    protected Handler Successor;

    public void SetSuccessor(Handler successor)
    {
        Successor = successor;
    }
    // 处理请求
    public abstract void HandleRequest(int request);
}
// 具体处理者
public class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request < 10)
        {
            Console.WriteLine("ConcreteHandler1处理请求："+request);
        }
        else
        {
            // 交给下一位处理
            Successor.HandleRequest(request);
        }
    }
}
public class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10)
        {
            Console.WriteLine("ConcreteHandler2处理请求："+request);
        }
        else
        {
            // 交给下一位处理
            Successor.HandleRequest(request);
        }
    }
}