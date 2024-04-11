using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个链表，删除链表的倒数第 n 个结点，并且返回链表的头结点。
 */
public class LeetCode_0019
{
    public static void Test()
    {
        LeetCode_0019 obj = new LeetCode_0019();
        obj.RemoveNthFromEnd(Tools.ConstructLinkedList(new []{1}), 1);
    }
    
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode vHead = new ListNode();
        vHead.next = head;
        ListNode left = vHead, right = vHead;
        for (int i = 0; i < n; i++)
        {
            right = right.next;
        }

        while (right.next != null)
        {
            left = left.next;
            right = right.next;
        }

        left.next = left.next.next;
        return vHead.next;
    }
}