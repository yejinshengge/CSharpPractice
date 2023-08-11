using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.两两交换链表中的节点;

//给你一个链表，两两交换其中相邻的节点，并返回交换后链表的头节点。
//你必须在不修改节点内部的值的情况下完成本题（即，只能进行节点交换）。
public class LeetCode_0024
{
    public static void Test()
    {
        LeetCode_0024 obj = new LeetCode_0024();
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);
        var node = obj.SwapPairs(head);
        
    }

    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode left = head;
        ListNode right = head.next;
        head = right;

        ListNode pre = null;
        while (left != null && right != null)
        {
            ListNode next = right.next;
            left.next = next;
            right.next = left;
            if (pre != null)
                pre.next = right;
            pre = left;

            left = next;
            right = next == null ? null : next.next;
        }

        return head;
    }
    
}