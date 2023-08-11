using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer024ReverseList
{
    public static void Offer024ReverseListMain()
    {
        Offer024ReverseList obj = new();
        ListNode head = new(1);
        head.next = new (2);
        head.next.next = new (3);
        // head.next.next.next = new (4);
        var node = obj.ReverseList2(head);
        Console.WriteLine(node);
    }
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        ListNode cur = head;
        ListNode lastNode = null;
        while (cur != null)
        {
            ListNode nextNode = cur.next;
            cur.next = lastNode;
            lastNode = cur;
            cur = nextNode;
        }
        return lastNode;
    }

    public ListNode ReverseList2(ListNode head)
    {
        return Reverse(head, null);
    }

    public ListNode Reverse(ListNode cur, ListNode pre)
    {
        if (cur == null) return pre;
        // 反转后的头结点
        var node = Reverse(cur.next, cur);
        cur.next = pre;
        return node;
    }
}