using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇;
// 给你一个链表的头节点 head 和一个整数 val ，请你删除链表中所有满足 Node.val == val 的节点，并返回 新的头节点 。
public class LeetCode_0203
{
    public static void Test()
    {
        LeetCode_0203 obj = new LeetCode_0203();
        ListNode head = new ListNode(7);
        head.next = new ListNode(7);
        head.next.next = new ListNode(7);
        head.next.next.next = new ListNode(7);
        head.next.next.next.next = new ListNode(7);
        head.next.next.next.next.next = new ListNode(7);

        var node = obj.RemoveElements(head,7);
        Console.WriteLine(node);
    }
    
    public ListNode RemoveElements(ListNode head, int val)
    {
        if (head == null) return null;
        ListNode newHead = new ListNode();
        newHead.next = head;
        ListNode pre = newHead;
        ListNode cur = head;
        
        while (cur != null)
        {
            if (cur.val == val)
                pre.next = cur.next;
            else
                pre = cur;
            cur = cur.next;
        }

        return newHead.next;

    }
    
 
}