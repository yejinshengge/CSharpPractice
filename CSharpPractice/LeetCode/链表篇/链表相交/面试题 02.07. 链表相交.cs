using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.链表相交;

// 给你两个单链表的头节点 headA 和 headB ，请你找出并返回两个单链表相交的起始节点。
// 如果两个链表没有交点，返回 null 。
public class LeetCode_面试题0207
{
    public static void Test()
    {
        LeetCode_面试题0207 obj = new LeetCode_面试题0207();
        ListNode headA = new ListNode(1);
        headA.next = new ListNode(2);
        headA.next.next = new ListNode(3);
        headA.next.next.next = new ListNode(4);
        headA.next.next.next.next = new ListNode(5);

        ListNode headB = new ListNode(1);
        headB.next = headA.next.next.next;
        // headB.next = new ListNode(2);
        // headB.next.next = new ListNode(3);
        // headB.next.next.next = headA.next.next;
        var node = obj.GetIntersectionNode(headA,headB);
    }
    
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        HashSet<ListNode> nodeSet = new HashSet<ListNode>();
        ListNode curA = headA;
        ListNode curB = headB;
        ListNode res = null;
        while (curA != null || curB != null)
        {
            if (curA != null)
            {
                if (nodeSet.Contains(curA))
                {
                    res = curA;
                    break;
                }
                nodeSet.Add(curA);
                curA = curA.next;
            }
            if (curB != null)
            {
                if (nodeSet.Contains(curB))
                {
                    res = curB;
                    break;
                }
                nodeSet.Add(curB);
                curB = curB.next;
            }
        }

        return res;
    }
}