namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR059
{
    public static void Test()
    {
        LeetCode_LCR059 obj = new LeetCode_LCR059();
        KthLargest kthLargest = new KthLargest(3, new[] { 4, 5, 8, 2 });
        Console.WriteLine(kthLargest.Add(3));
        Console.WriteLine(kthLargest.Add(5));
        Console.WriteLine(kthLargest.Add(10));
        Console.WriteLine(kthLargest.Add(9));
        Console.WriteLine(kthLargest.Add(4));
        kthLargest = new KthLargest(2, new[] { 0 });
        Console.WriteLine(kthLargest.Add(-1));
        Console.WriteLine(kthLargest.Add(1));
        Console.WriteLine(kthLargest.Add(-2));
        Console.WriteLine(kthLargest.Add(-4));
        Console.WriteLine(kthLargest.Add(-3));
    }
    
    public class KthLargest
    {
        private Heap _heap;
        public KthLargest(int k, int[] nums)
        {
            _heap = new Heap(k);
            foreach (var num in nums)
            {
                _heap.Add(num);
            }
        }
    
        public int Add(int val) {
            _heap.Add(val);
            return _heap.Peek();
        }

        class Heap
        {
            private int[] _arr;
            private int _curSize;
            
            public Heap(int size)
            {
                _arr = new int[size];
                _curSize = 0;
            }

            public void Add(int num)
            {
                if (_curSize < _arr.Length)
                {
                    _heapInsert(num);
                }
                else if (Peek() < num)
                {
                    _arr[0] = num;
                    _heapify();
                }
            }

            public int Peek()
            {
                return _arr[0];
            }

            private void _heapInsert(int num)
            {
                int index = _curSize++;
                _arr[index] = num;
                var parent = (index - 1) / 2;
                while (_arr[index] < _arr[parent])
                {
                    (_arr[parent], _arr[index]) = (_arr[index], _arr[parent]);
                    index = parent;
                    parent = (index - 1) / 2;
                }
            }

            private void _heapify()
            {
                int index = 0;
                int left = 1;
                while (left < _arr.Length)
                {
                    int smaller = left + 1 < _arr.Length && _arr[left] > _arr[left + 1] 
                        ? left + 1: left;
                    smaller = _arr[index] < _arr[smaller] ? index : smaller;
                    if(smaller == index) return;
                    (_arr[index], _arr[smaller]) = (_arr[smaller], _arr[index]);
                    index = smaller;
                    left = index * 2 + 1;
                }
            }
        }
    }
}