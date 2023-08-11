using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.环形链表;
/**
给定一个链表的头节点 head，返回链表开始入环的第一个节点。如果链表无环，则返回null。
如果链表中有某个节点，可以通过连续跟踪 next 指针再次到达，则链表中存在环。 
为了表示给定链表中的环，评测系统内部使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。
如果 pos 是 -1，则在该链表中没有环。注意：pos 不作为参数进行传递，仅仅是为了标识链表的实际情况。
不允许修改 链表。
 */
public class LeetCode_0142
{
    public static void Test()
    {
        LeetCode_0142 obj = new LeetCode_0142();
        ListNode headA = new ListNode(1);
        // headA.next = new ListNode(2);
        // headA.next.next = new ListNode(3);
        // headA.next.next.next = new ListNode(4);
        // headA.next.next.next.next = new ListNode(5);
        // headA.next.next.next.next.next = headA.next;
        var node = obj.DetectCycle(headA);
        
    }

    public ListNode DetectCycle(ListNode head)
    {
        HashSet<ListNode> nodeSet = new HashSet<ListNode>();
        ListNode cur = head;
        while (cur != null)
        {
            if (nodeSet.Contains(cur))
                return cur;
            nodeSet.Add(cur);
            cur = cur.next;
        }
        return null;
    }
}