using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.反转链表;

/**
 * 给你单链表的头节点 head ，请你反转链表，并返回反转后的链表。
 */
public class LeetCode_0206
{
    public static void Test()
    {
        LeetCode_0206 obj = new LeetCode_0206();
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);

        var node1 = obj.ReverseList(head);
        var node2= obj.ReverseList(null);
        var node3= obj.ReverseList(new ListNode(1));
        
    }

    public ListNode ReverseList(ListNode head)
    {
        ListNode left = null;
        ListNode right = head;

        while (right != null)
        {
            ListNode cur = right.next;
            right.next = left;
            left = right;
            right = cur;
        }

        return left;
    }
    
}