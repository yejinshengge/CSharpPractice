namespace CSharpPractice.程序员面试金典;

public class LeetCode_03_01
{
    public static void Test()
    {
        LeetCode_03_01 obj = new LeetCode_03_01();
        TripleInOne stack = new TripleInOne(0);
        stack.Push(0,1);
        stack.Push(0,2);
        stack.Push(0,3);
        Console.WriteLine(stack.Pop(0));
        Console.WriteLine(stack.Pop(0));
        Console.WriteLine(stack.Pop(0));
        Console.WriteLine(stack.Peek(0));
    }
    
    public class TripleInOne
    {
        private int[] _stack;
        private int[] _indexs;
        private int _stackSize;
        public TripleInOne(int stackSize)
        {
            _stack = new int[stackSize * 3];
            _indexs = new int[3]{0,stackSize,2*stackSize};
            _stackSize = stackSize;
        }
    
        public void Push(int stackNum, int value)
        {
            if(_indexs[stackNum] == (stackNum+1)*_stackSize)
                return;
            _stack[_indexs[stackNum]++] = value;
        }
    
        public int Pop(int stackNum)
        {
            if (_indexs[stackNum] == stackNum * _stackSize)
                return -1;
            var num = _stack[--_indexs[stackNum]];
            return num;
        }
    
        public int Peek(int stackNum) {
            if (_indexs[stackNum] == stackNum * _stackSize)
                return -1;
            var num = _stack[_indexs[stackNum]-1];
            return num;
        }
    
        public bool IsEmpty(int stackNum)
        {
            return _indexs[stackNum] == stackNum * _stackSize;
        }
    }
}