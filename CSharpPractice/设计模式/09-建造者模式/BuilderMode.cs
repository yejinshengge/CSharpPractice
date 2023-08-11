namespace CSharpPractice.设计模式._09_建造者模式;

public class BuilderMode
{
    public static void BuilderModeMain()
    {
        Director director = new Director();
        Builder builderA = new BuilderA();
        Builder builderB = new BuilderB();
        
        director.Construct(builderA);
        var productA = builderA.GetResult();
        productA.Show();
        
        director.Construct(builderB);
        var productB = builderB.GetResult();
        productB.Show();
        
        // 输出结果:
        // 产品包含如下部件：
        // 部件A
        // 部件B
        // 产品包含如下部件：
        // 部件X
        // 部件Y

    }
}

// 产品类,一个产品有多个部件
public class Product
{
    private readonly List<string> _parts = new();

    // 添加部件
    public void AddPart(string part)
    {
        _parts.Add(part);
    }
    // 展示产品
    public void Show()
    {
        Console.WriteLine("产品包含如下部件：");
        foreach (var part in _parts)
        {
            Console.WriteLine(part);
        }
    }
}
// 抽象建造者类,具体建造什么部件由子类决定
public abstract class Builder
{
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract Product GetResult();
}
// 建造者1
public class BuilderA : Builder
{
    private readonly Product _product = new Product();
    
    public override void BuildPartA()
    {
        _product.AddPart("部件A");
    }

    public override void BuildPartB()
    {
        _product.AddPart("部件B");
    }

    public override Product GetResult()
    {
        return _product;
    }
}
// 建造者2
public class BuilderB : Builder
{
    private readonly Product _product = new Product();
    
    public override void BuildPartA()
    {
        _product.AddPart("部件X");
    }

    public override void BuildPartB()
    {
        _product.AddPart("部件Y");
    }

    public override Product GetResult()
    {
        return _product;
    }
}
// 指挥者,用来指挥建造过程
public class Director
{
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}