namespace CSharpPractice.数据结构.练习;

public class HuffmanTree {

    public static void Test()
    {
        int[] arr = new[] {3, 5, 10, 16, 20, 22};
        var huffman = ConstructHuffman(arr);

        Console.WriteLine(huffman);
    }
    
    public static HuffmanTreeNode ConstructHuffman(int[] arr)
    {
        Heap<HuffmanTreeNode> heap = new Heap<HuffmanTreeNode>(arr.Length);
        for (int i = 0; i < arr.Length; i++)
        {
            heap.Push(new HuffmanTreeNode(arr[i]));
        }

        while (heap.Count > 1)
        {
            var left = heap.Pop();
            var right = heap.Pop();

            var node = new HuffmanTreeNode(left.Weight + right.Weight);
            node.Left = left;
            node.Right = right;
            
            heap.Push(node);
        }
        
        return heap.Pop();
    }
    
}

public class HuffmanTreeNode:IComparable<HuffmanTreeNode>
{
    public int Weight;
    public HuffmanTreeNode? Left;
    public HuffmanTreeNode? Right;

    public HuffmanTreeNode(int weight)
    {
        Weight = weight;
    }


    public int CompareTo(HuffmanTreeNode? other)
    {
        if (other == null) return 1;
        return Weight - other.Weight;
    }
}

public class Heap<T> where T:IComparable<T>
{
    private int _length;
    private int _count;
    private T[] _arr;
    public int Count => _count;
    public Heap(int capacity)
    {
        _length = capacity;
        _arr = new T[capacity];
    }

    public void Push(T item)
    {
        _arr[_count] = item;
        HeapInsert(_count);
        _count++;
    }

    public T Pop()
    {
        var res = _arr[0];
        (_arr[0], _arr[_count - 1]) = (_arr[_count - 1], _arr[0]);
        _count--;
        Heapify(0);
        return res;
    }

    private void HeapInsert(int index)
    {
        int parent = (index - 1) / 2;
        while (_arr[parent].CompareTo( _arr[index]) > 0)
        {
            (_arr[parent], _arr[index]) = (_arr[index], _arr[parent]);
            index = parent;
            parent = (index - 1) / 2;
        }
    }

    private void Heapify(int index)
    {
        int left = index * 2 + 1;
        while (left<_count)
        {
            int min = left;
            if (left + 1 < _count && _arr[left+1].CompareTo(_arr[left]) < 0)
            {
                min = left + 1;
            }
            if(_arr[index].CompareTo(_arr[min]) < 0)
                return;
            (_arr[index], _arr[min]) = (_arr[min], _arr[index]);
            index = min;
            left = index * 2 + 1;
        }
    }
}