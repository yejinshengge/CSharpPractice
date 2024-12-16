namespace CSharpPractice.LeetCode.堆;

public class LeetCode_1338
{
    public static void Test()
    {
        LeetCode_1338 obj = new LeetCode_1338();
        Console.WriteLine(obj.MinSetSize(new []{3,3,3,3,5,5,5,2,2,7}));
        Console.WriteLine(obj.MinSetSize(new []{7,7,7,7,7,7}));
        Console.WriteLine(obj.MinSetSize(new []{7}));
        Console.WriteLine(obj.MinSetSize(new []{1,2,3,4,5,6,7,8}));
    }
    
    public int MinSetSize(int[] arr)
    {
        Dictionary<int, int> dic = new();
        for (var i = 0; i < arr.Length; i++)
        {
            dic.TryAdd(arr[i], 0);
            dic[arr[i]]++;
        }

        Heap heap = new(arr.Length);
        foreach (var (key, value) in dic)
        {
            heap.HeapInsert(key,value);
        }

        int sum = 0;
        int cnt = 0;
        while (sum < arr.Length/2)
        {
            var item = heap.Pop();
            sum += item.num;
            cnt++;
        }

        return cnt;
    }

    public class Heap
    {
        public struct Item
        {
            public int val;
            public int num;
        }

        private Item[] _items;
        private int _count;
        
        public Heap(int len)
        {
            _items = new Item[len];
        }

        public void HeapInsert(int value, int count)
        {
            int cur = _count;
            _items[cur] = new Item() { val = value, num = count };
            int parent = (cur - 1) / 2;

            while (_items[cur].num > _items[parent].num )
            {
                (_items[cur], _items[parent]) = (_items[parent], _items[cur]);
                cur = parent;
                parent = (cur - 1) / 2;
            }

            _count++;
        }

        private void _heapify()
        {
            int cur = 0;
            int left = cur * 2 + 1;
            while (left < _count)
            {
                int biggest = left + 1 < _count && _items[left + 1].num > _items[left].num ? left + 1 : left;
                if(_items[biggest].num < _items[cur].num)
                    return;
                (_items[biggest], _items[cur]) = (_items[cur], _items[biggest]);
                cur = biggest;
                left = cur * 2 + 1;
            }
        }

        public Item Pop()
        {
            var item = _items[0];
            _count--;
            _items[0] = _items[_count];
            _heapify();
            return item;
        }
    }
}