namespace CSharpPractice.Class01;

public class MyClass {
    public static void MyClassMain()
    {
        // 对象初始化器
        SubClass subClass = new SubClass()
        {
            LastName = "abababa"
        };
        
        // 集合初始化器
        List<SubClass> subClasses = new List<SubClass>()
        {
            new SubClass(),
            new SubClass()
        };
        
        // 解构函数
        string lastName;
        string id;
        (lastName,id) = subClass;
        
        // 静态字段
        SubClass class1 = new SubClass();
        Console.WriteLine(SubClass.Number);
        SubClass class2 = new SubClass();
        Console.WriteLine(SubClass.Number);
        
        // 静态类
        SimpleMath.Max(1, 2);
        
        // 扩展方法
        class1.PrintStr("扩展方法");
    }
}

public class SubClass
{
    // 属性
    private string _LastName;
    public string LastName
    {
        get => _LastName;
        set => _LastName = value ?? throw new ArgumentNullException(nameof(value));
    }
    // 自动实现属性
    private string? Title { get; set; }
    private string? Title2 { get; set; } = "Title2";
    
    // 属性访问修饰符
    private string _id;
    public string Id
    {
        get => _id;
        private set => _id = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Deconstruct(out string lastName, out string id)
    {
        (lastName, id) = (_LastName, _id);
    }
    // 静态字段
    public static int Number;
    public SubClass()
    {
        Number++;
    }

    public static void PrintStr()
    {
        Console.WriteLine("没扩展");
    }
    
    // 静态字段和只读字段
    public const int MAX = Int32.MaxValue;
    public readonly int MIN = Int32.MinValue;
    public static readonly int MIN2 = Int32.MinValue;
    
}

public static class SimpleMath
{
    public static int Max(params int[] arr)
    {
        return arr[0];
    }
}

public static class SubClassExtension
{
    public static void PrintStr(this SubClass sub,string param)
    {
        Console.WriteLine(param);
    }
}

// 分部类
partial class Program
{
    // 分部方法 不允许返回值和out,可以用ref
    partial void Function();
}

partial class Program
{
    partial void Function()
    {
        
    }
}

