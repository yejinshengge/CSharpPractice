namespace CSharpPractice.LeetCode;

public class Offer009CQueue
{
    public class CQueue
    {
        private readonly Stack<int> _inStack, _outStack;
        public CQueue()
        {
            _inStack = new();
            _outStack = new();
        }
    
        public void AppendTail(int value) {
            // 新元素直接压入输入栈
            _inStack.Push(value);
        }
    
        public int DeleteHead()
        {
            if (_outStack.Count == 0)
            {
                // 两个栈都没有元素,直接返回-1
                if (_inStack.Count == 0)
                {
                    return -1;
                }
                // 把输入栈的元素挪入输出栈
                while (_inStack.Count > 0)
                {
                    _outStack.Push(_inStack.Pop());
                }
            }
            return _outStack.Pop();
        }
    }

    private void Call()
    {
        CQueue obj = new CQueue();
        obj.AppendTail(3);
        int param_2 = obj.DeleteHead();
        Console.WriteLine(param_2);
        var param_3 = obj.DeleteHead();
        Console.WriteLine(param_3);
    }
    public static void Offer009CQueueMain()
    {
        Offer009CQueue obj = new();
        obj.Call();
    }
}