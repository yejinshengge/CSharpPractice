using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR061
{
    public static void Test()
    {
        LeetCode_LCR061 obj = new LeetCode_LCR061();
        // Tools.PrintEnumerator(obj.KSmallestPairs(new []{1,7,11},new []{2,4,6},3));
        // Tools.PrintEnumerator(obj.KSmallestPairs(new []{1,1,2},new []{1,2,3},2));
        // Tools.PrintEnumerator(obj.KSmallestPairs(new []{1,2},new []{3},3));
        Tools.PrintEnumerator(obj.KSmallestPairs(new []{1,1,2},new []{1,2,3},10));
    }
    
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        Heap<List<int>> heap = new Heap<List<int>>(k, 
            (e1, e2) => nums1[e1[0]] + nums2[e1[1]] - nums1[e2[0]] - nums2[e2[1]]);
        // 先把[0,x]加入堆
        for (int i = 0; i < Math.Min(k,nums2.Length); i++)
        {
            heap.Push(new List<int>(){0,i});
        }

        IList<IList<int>> res = new List<IList<int>>();
        while (heap.CurSize > 0 && res.Count < k)
        {
            // 弹出堆顶元素
            var val = heap.Pop();
            // 添加到结果
            res.Add(new List<int>(){nums1[val[0]],nums2[val[1]]});
            // 固定nums2,移动nums1指针
            // 因为nums1不变,nums2往前的元素已经考虑过
            // nums1往后移动一位,nums2不变,已经比当前元素大
            // 所以只需要考虑nums1往后移动一位的情况
            if(val[0] + 1 < nums1.Length)
                heap.Push(new List<int>(){val[0]+1,val[1]});
        }
        return res;
    }
    
    private class Heap<T>
    {
        public int CurSize => _curSize;
        private T[] _arr;
        private int _curSize;
        private Func<T,T,int> _comparer;

        public Heap(int size,Func<T,T,int> comparer)
        {
            _arr = new T[size+1];
            _curSize = 0;
            _comparer = comparer;
        }

        public void Push(T val)
        {
            _arr[_curSize] = val;
            _heapInsert();
            if (_curSize < _arr.Length-1) 
                _curSize++;
        }

        public T Pop()
        {
            T val = _arr[0];
            (_arr[0], _arr[_curSize - 1]) = (_arr[_curSize - 1], _arr[0]);
            _curSize--;
            _heapify();
            return val;
        }

        private void _heapInsert()
        {
            int index = _curSize;
            int parent = (index - 1) / 2;
            while (_comparer(_arr[index],_arr[parent]) < 0)
            {
                (_arr[index], _arr[parent]) = (_arr[parent], _arr[index]);
                index = parent;
                parent = (index - 1) / 2;
            }
        }

        private void _heapify()
        {
            int index = 0;
            int left = 1;
            while (left < _curSize)
            {
                int smaller = left + 1 < _curSize 
                              && _comparer(_arr[left + 1], _arr[left]) < 0 
                    ? left + 1 : left;
                smaller = _comparer(_arr[index], _arr[smaller]) < 0 ? index : smaller;
                if(smaller == index)
                    return;
                (_arr[smaller], _arr[index]) = (_arr[index], _arr[smaller]);
                index = smaller;
                left = 2 * index + 1;
            }
        }
    }
}