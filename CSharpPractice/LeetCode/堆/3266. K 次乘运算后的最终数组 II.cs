using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.堆;

public class LeetCode_3266
{
    public static void Test()
    {
        LeetCode_3266 obj = new LeetCode_3266();
        Tools.PrintArr(obj.GetFinalState(new []{2,1,3,5,6},5,2));
        Tools.PrintArr(obj.GetFinalState(new []{100000,2000},2,1000000));
        Tools.PrintArr(obj.GetFinalState(new []{10000},1000000000,1000000));
        Tools.PrintArr(obj.GetFinalState(new []{4,2,4},3,2));
    }

    private const int MOD = 1000000007;
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        if (multiplier == 1) return nums;
        var len = nums.Length;
        Heap heap = new Heap(len);
        int max = 0;
        for (int i = 0; i < len; i++)
        {
            max = Math.Max(nums[i],max);
            heap.HeapInsert(i,nums[i]);
        }

        for (;heap.Peek().Item2 < max && k > 0;k--)
        {
            var top = heap.Pop();
            top.Item2 *= multiplier;
            heap.HeapInsert(top.Item1,top.Item2);
        }
        
        int[] res = new int[len];
        for (int i = 0; i < len; i++)
        {
            var top = heap.Pop();
            var pow = k / len + (i >= k % len ? 0 : 1);
            res[top.Item1] = (int)(_pow(multiplier, pow) * (top.Item2 % MOD)%MOD);
        }

        return res;
    }

    private int _pow(long x, long y)
    {
        long res = 1;
        while (y > 0)
        {
            if ((y & 1) == 1)
                res = res * x % MOD;
            x = x * x % MOD;
            y >>= 1;
        }

        return (int)res % MOD;
    }

    public class Heap
    {
        private (int,long)[] _nums;
        private int _count = 0;
        
        public Heap(int length)
        {
            _nums = new (int, long)[length];
        }

        public void HeapInsert(int index,long num)
        {
            int cur = _count;
            _nums[cur] = (index, num);
            int parent = (cur - 1) / 2;
            while (_compare(_nums[cur],_nums[parent]))
            {
                (_nums[cur], _nums[parent]) = (_nums[parent], _nums[cur]);
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
                int smallest = left + 1 < _count && _compare(_nums[left+1],_nums[left])
                    ? left+1 : left;
                if(_compare(_nums[cur],_nums[smallest]))
                    return;
                (_nums[smallest], _nums[cur]) = (_nums[cur], _nums[smallest]);
                cur = smallest;
                left = cur * 2 + 1;
            }
        }

        private bool _compare((int, long) a, (int, long) b)
        {
            if (a.Item2 == b.Item2) return a.Item1 < b.Item1;
            return a.Item2 < b.Item2;
        }

        public (int, long) Pop()
        {
            var top = _nums[0];
            _nums[0] = _nums[_count - 1];
            _count--;
            _heapify();
            return top;
        }

        public (int, long) Peek()
        {
            return _nums[0];
        }
    }
}