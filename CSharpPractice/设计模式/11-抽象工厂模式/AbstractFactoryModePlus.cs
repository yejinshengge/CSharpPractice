using System.Reflection;

namespace CSharpPractice.设计模式._11_抽象工厂模式;

public class AbstractFactoryModePlus
{
    public static void AbstractFactoryModePlusMain()
    {
        var productA = FactoryPlus.GetProductA();
        productA.ShowA();

        var productB = FactoryPlus.GetProductB();
        productB.ShowB();
    }
}

public class FactoryPlus
{
    // private static readonly string ProductType = "1";
    private static readonly string ProductType = "2";
    
    public static ProductA GetProductA()
    {
        // 通过反射避免了手动添加分支
        string className = "CSharpPractice.设计模式._11_抽象工厂模式.ConcreteProductA" + ProductType;
        return (ProductA) Assembly.Load("CSharpPractice").CreateInstance(className);
    }
    
    public static ProductB GetProductB()
    {
        string className = "CSharpPractice.设计模式._11_抽象工厂模式.ConcreteProductB" + ProductType;
        return (ProductB) Assembly.Load("CSharpPractice").CreateInstance(className);
    }
}