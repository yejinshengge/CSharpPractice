using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针.链表;

/**
 * 给你一个链表的头节点 head 和一个特定值 x ，请你对链表进行分隔，使得所有 小于 x 的节点都出现在 大于或等于 x 的节点之前。
    
    你应当 保留 两个分区中每个节点的初始相对位置。
 */
public class LeetCode_0086
{
    public static void Test()
    {
        LeetCode_0086 obj = new LeetCode_0086();
        Tools.PrintLinkedList(obj.Partition2(Tools.ConstructLinkedList(new []{1,4,3,2,5,2}),3));
        Tools.PrintLinkedList(obj.Partition2(Tools.ConstructLinkedList(new []{2,1}),2));
        Tools.PrintLinkedList(obj.Partition2(Tools.ConstructLinkedList(new []{1,2}),2));
        Tools.PrintLinkedList(obj.Partition2(Tools.ConstructLinkedList(new []{2,3,4}),1));
        Tools.PrintLinkedList(obj.Partition2(Tools.ConstructLinkedList(new []{2,3,4}),5));
        Tools.PrintLinkedList(obj.Partition2(Tools.ConstructLinkedList(Array.Empty<int>()),5));
    }
    
    public ListNode Partition(ListNode head, int x)
    {
        ListNode smallTail = null;
        ListNode bigTail = null;
        ListNode smallHead = null;
        ListNode bigHead = null;
        ListNode cur = head;

        while (cur != null)
        {
            if (cur.val < x)
            {
                if (smallTail == null)
                {
                    smallHead = cur;
                    smallTail = cur;
                }
                else
                {
                    smallTail.next = cur;
                    smallTail = smallTail.next;
                }
                cur = cur.next;
            }
            else
            {
                if (bigTail == null)
                {
                    bigHead = cur;
                    bigTail = cur;
                }
                else
                {
                    bigTail.next = cur;
                    bigTail = bigTail.next;
                }
                cur = cur.next;
            }
        }

        if (smallTail != null)
            smallTail.next = bigHead;
        if (bigTail != null)
            bigTail.next = null;
        return smallHead != null?smallHead:bigHead;
    }
    
    public ListNode Partition2(ListNode head, int x)
    {
        ListNode smallHead = new ListNode(0);
        ListNode bigHead = new ListNode(0);
        ListNode smallTail = smallHead;
        ListNode bigTail = bigHead;
        ListNode cur = head;

        while (cur != null)
        {
            if (cur.val < x)
            {
                smallTail.next = cur;
                smallTail = smallTail.next;
            }
            else
            {
                bigTail.next = cur;
                bigTail = bigTail.next;
            }
            cur = cur.next;
        }

        smallTail.next = bigHead.next;
        bigTail.next = null;
        return smallHead.next;
    }
}