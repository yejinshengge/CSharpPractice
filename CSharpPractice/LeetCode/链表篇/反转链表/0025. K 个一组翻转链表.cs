using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.反转链表;

/**
给你链表的头节点 head ，每 k 个节点一组进行翻转，请你返回修改后的链表。

k 是一个正整数，它的值小于或等于链表的长度。如果节点总数不是 k 的整数倍，那么请将最后剩余的节点保持原有顺序。

你不能只是单纯的改变节点内部的值，而是需要实际进行节点交换。
 */
public class LeetCode_0025
{
    public static void Test()
    {
        LeetCode_0025 obj = new LeetCode_0025();
        var list = Tools.ConstructLinkedList(new[] { 1, 2, 3, 4, 5 });
        var res = obj.ReverseKGroup(list, 3);
        Tools.PrintLinkedList(res);
    }
    
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode vNode = new ListNode();
        Stack<ListNode> stack = new Stack<ListNode>();
        vNode.next = head;
        ListNode cur = vNode;
        ListNode next = head;
        
        while (next != null)
        {
            stack.Push(next);
            next = next.next;

            if (stack.Count == k)
            {
                cur.next = stack.Peek();
                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    if (stack.Count != 0)
                        node.next = stack.Peek();
                    else
                    {
                        node.next = next;
                        cur = node;
                    }
                }
            }
        }

        return vNode.next;
    }
}