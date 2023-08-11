namespace CSharpPractice.设计模式._05_工厂方法模式;

public class FactoryMethodMode
{
    public static void FactoryMethodModeMain()
    {
        Factory factory1 = new FactoryA();
        var product1 = factory1.CreateProduct();
        
        Factory factory2 = new FactoryB();
        var product2 = factory2.CreateProduct();
        
        Factory factory3 = new FactoryC();
        var product3 = factory3.CreateProduct();
    }
}
// 抽象产品类
public abstract class Product { }
// 具体产品类
public class ProductA:Product { }
public class ProductB:Product { }
public class ProductC:Product { }

// 抽象工厂类
public abstract class Factory
{
    public abstract Product CreateProduct();
}
// 具体工厂类
public class FactoryA : Factory
{
    public override Product CreateProduct()
    {
        return new ProductA();
    }
}
public class FactoryB : Factory
{
    public override Product CreateProduct()
    {
        return new ProductB();
    }
}
public class FactoryC : Factory
{
    public override Product CreateProduct()
    {
        return new ProductC();
    }
}