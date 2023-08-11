namespace CSharpPractice.设计模式._06_原型模式;

public class PrototypeMode
{
    public static void PrototypeModeMain()
    {
        ConcretePrototype p1 = new ConcretePrototype("123456");
        ConcretePrototype p2 = (ConcretePrototype)p1.Clone();

        Console.WriteLine(p1.Id);
        Console.WriteLine(p2.Id);
        // 输出结果:
        // 123456
        // 123456

    }
}
// 原型接口,声明克隆方法
public interface IPrototype
{
    public IPrototype Clone();
}
// 具体原型类
public class ConcretePrototype:IPrototype
{
    public string Id;

    public ConcretePrototype(string id)
    {
        Id = id;
    }
    public IPrototype Clone()
    {
        // 浅复制
        return (IPrototype)this.MemberwiseClone();
    }
}