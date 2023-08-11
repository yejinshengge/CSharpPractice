using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 给你单链表的头节点 head ，请你反转链表，并返回反转后的链表。
public class LeetCode_023
{
    public static void Test()
    {
        LeetCode_023 obj = new LeetCode_023();
        ListNode head = new ListNode(0);
        head.next = new ListNode(1);
        head.next.next = new ListNode(2);
        head.next.next.next = new ListNode(3);
        head.next.next.next.next = new ListNode(4);

        var node = obj.ReverseList2(head);
        Console.WriteLine(node);
    }

    // 思路一:递归
    private ListNode _head;

    public ListNode ReverseList(ListNode head)
    {
        if (head == null) return head;
        Process(head);
        return _head;
    }
    public ListNode Process(ListNode head)
    {
        if (head.next == null)
        {
            _head = head;
            return head;
        }

        var node = Process(head.next);
        node.next = head;
        head.next = null;
        return head;
    }

    // 优化,尾递归
    public ListNode ReverseList2(ListNode head)
    {
        return Process2(head,null);
    }

    public ListNode Process2(ListNode head,ListNode newHead)
    {
        if (head == null) return newHead;

        var node = head.next;
        head.next = newHead;
        return Process2(node, head);
    }
}