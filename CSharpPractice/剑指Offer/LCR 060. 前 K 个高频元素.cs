using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR060
{
    public static void Test()
    {
        LeetCode_LCR060 obj = new LeetCode_LCR060();
        // Tools.PrintArr(obj.TopKFrequent(new []{1,1,1,2,2,3},2));
        // Tools.PrintArr(obj.TopKFrequent(new []{1,1,1,2,2,2,3},2));
        // Tools.PrintArr(obj.TopKFrequent(new []{1},1));
        Tools.PrintArr(obj.TopKFrequent(new []{6,0,1,4,9,7,-3,1,-4,-8,4,-7,-3,3,2,-3,9,5,-4,0},6));
    }
    
    public int[] TopKFrequent(int[] nums, int k)
    {
        Heap heap = new Heap(nums.Length);
        foreach (var num in nums)
        {
            heap.Add(num);
        }

        int[] res = new int[k];
        for (int i = k-1; i >=0; i--)
        {
            res[i] = heap.Pop();
        }

        return res;
    }
    
    private class Heap
    {
        // 记录元素本身
        private int[] _arr;
        private int _curSize;
        // 记录每个元素的出现次数
        private Dictionary<int, int> _valNumDic;// key = val value = num
        // 记录每个元素在堆中的位置
        private Dictionary<int, int> _valIndexDic;// key = val value = index
        
        public Heap(int size)
        {
            _arr = new int[size];
            _valNumDic = new Dictionary<int, int>();
            _valIndexDic = new Dictionary<int, int>();
            _curSize = 0;
        }

        public void Add(int val)
        {
            int index = -1;
            // 如果元素已经存在，则更新出现次数
            if (_valIndexDic.ContainsKey(val))
            {
                index = _valIndexDic[val];
                _valNumDic[val]++;
            }
            else
            {
                // 如果元素不存在，则添加元素
                index = _curSize++;
                _valIndexDic.Add(val,index);
                _valNumDic.Add(val,1);
            }
            _arr[index] = val;
            _heapInsert(index);
            
        }

        public int Pop()
        {
            int val = _arr[0];
            var tail = _curSize - 1;
            (_arr[0], _arr[tail]) = (_arr[tail], _arr[0]);
            _valIndexDic.Remove(val);
            _valNumDic.Remove(val);
            _valIndexDic[_arr[0]] = 0;
            _curSize--;
            _heapify();
            return val;
        }

        private void _heapInsert(int index)
        {
            int parent = (index - 1) / 2;
            // 如果当前元素的出现次数大于父元素的出现次数，则交换位置
            while (_valNumDic[_arr[index]] > _valNumDic[_arr[parent]])
            {
                (_arr[index], _arr[parent]) = (_arr[parent], _arr[index]);
                // 更新元素在堆中的位置
                _valIndexDic[_arr[index]] = index;
                _valIndexDic[_arr[parent]] = parent;
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
                
                // 如果当前元素的出现次数大于子节点的出现次数，则交换位置
                int bigger = left + 1 < _curSize 
                             && _valNumDic[_arr[left + 1]] > _valNumDic[_arr[left]] 
                    ? left + 1 : left;
                bigger = _valNumDic[_arr[index]] > _valNumDic[_arr[bigger]] ? index : bigger;
                if(index == bigger)
                    return;
                (_arr[index], _arr[bigger]) = (_arr[bigger], _arr[index]);
                // 更新元素在堆中的位置
                _valIndexDic[_arr[index]] = index;
                _valIndexDic[_arr[bigger]] = bigger;
                index = bigger;
                left = 2 * index + 1;
            }
        }
    }
}