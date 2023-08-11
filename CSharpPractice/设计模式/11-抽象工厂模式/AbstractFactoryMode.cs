namespace CSharpPractice.设计模式._11_抽象工厂模式;

public class AbstractFactoryMode
{
    public static void AbstractFactoryModeMain()
    {
        // 确定实例化哪个工厂
        // Factory factory = new FactoryA();
        Factory factory = new FactoryB();

        var productA = factory.GetProductA();
        productA.ShowA();

        var productB = factory.GetProductB();
        productB.ShowB();
        
        // 输出结果:
        // ProductA2
        // ProductB2

    }
}
// 抽象工厂类
public abstract class Factory
{
    public abstract ProductA GetProductA();
    public abstract ProductB GetProductB();
}

// 抽象产品类
public abstract class ProductA
{
    public abstract void ShowA();
}
public abstract class ProductB
{
    public abstract void ShowB();
}
// 具体产品类
public class ConcreteProductA1 : ProductA
{
    public override void ShowA()
    {
        Console.WriteLine("ProductA1");
    }
}
public class ConcreteProductA2 : ProductA
{
    public override void ShowA()
    {
        Console.WriteLine("ProductA2");
    }
}
public class ConcreteProductB1 : ProductB
{
    public override void ShowB()
    {
        Console.WriteLine("ProductB");
    }
}
public class ConcreteProductB2 : ProductB
{
    public override void ShowB()
    {
        Console.WriteLine("ProductB2");
    }
}
// 具体工厂类
public class FactoryA : Factory
{
    // 生产A1
    public override ProductA GetProductA()
    {
        return new ConcreteProductA1();
    }

    // 生产B1
    public override ProductB GetProductB()
    {
        return new ConcreteProductB1();
    }
}
public class FactoryB : Factory
{
    // 生产A2
    public override ProductA GetProductA()
    {
        return new ConcreteProductA2();
    }
    // 生产B2
    public override ProductB GetProductB()
    {
        return new ConcreteProductB2();
    }
}