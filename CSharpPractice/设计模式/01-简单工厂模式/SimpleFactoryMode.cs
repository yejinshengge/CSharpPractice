namespace CSharpPractice.设计模式._01_简单工厂模式;

public class SimpleFactoryMode
{
    public static void SimpleFactoryModeMain()
    {
        Product productA = SimpleFactory.CreateProduct("A");
        productA.Operate();
        
        Product productB = SimpleFactory.CreateProduct("B");
        productB.Operate();
        
        Product productC = SimpleFactory.CreateProduct("C");
        productC.Operate();
        
        // 输出结果:
        // OperationA
        // OperationB
        // OperationC
   
    }
}

// 简单工厂
public class SimpleFactory
{
    public static Product? CreateProduct(string param)
    {
        Product? product = null;
        switch (param)
        {
            case "A":
                product = new ProductA();
                break;
            case "B":
                product = new ProductB();
                break;
            case "C":
                product = new ProductC();
                break;
        }
        return product;
    }
}

// 抽象产品类
public abstract class Product
{
    public abstract void Operate();
}
// 具体产品类
public class ProductA:Product
{
    public override void Operate()
    {
        Console.WriteLine("OperationA");
    }
}
public class ProductB:Product
{
    public override void Operate()
    {
        Console.WriteLine("OperationB");
    }
}
public class ProductC:Product
{
    public override void Operate()
    {
        Console.WriteLine("OperationC");
    }
}