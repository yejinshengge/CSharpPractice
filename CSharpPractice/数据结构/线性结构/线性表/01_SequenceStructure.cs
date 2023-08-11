namespace CSharpPractice.数据结构.线性结构.线性表;

public class SequenceStructure {
    public static void SequenceStructureMain()
    {
        SequenceStructure obj = new();
        MyList<int> arr = new MyList<int>(5);
        arr.Insert(0,0);
        arr.Insert(1,1);
        arr.Insert(2,2);
        arr.Insert(3,3);
        
        arr.Delete(3);
        arr.Insert(7,3);
        Console.WriteLine(arr);
    }
}
public interface IMyList<T>
{
    /// <summary>
    /// 查找元素
    /// </summary>
    /// <param name="index">元素下标</param>
    /// <returns></returns>
    public T GetData(int index);
    /// <summary>
    /// 插入元素
    /// </summary>
    /// <param name="e">待插入元素</param>
    /// <param name="index">插入位置</param>
    public void Insert(T e, int index);
    /// <summary>
    /// 删除元素
    /// </summary>
    /// <param name="index">元素下标</param>
    public void Delete(int index);
}
    
public class MyList<T>:IMyList<T>
{
    private T[] _data;
    private int _num;

    public MyList(int maxLength)
    {
        _data = new T[maxLength];
        _num = 0;
    }
        
    public T GetData(int index)
    {
        if (index >= _data.Length || index < 0)
            throw new Exception("下标越界");
        return _data[index];
    }

    public void Insert(T e, int index)
    {
        if (index >= _num+1 || index < 0)
            throw new Exception("下标越界");
        if(_data.Length == _num)
            throw new Exception("数组已满");
        for (int i = _num - 1; i > index; i--)
            _data[i] = _data[i - 1];
        _data[index] = e;
        _num++;
    }

    public void Delete(int index)
    {
        if (index >= _num || index < 0)
            throw new IndexOutOfRangeException("下标越界");
        for (int i = index; i < _num-1; i++)
            _data[i] = _data[i + 1];
        _num--;
    }
}