namespace CSharpPractice.设计模式._24_访问者模式;

public class VisitorMode
{
    public static void VisitorModeMain()
    {
        ObjectStructure obj = new ObjectStructure();
        obj.Attach(new ConcreteElementA());
        obj.Attach(new ConcreteElementB());

        ConcreteVisitor1 v1 = new ConcreteVisitor1();
        ConcreteVisitor2 v2 = new ConcreteVisitor2();
        
        obj.Accept(v1);
        obj.Accept(v2);
        
        // 输出结果:
        // ConcreteElementA 被 ConcreteVisitor1 访问
        // ConcreteElementB 被 ConcreteVisitor1 访问
        // ConcreteElementA 被 ConcreteVisitor2 访问
        // ConcreteElementB 被 ConcreteVisitor2 访问

    }
}
// 访问者抽象类
public abstract class Visitor
{
    public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
 
    public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
}
// 被访问的元素抽象类
public abstract class Element
{
    public abstract void Accept(Visitor visitor);
}
// 具体被访问的元素
public class ConcreteElementA:Element
{
    public override void Accept(Visitor visitor)
    {
        // 双分派技术实现处理与数据结构分离
        visitor.VisitConcreteElementA(this);
    }
    // 其他专有方法
    public void OperationA(){}
}
public class ConcreteElementB:Element
{
    public override void Accept(Visitor visitor)
    {
        // 双分派技术实现处理与数据结构分离
        visitor.VisitConcreteElementB(this);
    }
    // 其他专有方法
    public void OperationB(){}
}
// 具体访问者类
public class ConcreteVisitor1 : Visitor
{
    public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        Console.WriteLine($"{concreteElementA.GetType().Name} 被 ConcreteVisitor1 访问");
    }

    public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        Console.WriteLine($"{concreteElementB.GetType().Name} 被 ConcreteVisitor1 访问");
    }
}

public class ConcreteVisitor2 : Visitor
{
    public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        Console.WriteLine($"{concreteElementA.GetType().Name} 被 ConcreteVisitor2 访问");
    }

    public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        Console.WriteLine($"{concreteElementB.GetType().Name} 被 ConcreteVisitor2 访问");
    }
}
// 枚举被访问元素的类
class ObjectStructure
{
    private readonly IList<Element> _elements = new List<Element>();
 
    public void Attach(Element element)
    {
        _elements.Add(element);
    }
    public void Detach(Element element)
    {
        _elements.Remove(element);
    }
    public void Accept(Visitor visitor)
    {
        foreach (Element e in _elements)
        {
            e.Accept(visitor);
        }
    }
}