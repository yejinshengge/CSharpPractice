using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.旋转链表;

/**
 * 给你一个链表的头节点 head ，旋转链表，将链表每个节点向右移动 k 个位置。
 */
public class LeetCode_0061
{
    public static void Test()
    {
        LeetCode_0061 obj = new LeetCode_0061();
        var list1 = Tools.ConstructLinkedList(new[] { 1, 2, 3, 4, 5 });
        Tools.PrintLinkedList(obj.RotateRight(list1,2));
        
        var list2 = Tools.ConstructLinkedList(new[] { 0,1,2 });
        Tools.PrintLinkedList(obj.RotateRight(list2,4));
    }
    
    public ListNode RotateRight1(ListNode head, int k)
    {
        if (head == null||head.next == null) return head;
        ListNode fastNode = head;
        ListNode slowNode = head;

        for (int i = 0; i < k; i++)
        {
            fastNode = fastNode.next;
            if (fastNode == null)
                fastNode = head;
        }

        while (fastNode.next != null)
        {
            fastNode = fastNode.next;
            slowNode = slowNode.next;
        }

        fastNode.next = head;
        head = slowNode.next;
        slowNode.next = null;
        return head;
    }
    
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null||head.next == null) return head;
        ListNode tail = head;
        int len = 1;
        while (tail.next != null)
        {
            tail = tail.next;
            len++;
        }

        int index = len - k % len;
        if (index == 0) return head;
        tail.next = head;
        for (int i = 0; i < index-1; i++)
        {
            head = head.next;
        }

        ListNode newHead = head.next;
        head.next = null;
        return newHead;
    }
}