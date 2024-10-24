using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_078
{
    public static void Test()
    {
        LeetCode_078 obj = new LeetCode_078();
        Tools.PrintLinkedList(obj.MergeKLists(new []
        {
            Tools.ConstructLinkedList(new []{1,4,5}),
            Tools.ConstructLinkedList(new []{1,3,4}),
            Tools.ConstructLinkedList(new []{2,6}),
        }));
        Tools.PrintLinkedList(obj.MergeKLists(Array.Empty<ListNode>()));
        Tools.PrintLinkedList(obj.MergeKLists(new []{Tools.ConstructLinkedList(Array.Empty<int>())}));
    }
    
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0) return null;
        return _mergeList(lists, 0, lists.Length-1);
    }

    private ListNode _mergeList(ListNode[] lists, int left, int right)
    {
        if (left == right) return lists[left];
        if (left > right) return null;
        int mid = (left + right) / 2;
        var list1 = _mergeList(lists, left, mid);
        var list2 = _mergeList(lists, mid+1, right);
        return _merge(list1, list2);
    }

    private ListNode _merge(ListNode list1, ListNode list2)
    {
        ListNode vHead = new ListNode();
        ListNode cur = vHead;
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                cur.next = list1;
                list1 = list1.next;
            }
            else
            {
                cur.next = list2;
                list2 = list2.next;
            }
            cur = cur.next;
        }

        if (list1 != null)
            cur.next = list1;
        if (list2 != null)
            cur.next = list2;
        return vHead.next;
    }
}