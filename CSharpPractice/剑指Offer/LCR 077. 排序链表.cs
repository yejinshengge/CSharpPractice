using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR077
{
    public static void Test()
    {
        LeetCode_LCR077 obj = new LeetCode_LCR077();
        Tools.PrintLinkedList(obj.SortList(Tools.ConstructLinkedList(new []{4,2,1,3})));
        Tools.PrintLinkedList(obj.SortList(Tools.ConstructLinkedList(new []{-1,5,3,4,0})));
        Tools.PrintLinkedList(obj.SortList(Tools.ConstructLinkedList(Array.Empty<int>())));
    }
    
    public ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null) return head;
        var list1 = head;
        var list2 = _split(head);
        list1 = SortList(list1);
        list2 = SortList(list2);
        return _merge(list1, list2);
    }

    private ListNode _split(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        ListNode slow = head, fast = head.next;
        while (fast is { next: not null })
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        var next = slow.next;
        slow.next = null;
        return next;
    }

    private ListNode _merge(ListNode list1, ListNode list2)
    {
        ListNode vHead = new ListNode();
        ListNode cur = vHead;
        while (list1 != null && list2 != null)
        {
            if (list1.val > list2.val)
            {
                cur.next = list2;
                list2 = list2.next;
            }
            else
            {
                cur.next = list1;
                list1 = list1.next;
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