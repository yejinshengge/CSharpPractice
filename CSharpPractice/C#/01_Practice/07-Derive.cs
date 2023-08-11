namespace CSharpPractice.Class01;

public class Derive {
    public static void DeriveMain()
    {
        // 基类和派生类之间的转型
        Appointment appointment = new Appointment();
        PdaItem item = appointment;

        PdaItem item2 = new PdaItem();
        //Appointment appointment2 = (Appointment)item2;
        Appointment appointment2 = new Appointment();
        
        // 扩展方法
        item.PdaItemExt();
        item2.PdaItemExt();
        appointment2.PdaItemExt();
        
        // 虚方法
        ThirdClass thirdClass = new ThirdClass();
        PdaItem item3 = thirdClass;
        Appointment appointment3 = thirdClass;
        thirdClass.GetName();
        item3.GetName();
        appointment3.GetName();

    }
}

public class PdaItem
{
    private string m_type;
    protected string m_name;
    
    // 虚方法
    public virtual void GetName() {
        Console.WriteLine("PdaItem");
    }
}

public class Appointment : PdaItem
{
    // 自定义转换
    // 隐式转换
    public static implicit operator OtherClass(Appointment appointment)
    {
        return appointment;
    }

    public void Fun()
    {
        m_name = "ababa";
    }

    public override void GetName() {
        Console.WriteLine("Appointment");
    }
}

public class ThirdClass : Appointment
{
    public new void GetName() {
        Console.WriteLine("ThirdClass");
    }
}

public class OtherClass
{
    // 显式转换
    public static explicit operator Appointment(OtherClass appointment)
    {
        return null;
    }


}
public static class PdaItemCLass
{
    public static void PdaItemExt(this PdaItem item)
    {
        Console.WriteLine("PdaItem扩展方法");
    }
    
    public static void PdaItemExt(this Appointment item)
    {
        Console.WriteLine("Appointment扩展方法");
    }
}

// 密封类
public sealed class CommandLineParser
{
    
}
// 抽象类
public abstract class AbstractClass
{
    public virtual string Name { get; set; }
    public abstract void Print();
}

public class Child : AbstractClass
{
    public override void Print()
    {
        Console.WriteLine("Child.Print");
    }
}
