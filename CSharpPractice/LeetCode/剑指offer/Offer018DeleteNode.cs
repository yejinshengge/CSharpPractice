using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer018DeleteNode
{
    
    public ListNode DeleteNode(ListNode head, int val)
    {
        if (head == null)
            return head;
        if (head.val == val)
            return head.next;
        ListNode cur = head;
        ListNode pre = head;
        while (cur != null)
        {
            if(cur.val == val)
                break;
            pre = cur;
            cur = cur.next;
        }

        pre.next = cur.next;
        cur.next = null;
        return head;
    }

    public static void Offer018DeleteNodeMain()
    {
        Offer018DeleteNode obj = new();
        ListNode head = new ListNode(4);
        head.next = new ListNode(5);
        head.next.next = new ListNode(1);
        head.next.next.next = new ListNode(9);
        ListNode head2 = obj.DeleteNode(head, 5);
        Console.WriteLine(head2);
    }
}