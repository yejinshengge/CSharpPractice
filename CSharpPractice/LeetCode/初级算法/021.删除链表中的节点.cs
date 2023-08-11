using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 有一个单链表的head，我们想删除它其中的一个节点node。
//
// 给你一个需要删除的节点node。你将无法访问第一个节点head。
//
// 链表的所有值都是 唯一的，并且保证给定的节点node不是链表中的最后一个节点。
public class LeetCode_021
{
    public static void Test()
    {
        LeetCode_021 obj = new LeetCode_021();
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        
        obj.DeleteNode(head.next);
        Console.WriteLine();
    }

    // 思路一:只改变值,并将最后一个节点断开
    public void DeleteNode(ListNode node)
    {
        ListNode pre = null;
        while (node.next != null)
        {
            node.val = node.next.val;
            pre = node;
            node = node.next;
        }

        pre.next = null;
    }

    // 思路二:化身为下一个节点,并干掉下一个节点
    public void DeleteNode2(ListNode node)
    {
        node.val = node.next.val;
        node.next = node.next.next;
    }
    

    

}