using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.删除链表的倒数第N个节点;

// 给你一个链表，删除链表的倒数第 n 个结点，并且返回链表的头结点。
public class LeetCode_0019
{
    public static void Test()
    {
        LeetCode_0019 obj = new LeetCode_0019();
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);
        var node = obj.RemoveNthFromEnd(head, 2);
        
    }
    
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (head == null) return null;
        ListNode newHead = new ListNode(-1);
        newHead.next = head;
        ListNode left = newHead;
        ListNode right = newHead;
    
        while (n-->0 && right != null)
        {
            right = right.next;
        }

        if (right == null) return null;
        while (right.next != null)
        {
            left = left.next;
            right = right.next;
        }

        left.next = left.next.next;
        return newHead.next;
    }
}