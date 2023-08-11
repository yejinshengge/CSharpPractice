namespace CSharpPractice.设计模式._16_迭代器模式;

public class IteratorMode
{
    public static void IteratorModeMain()
    {
        // 聚集对象
        ConcreteAggregate aggregate = new ConcreteAggregate();
        aggregate[0] = "A";
        aggregate[1] = "B";
        aggregate[2] = "C";
        aggregate[3] = "D";

        Iterator iterator = new ConcreteIterator(aggregate);
        
        while (!iterator.IsDone())
        {
            Console.WriteLine(iterator.CurrentItem());
            iterator.Next();
        }
    }
}
// 迭代器抽象类
public abstract class Iterator
{
    // 得到起始元素
    public abstract object? First();
    // 得到下一元素
    public abstract object? Next();
    // 判断是否到达结尾
    public abstract bool IsDone();
    // 返回当前元素
    public abstract object? CurrentItem();
}
// 聚集抽象类
public abstract class Aggregate
{
    // 创建迭代器
    public abstract Iterator CreateIterator();
}
// 具体迭代器类
public class ConcreteIterator : Iterator
{
    private readonly ConcreteAggregate _aggregate;
    private int _current = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    
    public override object? First()
    {
        if (_aggregate.Count == 0) return null;
        return _aggregate[0];
    }

    public override object? Next()
    {
        object? res = null;
        _current++;
        if (_current < _aggregate.Count)
        {
            res = _aggregate[_current];
        }
        return res;
    }

    public override bool IsDone()
    {
        return _current >= _aggregate.Count;
    }

    public override object? CurrentItem()
    {
        if (_aggregate.Count == 0) return null;
        return _aggregate[_current];
    }
}
// 具体聚集类
public class ConcreteAggregate : Aggregate
{
    private readonly IList<object> _items = new List<object>();

    public int Count => _items.Count;

    public object this[int index]
    {
        get => _items[index];
        set => _items.Insert(index, value);
    }
    public override Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }
}