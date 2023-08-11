namespace CSharpPractice.设计模式._10_观察者模式;

public class ObserverMode
{
    public static void ObserverModeMain()
    {
        ConcreteSubject subject = new ConcreteSubject();
        
        subject.Add(new ConcreteObserver("A",subject));
        subject.Add(new ConcreteObserver("B",subject));
        subject.Add(new ConcreteObserver("C",subject));

        subject.SubjectState = "ABC";
        subject.Notify();
        
        // 输出结果:
        // 观察者 A 的新状态为 ABC
        // 观察者 B 的新状态为 ABC
        // 观察者 C 的新状态为 ABC

    }
}
// 抽象观察者
public abstract class Observer
{
    // 更新
    public abstract void Update();
}
// 抽象通知者
public abstract class Subject
{
    private readonly List<Observer> _observers = new();

    // 添加观察者
    public void Add(Observer observer)
    {
        _observers.Add(observer);
    }
    // 删除观察者
    public void Delete(Observer observer)
    {
        _observers.Remove(observer);
    }
    // 通知观察者
    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}
// 具体观察者
public class ConcreteObserver:Observer
{
    private string _name;
    private string? _observeState;
    private ConcreteSubject _subject;

    public ConcreteObserver(string name,ConcreteSubject subject)
    {
        _name = name;
        _subject = subject;
    }
    
    public override void Update()
    {
        _observeState = _subject.SubjectState;
        Console.WriteLine($"观察者 {_name} 的新状态为 {_observeState}");
    }
}
// 具体通知者
public class ConcreteSubject : Subject
{
    public string? SubjectState { get; set; }
}