namespace CSharpPractice.程序员面试金典;

public class LeetCode_03_05
{
    public static void Test()
    {
        LeetCode_03_05 obj = new LeetCode_03_05();
    }
}

public class SortedStack
{
    private Stack<int> _stack1;
    private Stack<int> _stack2;
    
    public SortedStack()
    {
        _stack1 = new Stack<int>();
        _stack2 = new Stack<int>();
    }
    
    public void Push(int val)
    {
        int max = _stack1.Count > 0 ? _stack1.Peek() : int.MaxValue;
        int min = _stack2.Count > 0 ? _stack2.Peek() : int.MinValue;

        if (val > max)
        {
            while (_stack1.Count > 0 && _stack1.Peek() < val)
            {
                _stack2.Push(_stack1.Pop());
            }
            _stack1.Push(val);
        }
        else if (val < min)
        {
            while (_stack2.Count > 0 && _stack2.Peek() > val)
            {
                _stack1.Push(_stack2.Pop());
            }
            _stack2.Push(val);
        }
        else
        {
            _stack1.Push(val);
        }
    }
    
    public void Pop()
    {
        if(IsEmpty())
            return;
        // 将辅助栈压回主栈
        while (_stack2.Count > 0)
        {
            _stack1.Push(_stack2.Pop());
        }
        _stack1.Pop();
    }
    
    public int Peek() {
        if(IsEmpty())
            return -1;
        // 将辅助栈压回主栈
        while (_stack2.Count > 0)
        {
            _stack1.Push(_stack2.Pop());
        }
        return _stack1.Peek();
    }
    
    public bool IsEmpty()
    {
        return _stack1.Count == 0 && _stack2.Count == 0;
    }
}