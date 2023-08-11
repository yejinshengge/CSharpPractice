namespace CSharpPractice.LeetCode.数组篇;

/// <summary>
/// 给你一个长度为 n 的整数数组，每次操作将会使 n - 1 个元素增加 1 。返回让数组所有元素相等的最小操作次数。
/// </summary>
public class Solution453 {

    public static void Test()
    {
        Solution453 obj = new Solution453();
        int[] nums = {1,2,3};
        Console.WriteLine(obj.MinMoves(nums));
    }
    
    public int MinMoves(int[] nums)
    {
        Heap heap = new Heap(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            heap.Insert(nums[i]);
        }

        int res = 0;
        while (!heap.Check())
        {
            res+=heap.AddOne(0);
        }
        return res;
    }


}

public class Heap
{
    private int[] _arr;
    private int _count = 0;

    public Heap(int capacity)
    {
        _arr = new int[capacity];
    }

    public void Insert(int num)
    {
        _arr[_count] = num;
        HeapInsert(_count);
        _count++;
    }

    public int AddOne(int index)
    {
        int diff = _arr[index] - _arr[_count - 1];
        if (diff == 0) diff = 1;
        for (int i = 0; i < _count; i++)
        {
            if (i != index) _arr[i]+=diff;
        }
        Heapify(index);
        return diff;
    }
    
    public bool Check()
    {
        int flag = _arr[0];
        for (int i = 1; i < _arr.Length; i++)
        {
            if (_arr[i] != flag) return false;
        }
        return true;
    }
    private void HeapInsert(int index)
    {
        var parent = (index-1)/2;
        while (_arr[index] > _arr[parent])
        {
            (_arr[index], _arr[parent]) = (_arr[parent], _arr[index]);
            index = parent;
            parent = (index-1)/2;
        }
    }

    private void Heapify(int index)
    {
        // 左孩子
        int left = index * 2 + 1;
        while (left <= _count-1)
        {
            int largest = left;
            if (left + 1 <= _count-1)
                largest = _arr[left] > _arr[left + 1] ? left : left + 1;
            largest = _arr[largest] > _arr[index] ? largest : index;
            if(largest == index)
                break;
            (_arr[index], _arr[largest]) = (_arr[largest], _arr[index]);
            index = largest;
            left = index * 2 + 1;
        }
    }
    
}