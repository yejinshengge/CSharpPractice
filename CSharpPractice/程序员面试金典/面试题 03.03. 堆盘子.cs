namespace CSharpPractice.程序员面试金典;

public class LeetCode_03_03
{
    public static void Test()
    {
        LeetCode_03_03 obj = new LeetCode_03_03();
        StackOfPlates stackOfPlates = new StackOfPlates(0);
        Console.WriteLine(stackOfPlates.Pop());
        stackOfPlates.Push(1);
        Console.WriteLine(stackOfPlates.Pop());
    }
}

public class StackOfPlates
{
    private List<List<int>> _stacks;
    private int _cap;
    private int _curStack;
    public StackOfPlates(int cap)
    {
        _curStack = -1;
        _cap = cap;
        _stacks = new List<List<int>>();
    }
    
    public void Push(int val) {
        if(_cap == 0) return;
        if (_curStack == -1 || _stacks[_curStack].Count == _cap)
        {
            _stacks.Add(new List<int>());
            _curStack++;
        }
        _stacks[_curStack].Add(val);
    }
    
    public int Pop()
    {
        if (_curStack < 0)
            return -1;
        int val = _stacks[_curStack][^1];
        _stacks[_curStack].RemoveAt(_stacks[_curStack].Count-1);
        if(_stacks[_curStack].Count == 0)
            _stacks.RemoveAt(_curStack--);
        return val;
    }
    
    public int PopAt(int index)
    {
        if (index > _curStack || index < 0)
            return -1;
        int val = _stacks[index][^1];
        _stacks[index].RemoveAt(_stacks[index].Count-1);
        if (_stacks[index].Count == 0)
        {
            _stacks.RemoveAt(index);
            _curStack--;
        }

        return val;
    }
}
