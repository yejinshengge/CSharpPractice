using System.Collections;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.合并链表;

/**
给你一个链表数组，每个链表都已经按升序排列。

请你将所有链表合并到一个升序链表中，返回合并后的链表。
 */
public class LeetCode_0023
{
    public static void Test()
    {
        LeetCode_0023 obj = new LeetCode_0023();
        var node1 = Tools.ConstructLinkedList(new[] { 1, 4, 5 });
        var node2 = Tools.ConstructLinkedList(new[] { 1,3,4 });
        var node3 = Tools.ConstructLinkedList(new[] { 2,6 });
        
        Tools.PrintLinkedList(obj.MergeKLists3(new ListNode[]{node1,node2,node3}));
    }

    #region 顺序合并
    public ListNode MergeKLists1(ListNode[] lists)
    {
        ListNode head = new ListNode(int.MaxValue);
        ListNode cur = head;
        ListNode min = head;
        while (true)
        {
            int index = -1;
            for (int i = 0; i < lists.Length; i++)
            {
                if(lists[i] == null) continue;
                if ( min == null || lists[i].val <= min.val)
                {
                    min = lists[i];
                    index = i;
                }
            }
            if(index == -1) break;
            cur.next = min;
            cur = cur.next;
            lists[index] = lists[index].next;
            min = lists[index];
        }

        return head.next;
    }
    
    #endregion

    #region 分治解法

    private ListNode _doMerge(ListNode head1,ListNode head2)
    {
        if (head1 == null) return head2;
        if (head2 == null) return head1;

        ListNode head = new ListNode(0);
        ListNode cur = head;
        while (head1 != null && head2 != null)
        {
            if (head1.val < head2.val)
            {
                cur.next = head1;
                head1 = head1.next;
            }
            else
            {
                cur.next = head2;
                head2 = head2.next;
            }
            cur = cur.next;
        }

        cur.next = head1 != null ? head1 : head2;
        return head.next;
    }

    private ListNode _merge(ListNode[] lists, int left, int right)
    {
        if (right < left) return null;
        if (left == right) return lists[left];
        int mid = (left + right) / 2;
        return _doMerge(_merge(lists, left, mid), _merge(lists, mid + 1, right));
    }
    
    public ListNode MergeKLists2(ListNode[] lists)
    {
        return _merge(lists, 0, lists.Length - 1);
    }
    
    #endregion

    #region 优先级队列

    public ListNode MergeKLists3(ListNode[] lists)
    {
        PriorityQueue<ListNode, int> queue = new PriorityQueue<ListNode, int>();
        for (int i = 0; i < lists.Length; i++)
        {
            if(lists[i] == null) continue;
            queue.Enqueue(lists[i],lists[i].val);
        }

        ListNode head = new ListNode(0);
        ListNode cur = head;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            cur.next = node;
            cur = cur.next;
            if(node.next != null)
                queue.Enqueue(node.next,node.next.val);
        }

        return head.next;
    }

    private class PriorityQueue<T1, T2> where T2 : struct,IComparable<T2>
    {
        public int Count => _nodes.Count;
        
        private readonly List<T1> _nodes = new();
        private readonly List<T2> _priority = new();

        public void Enqueue(T1 node, T2 priority)
        {
            _nodes.Add(node);
            _priority.Add(priority);
            _heapInsert(_priority.Count - 1);
        }

        public T1 Dequeue()
        {
            return Dequeue(out _);
        }
        
        public T1 Dequeue(out T2 priority)
        {
            var node = _nodes[0];
            priority = _priority[0];

            (_nodes[0], _nodes[^1]) = (_nodes[^1], _nodes[0]);
            (_priority[0], _priority[^1]) = (_priority[^1], _priority[0]);
            _nodes.RemoveAt(_nodes.Count-1);
            _priority.RemoveAt(_priority.Count-1);

            _heapify(0);
            return node;
        }

        // 上浮
        private void _heapInsert(int index)
        {
            int parent = (index-1) / 2;
            while (_priority[index].CompareTo( _priority[parent]) < 0)
            {
                (_priority[index], _priority[parent]) = (_priority[parent], _priority[index]);
                (_nodes[index], _nodes[parent]) = (_nodes[parent], _nodes[index]);
                index = parent;
                parent = (index-1) / 2;
            }
        }

        // 下沉
        private void _heapify(int index)
        {
            int left = index * 2 + 1;
            while (left < _priority.Count)
            {
                var right = left + 1;
                int smallerChild = right <_priority.Count && 
                                   _priority[left].CompareTo(_priority[right]) > 0 ? right : left;
                
                if(_priority[index].CompareTo(_priority[smallerChild]) < 0)
                    break;
                (_priority[smallerChild], _priority[index]) = (_priority[index], _priority[smallerChild]);
                (_nodes[smallerChild], _nodes[index]) = (_nodes[index], _nodes[smallerChild]);

                index = smallerChild;
                left = smallerChild * 2 + 1;
            }
        }
    }

    #endregion
}