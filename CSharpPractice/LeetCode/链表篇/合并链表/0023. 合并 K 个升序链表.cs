using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.合并链表;

/**
给你一个链表数组，每个链表都已经按升序排列。

请你将所有链表合并到一个升序链表中，返回合并后的链表。
 */
public class LeetCode_0023
{
    public static void Test()
    {
        LeetCode_0023 obj = new LeetCode_0023();
        var node1 = Tools.ConstructLinkedList(new[] { 1, 4, 5 });
        var node2 = Tools.ConstructLinkedList(new[] { 1,3,4 });
        var node3 = Tools.ConstructLinkedList(new[] { 2,6 });
        
        Tools.PrintLinkedList(obj.MergeKLists(new ListNode[]{null}));
    }
    
    public ListNode MergeKLists(ListNode[] lists)
    {
        ListNode head = new ListNode(int.MaxValue);
        ListNode cur = head;
        ListNode min = head;
        while (true)
        {
            int index = -1;
            for (int i = 0; i < lists.Length; i++)
            {
                if(lists[i] == null) continue;
                if ( min == null || lists[i].val <= min.val)
                {
                    min = lists[i];
                    index = i;
                }
            }
            if(index == -1) break;
            cur.next = min;
            cur = cur.next;
            lists[index] = lists[index].next;
            min = lists[index];
        }

        return head.next;
    }
}