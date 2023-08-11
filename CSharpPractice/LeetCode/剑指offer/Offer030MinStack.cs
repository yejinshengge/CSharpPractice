namespace CSharpPractice.LeetCode;

public class Offer030MinStack
{
    public static void Offer030MinStackMain()
    {
        Offer030MinStack obj = new();
        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine(minStack.Min());
        minStack.Pop();
        Console.WriteLine(minStack.Top());
        Console.WriteLine(minStack.Min());
    }
    public class MinStack
    {
        private readonly Stack<int> _stack;
        private readonly Stack<int> _assistStack;
        
        public MinStack()
        {
            _stack = new();
            _assistStack = new();
        }
    
        public void Push(int x) {
            _stack.Push(x);
            if(_assistStack.Count == 0 || x < _assistStack.Peek())
                _assistStack.Push(x);
            else
                _assistStack.Push(_assistStack.Peek());
        }
    
        public void Pop()
        {
            _stack.Pop();
            _assistStack.Pop();
        }
    
        public int Top()
        {
            return _stack.Peek();
        }
    
        public int Min()
        {
            return _assistStack.Peek();
        }
    }
}