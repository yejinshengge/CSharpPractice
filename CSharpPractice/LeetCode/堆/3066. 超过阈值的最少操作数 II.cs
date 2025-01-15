namespace CSharpPractice.LeetCode.堆;

public class LeetCode_3066
{
    public static void Test()
    {
        LeetCode_3066 obj = new LeetCode_3066();
        // Console.WriteLine(obj.MinOperations(new []{2,11,10,1,3},10));
        // Console.WriteLine(obj.MinOperations(new []{1,1,2,4,9},20));
        Console.WriteLine(obj.MinOperations(new []{1000000000,999999999,1000000000,999999999,1000000000,999999999},1000000000));
    }
    
    public int MinOperations(int[] nums, int k)
    {
        Heap heap = new Heap(nums);
        int count = 0;
        while (heap.Count() >= 2 && heap.Peek() < k)
        {
            var top1 = heap.Pop();
            var top2 = heap.Pop();
            heap.Push(Math.Min(top1,top2)*2+Math.Max(top1,top2));
            count++;
        }

        return count;
    }
}

public class Heap
{
    private long[] _arr;
    private int _count;
    
    public Heap(int[] arr)
    {
        _arr = new long[arr.Length];
        _count = 0;
        foreach (var num in arr)
        {
            Push(num);
        }
    }

    public void Push(long num)
    {
        _arr[_count] = num;
        int parent = (_count - 1) / 2;
        int cur = _count;
        while (_arr[parent] > _arr[cur])
        {
            (_arr[parent], _arr[cur]) = (_arr[cur], _arr[parent]);
            cur = parent;
            parent = (cur - 1) / 2;
        }
        _count++;
    }

    public long Pop()
    {
        long top = _arr[0];
        _arr[0] = _arr[--_count];
        int cur = 0;
        int left = cur*2+1;
        while (left < _count)
        {
            int smaller = left + 1 < _count && _arr[left + 1] < _arr[left] ? left + 1 : left;
            smaller = _arr[cur] < _arr[smaller] ? cur : smaller;
            if(smaller == cur)
                break;
            (_arr[cur], _arr[smaller]) = (_arr[smaller], _arr[cur]);
            cur = smaller;
            left = cur * 2 + 1;
        }

        return top;
    }

    public long Peek()
    {
        return _arr[0];
    }

    public int Count()
    {
        return _count;
    }
}