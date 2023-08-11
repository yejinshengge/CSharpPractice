namespace CSharpPractice.设计模式._14_备忘录模式;

public class MementoMode
{
    public static void MementoModeMain()
    {
        Originator originator = new Originator();
        originator.State = "状态A";
        originator.Show();

        // 保存状态
        CareTaker careTaker = new CareTaker();
        careTaker.Memento = originator.CreateMemento();

        originator.State = "状态B";
        originator.Show();
        
        // 恢复状态
        originator.SetMemento(careTaker.Memento);
        originator.Show();
        // 输出结果：
        // State:状态A
        // State:状态B
        // State:状态A
    }
}
// 备忘录的创建者
public class Originator
{
    // 需要保存的属性
    public string State { get; set; }

    // 创建备忘录
    public Memento CreateMemento()
    {
        return new Memento(State);
    }
    // 恢复备忘录
    public void SetMemento(Memento memento)
    {
        State = memento.State;
    }

    public void Show()
    {
        Console.WriteLine("State:"+State);
    }
}

// 备忘录
public class Memento
{
    public string State { get; }

    public Memento(string state)
    {
        State = state;
    }
}
// 备忘录管理者
public class CareTaker
{
    public Memento Memento { get; set; }
}