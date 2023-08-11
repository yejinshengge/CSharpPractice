namespace CSharpPractice.设计模式._08_外观模式;

public class FacadeMode
{
    public static void FacadeModeMain()
    {
        Facade facade = new Facade();
        facade.Method1();
        Console.WriteLine("————————————");
        facade.Method2();
        
        // 输出结果:
        // 子系统方法一
        // 子系统方法二
        // 子系统方法三
        // ————————————
        // 子系统方法一
        // 子系统方法四

    }
}

// 子系统
class SubSystemOne
{
    public void MethodOne()
    {
        Console.WriteLine(" 子系统方法一");
    }
}
 
class SubSystemTwo
{
    public void MethodTwo()
    {
        Console.WriteLine(" 子系统方法二");
    }
}
 
class SubSystemThree
{
    public void MethodThree()
    {
        Console.WriteLine(" 子系统方法三");
    }
}
 
class SubSystemFour
{
    public void MethodFour()
    {
        Console.WriteLine(" 子系统方法四");
    }
}
// 外观类
public class Facade
{
    private SubSystemOne _one;
    private SubSystemTwo _two;
    private SubSystemThree _three;
    private SubSystemFour _four;

    public Facade()
    {
        _one = new SubSystemOne();
        _two = new SubSystemTwo();
        _three = new SubSystemThree();
        _four = new SubSystemFour();
    }

    public void Method1()
    {
        _one.MethodOne();
        _two.MethodTwo();
        _three.MethodThree();
    }

    public void Method2()
    {
        _one.MethodOne();
        _four.MethodFour();
    }
}