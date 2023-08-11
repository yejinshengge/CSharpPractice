using System.Collections;

namespace CSharpPractice.数据结构.堆;

public class HeapPractice {
    public static void HeapPracticeMain()
    {
        HeapList<int> heapList = new();
        heapList.Push(6);
        heapList.Push(5);
        heapList.Push(4);
        heapList.Push(3);
        heapList.Push(7);

        Console.WriteLine(heapList.Pop());
        Console.WriteLine(heapList.Pop());
        Console.WriteLine(heapList.Pop());
        
        Console.WriteLine(heapList);
    }
}

public class HeapList<T> where T : IComparable<T>
{
    private T[] _items;
    // 默认数组大小
    private const int DefaultCapacity = 4;
    // 元素数量
    private int _size;
    public int Count => _size;
    // 当前数组大小
    public int Capacity
    {
        get => _items.Length;
        set
        {
            if (value < _size)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (value != _items.Length)
            {
                if (value > 0)
                {
                    T[] newItems = new T[value];
                    if (_size > 0)
                    {
                        Array.Copy(_items, newItems, _size);
                    }
                    _items = newItems;
                }
                else
                {
                    _items = new T[DefaultCapacity];
                }
            }
        }
    }
    
    public HeapList()
    {
        _items = new T[DefaultCapacity];
    }

    public HeapList(int length)
    {
        _items = new T[length];
    }
    
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException();
            return _items[index];
        }
    }

    /// <summary>
    /// 压入元素
    /// </summary>
    /// <param name="e"></param>
    public void Push(T e)
    {
        // 扩容
        if (_size >= _items.Length)
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            if ((uint)newCapacity > Array.MaxLength) newCapacity = Array.MaxLength;
            Capacity = newCapacity;
        }

        _items[_size] = e;
        HeapInsert(_size++);
    }

    /// <summary>
    /// 弹出元素
    /// </summary>
    public T Pop()
    {
        if (_size <= 0) throw new ArgumentOutOfRangeException();
        var node = _items[0];
        // 交换首尾元素
        (_items[_size - 1], _items[0]) = (_items[0], _items[_size - 1]);
        _size--;
        // 下沉操作
        Heapify(0);
        return node;
    }
    /// <summary>
    /// 上浮操作
    /// </summary>
    /// <param name="index"></param>
    private void HeapInsert(int index)
    {
        // 当前节点比父节点小,交换两者位置
        int parentIndex = (index - 1) / 2;
        while(_items[index].CompareTo(_items[parentIndex]) < 0 )
        {
            (_items[index], _items[parentIndex]) = (_items[parentIndex], _items[index]);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    /// <summary>
    /// 下沉操作
    /// </summary>
    /// <param name="index"></param>
    private void Heapify(int index)
    {
        // 左孩子节点下标
        int left = index * 2 + 1;
        while (left < _size)
        {
            int min = left;
            // 左右孩子比较
            if (left + 1 < _size && _items[left + 1].CompareTo(_items[left]) < 0)
            {
                min = left + 1;
            }
            // 与父节点比较
            if (_items[index].CompareTo(_items[min]) < 0)
            {
                break;
            }
            // 父节点与子节点交换
            (_items[index], _items[min]) = (_items[min], _items[index]);
            // 继续向下寻找
            index = min;
            left = index * 2 + 1;
        }
    }
}