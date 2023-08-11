namespace CSharpPractice.数据结构.线性结构.线性表;

public class StackPractice {
    public static void StackPracticeMain()
    {
        MyStack<int> stack = new MyStack<int>(10);
        Console.WriteLine(stack.IsEmpty());
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        Console.WriteLine(stack.IsEmpty());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        stack.Push(5);
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());

    }
}

public interface IMyStack<T>
{
    public int Count { get; }
    /// <summary>
    /// 入栈
    /// </summary>
    /// <param name="e"></param>
    public void Push(T e);

    /// <summary>
    /// 出栈
    /// </summary>
    /// <returns></returns>
    public T Pop();

    /// <summary>
    /// 获取栈顶元素
    /// </summary>
    /// <returns></returns>
    public T Peek();

    /// <summary>
    /// 栈是否为空
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty();
}

public class MyStack<T> : IMyStack<T>
{
    private readonly T[] _arr;
    private int _top;
    public int Count { get; private set; }

    public MyStack(int size)
    {
        _arr = new T[size];
    }
    public void Push(T e)
    {
        if (Count == _arr.Length)
            throw new StackOverflowException("栈溢出");
        _arr[_top++] = e;
        Count++;
    }

    public T Pop()
    {
        if(Count == 0)
            throw new Exception("栈为空");
        Count--;
        return _arr[--_top];
    }

    public T Peek()
    {
        if(Count == 0)
            throw new Exception("栈为空");
        return _arr[_top-1];
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }
}