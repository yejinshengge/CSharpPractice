namespace CSharpPractice.LeetCode.栈与队列;

// 请你仅使用两个队列实现一个后入先出（LIFO）的栈，并支持普通栈的全部四种操作（push、top、pop 和 empty）。
public class LeetCode_0225
{
    public static void Test()
    {
        LeetCode_0225 obj = new LeetCode_0225();
        MyStack stack = new MyStack();
        
        stack.Push(1);
        stack.Push(2);
        Console.WriteLine(stack.Top());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Empty());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Empty());
    }

}

public class MyStack
{
    private Queue<int> _queue1;
    private Queue<int> _queue2;
    
    public MyStack()
    {
        _queue1 = new Queue<int>();
        _queue2 = new Queue<int>();
    }
    
    public void Push(int x) {
        _queue1.Enqueue(x);
    }
    
    public int Pop() {
        while (_queue1.Count > 1)
        {
            _queue2.Enqueue(_queue1.Dequeue());
        }

        int res = _queue1.Dequeue();
        while (_queue2.Count>0)
        {
            _queue1.Enqueue(_queue2.Dequeue());
        }

        return res;
    }
    
    public int Top()
    {
        int res = Pop();
        _queue1.Enqueue(res);
        return res;
    }
    
    public bool Empty()
    {
        return _queue1.Count == 0 && _queue2.Count == 0;
    }
}