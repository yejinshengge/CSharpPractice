namespace CSharpPractice.设计模式._07_模板方法模式;

public class TemplateMethodMode
{
    public static void TemplateMethodModeMain()
    {
        AbstractClass a;
        a = new ConcreteClassA();
        a.TemplateMethod();

        a = new ConcreteClassB();
        a.TemplateMethod();
        
        // 输出结果:
        // ConcreteClassA Method1
        // ConcreteClassA Method2
        // 模板方法
        // ConcreteClassB Method1
        // ConcreteClassB Method2
        // 模板方法

    }
}

public abstract class AbstractClass
{
    public abstract void Method1();
    public abstract void Method2();

    // 模板方法
    public void TemplateMethod()
    {
        Method1();
        Method2();
        Console.WriteLine("模板方法");
    }
}

public class ConcreteClassA : AbstractClass
{
    public override void Method1()
    {
        Console.WriteLine("ConcreteClassA Method1");
    }

    public override void Method2()
    {
        Console.WriteLine("ConcreteClassA Method2");
    }
}
public class ConcreteClassB : AbstractClass
{
    public override void Method1()
    {
        Console.WriteLine("ConcreteClassB Method1");
    }

    public override void Method2()
    {
        Console.WriteLine("ConcreteClassB Method2");
    }
}