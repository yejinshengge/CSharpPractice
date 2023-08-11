namespace CSharpPractice.Class01;

public interface MyInterface
{
    void Bar();

}
public interface MyInterface2:MyInterface
{
    // 静态成员
    private static string? _Field;

    public static string? Field
    {
        get => _Field;
        private set => _Field = value;
    }
    // 实例属性和方法
    string FirstName { get; set; }
    string LastName { get; set; }
    public string GetName() => $"{FirstName},{LastName}";
    
    // 修饰符
    public string Pu { get; set; }
    protected string Pro { get; set; }
    private void GetName2()
    {
        Console.WriteLine("private");
    }
    virtual void GetName3()
    {
        Console.WriteLine("virtual");
    }

    sealed void GetName4()
    {
        Console.WriteLine("sealed");
    }

}

public abstract class Child1 : MyInterface
{
    public abstract void Bar();
}

public class Child2 : MyInterface
{
    public void Bar()
    {
        
    }
}