namespace CSharpPractice.LeetCode.栈与队列;
// 请你仅使用两个栈实现先入先出队列。队列应当支持一般队列支持的所有操作（push、pop、peek、empty）
public class LeetCode_0232
{
    public static void Test()
    {
        LeetCode_0232 obj = new LeetCode_0232();

        MyQueue queue = new MyQueue();
        queue.Push(1);
        queue.Push(2);
        Console.WriteLine(queue.Peek());
        Console.WriteLine(queue.Pop());
        Console.WriteLine(queue.Empty());
        
    }

}

public class MyQueue
{
    private Stack<int> _stack1;
    private Stack<int> _stack2;
    
    public MyQueue()
    {
        _stack1 = new Stack<int>();
        _stack2 = new Stack<int>();
    }
    
    public void Push(int x) {
        _stack1.Push(x);
    }
    
    public int Pop()
    {
        if (_stack2.Count == 0)
        {
            while (_stack1.Count>0)
            {
                _stack2.Push(_stack1.Pop());
            }
        }

        return _stack2.Pop();
    }
    
    public int Peek() {
        if (_stack2.Count == 0)
        {
            while (_stack1.Count>0)
            {
                _stack2.Push(_stack1.Pop());
            }
        }

        return _stack2.Peek();
    }
    
    public bool Empty()
    {
        return _stack1.Count == 0 && _stack2.Count == 0;
    }
}