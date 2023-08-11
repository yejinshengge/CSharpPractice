using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 给你一个链表，删除链表的倒数第 n 个结点，并且返回链表的头结点。
public class LeetCode_022
{
    public static void Test()
    {
        LeetCode_022 obj = new LeetCode_022();
        ListNode head = new ListNode(0);
        head.next = new ListNode(1);
        head.next.next = new ListNode(2);
        head.next.next.next = new ListNode(3);
        head.next.next.next.next = new ListNode(4);
        obj.RemoveNthFromEnd(head, 2);
        Console.WriteLine(head);
    }

    // 思路一:快慢指针
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (head.next == null) return null;
        int index = 0;
        ListNode left = head,right = head;

        while (right.next != null)
        {
            if (index >= n)
            {
                left = left.next;
            }
            index++;
            right = right.next;
        }
        // index<n说明删除的是头结点
        if (index < n)
            return head.next;
        left.next = left.next.next;
        return head;
    }
    
    // 优化
    public ListNode RemoveNthFromEnd2(ListNode head, int n)
    {
        ListNode left = head,right = head;

        for (int i = 0; i < n; i++)
        {
            right = right.next;
        }
        
        // 如果right为空,说明删除的是头结点
        if (right == null)
            return head.next;
        while (right.next != null)
        {
            left = left.next;
            right = right.next;
        }

        left.next = left.next.next;
        return head;
    }
}