using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.栈与队列;

// 给你一个整数数组 nums 和一个整数 k ，请你返回其中出现频率前 k 高的元素。你可以按 任意顺序 返回答案。
public class LeetCode_0347
{
    public static void Test()
    {
        LeetCode_0347 obj = new LeetCode_0347();
        Util.Tools.PrintArr(obj.TopKFrequent(new []{1,1,1,2,2,3},2));
        Util.Tools.PrintArr(obj.TopKFrequent(new []{1},1));
    }
    
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            dic.TryAdd(nums[i], 0);
            dic[nums[i]]++;
        }

        Heap heap = new Heap(dic.Count);
        foreach (var item in dic)
        {
            heap.Push(item.Key,item.Value);
            if (heap.Count > k)
                heap.Pop();
        }

        int[] res = new int[k];
        for (int i = k-1; i >= 0; i--)
        {
            res[i] = heap.Pop();
        }

        return res;
    }
}

public class Heap
{
    private (int, int)[] _arr;
    private int _count;

    public int Count => _count;
    public Heap(int len)
    {
        _arr = new (int, int)[len];
        _count = 0;
    }

    public void Push(int key, int val)
    {
        _arr[_count] = (key, val);
        HeapInsert(_count);
        _count++;
    }

    public int Pop()
    {
        int res = _arr[0].Item1;
        _count--;
        (_arr[0], _arr[_count]) = (_arr[_count], _arr[0]);
        Heapify(0);
        return res;
    }

    private void HeapInsert(int index)
    {
        int parent = (index - 1) / 2;
        while (_arr[index].Item2 < _arr[parent].Item2)
        {
            (_arr[index], _arr[parent]) = (_arr[parent], _arr[index]);
            index = parent;
            parent = (index - 1) / 2;
        }
        
    }

    private void Heapify(int index)
    {
        int left = 2 * index + 1;
        while (left < _count)
        {
            int smallest = left + 1 < _count && _arr[left + 1].Item2 < _arr[left].Item2 ? left + 1 : left;
            // 父节点比子节点大
            if (_arr[smallest].Item2 < _arr[index].Item2)
            {
                (_arr[smallest], _arr[index]) = (_arr[index], _arr[smallest]);
                index = smallest;
                left = 2 * index + 1;
            }
            // 父节点比子节点小
            else
            {
                break;
            }
        }
    }
}