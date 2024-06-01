namespace CSharpPractice.程序员面试金典;

public class LeetCode_03_02
{
    public static void Test()
    {
        LeetCode_03_02 obj = new LeetCode_03_02();
        MinStack stack = new MinStack();
        
    }
}

// 栈节点封装最小值
public class MinStack
{
    private List<StackNode> _stack;
    
    
    public MinStack()
    {
        _stack = new List<StackNode>();
    }
    
    public void Push(int x)
    {
        int min = int.MaxValue;
        if (_stack.Count > 0)
            min = _stack[^1].min;
        min = Math.Min(min, x);
        StackNode node = new StackNode()
        {
            val = x,
            min = min
        };
        _stack.Add(node);
    }
    
    public void Pop()
    {
        if(_stack.Count == 0) return;
        _stack.RemoveAt(_stack.Count - 1);
    }
    
    public int Top()
    {
        return _stack[^1].val;
    }
    
    public int GetMin() {
        return _stack[^1].min;
    }

    private class StackNode
    {
        public int val;
        public int min;
    }
}

// 双栈实现