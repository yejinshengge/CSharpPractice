namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR031
{
    public static void Test()
    {
        LeetCode_LCR031 obj = new LeetCode_LCR031();
        LRUCache cache = new LRUCache(2);
        cache.Put(1,1);
        cache.Put(2,2);
        cache.Get(1);
        cache.Put(3,3);
        cache.Get(2);
        cache.Put(4,4);
        cache.Get(1);
        cache.Get(3);
        cache.Get(4);
    }
}

public class LRUCache
{
    private int _capacity;
    private Dictionary<int, ListNode> _dic;
    private ListNode _head = new ListNode(0,0);
    private ListNode _tail = new ListNode(0, 0);
    
    public LRUCache(int capacity)
    {
        _dic = new Dictionary<int, ListNode>();
        _capacity = capacity;
        _head.next = _tail;
        _tail.prev = _head;
    }
    
    public int Get(int key)
    {
        if (!_dic.ContainsKey(key))
            return -1;
        var cur = _dic[key];
        var prev = cur.prev;
        var next = cur.next;

        prev.next = next;
        next.prev = prev;

        cur.next = _tail;
        cur.prev = _tail.prev;
        _tail.prev = cur;
        cur.prev.next = cur;
        
        return cur.val;
    }
    
    public void Put(int key, int value)
    {
        if (!_dic.ContainsKey(key))
        {
            if (_dic.Count == _capacity)
            {
                var oldNode = _head.next;
                _dic.Remove(oldNode.key);
                _head.next = oldNode.next;
                _head.next.prev = _head;
            }
            _dic[key] = new ListNode(key, value);
            var prev = _tail.prev;
            prev.next = _dic[key];
            _dic[key].prev = prev;

            _dic[key].next = _tail;
            _tail.prev = _dic[key];
        }
        else
        {
            _dic[key].val = value;
            var cur = _dic[key];
            var prev = cur.prev;
            var next = cur.next;

            prev.next = next;
            next.prev = prev;

            cur.next = _tail;
            cur.prev = _tail.prev;
            _tail.prev = cur;
            cur.prev.next = cur;
        }
    }

    private class ListNode
    {
        public int val;
        public int key;
        public ListNode next;
        public ListNode prev;

        public ListNode( int key,int val)
        {
            this.val = val;
            this.key = key;
        }
    }
}