namespace CSharpPractice.LeetCode.初级算法;

/**
    设计一个支持 push ，pop ，top 操作，并能在常数时间内检索到最小元素的栈。
    实现 MinStack 类:
    MinStack() 初始化堆栈对象。
    void push(int val) 将元素val推入堆栈。
    void pop() 删除堆栈顶部的元素。
    int top() 获取堆栈顶部的元素。
    int getMin() 获取堆栈中的最小元素。
 */
public class LeetCode_039
{
    public static void Test()
    {
        LeetCode_039 obj = new LeetCode_039();
        MinStack stack = new MinStack();
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-3);
        Console.WriteLine(stack.GetMin());
        stack.Pop();
        Console.WriteLine(stack.Top());
        Console.WriteLine(stack.GetMin());
    }

}

// 思路一:链表实现
public class MinStack
{
    private class ListNode
    {
        public int val;
        public int min;
        public ListNode next;

        public ListNode(int val, int min, ListNode next)
        {
            this.val = val;
            this.min = min;
            this.next = next;
        }
    }

    private ListNode head;

    public void Push(int val)
    {
        if (head == null)
            head = new ListNode(val, val, null);
        else
            head = new ListNode(val, Math.Min(val, head.min), head);
    }
    
    public void Pop()
    {
        if(head == null) throw new IndexOutOfRangeException("栈为空");
        head = head.next;
    }
    
    public int Top()
    {
        if(head == null) throw new IndexOutOfRangeException("栈为空");
        return head.val;
    }
    
    public int GetMin() {
        if(head == null) throw new IndexOutOfRangeException("栈为空");
        return head.min;
    }
}

// 思路二:单个栈
public class MinStack2
{
    private Stack<int> _stack = new();
    private int _min = int.MaxValue;
    
    public void Push(int val)
    {
        if (val <= _min)
        {
            _stack.Push(_min);
            _min = val;
        }
        _stack.Push(val);
    }
    
    public void Pop()
    {
        if (_stack.Pop() == _min)
            _min = _stack.Pop();
    }
    
    public int Top()
    {
        return _stack.Peek();
    }
    
    public int GetMin()
    {
        return _min;
    }
}