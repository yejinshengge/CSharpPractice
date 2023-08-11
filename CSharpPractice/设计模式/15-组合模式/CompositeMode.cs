namespace CSharpPractice.设计模式._15_组合模式;

public class CompositeMode
{
    public static void CompositeModeMain()
    {
        Composite root = new Composite("Root");
        root.Add(new Leaf("C"));
        root.Add(new Leaf("D"));
        
        var compositeA = new Composite("A");
        compositeA.Add(new Leaf("E"));
        compositeA.Add(new Leaf("F"));
        root.Add(compositeA);
        
        var compositeB = new Composite("B");
        compositeB.Add(new Leaf("G"));
        compositeB.Add(new Leaf("H"));
        root.Add(compositeB);
        
        root.Display(1);
        
        // 输出结果:
        // -Root
        // ---C
        // ---D
        // ---A
        // -----E
        // -----F
        // ---B
        // -----G
        // -----H


    }
}

// 组件抽象类
public abstract class Component
{
    protected string Name;

    public Component(string name)
    {
        Name = name;
    }

    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
}
// 叶节点类
public class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }
    // 叶节点本身无法添加或删除节点,这样做是为了消除叶节点和枝节点在抽象层次的区别
    public override void Add(Component c)
    {
        Console.WriteLine("无法添加节点");
    }

    public override void Remove(Component c)
    {
        Console.WriteLine("无法删除节点");
    }
    // 显示叶节点
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-',depth)+Name);
    }
}
// 枝节点类
public class Composite : Component
{
    // 用来存储子对象
    private readonly List<Component> _children = new();
    
    public Composite(string name) : base(name)
    {
    }

    public override void Add(Component c)
    {
        _children.Add(c);
    }

    public override void Remove(Component c)
    {
        _children.Remove(c);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-',depth)+Name);
        foreach (var child in _children)
        {
            child.Display(depth+2);
        }
    }
}