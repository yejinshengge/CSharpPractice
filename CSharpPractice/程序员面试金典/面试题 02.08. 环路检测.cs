using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_02_08
{
    public static void Test()
    {
        LeetCode_02_08 obj = new LeetCode_02_08();
        ListNode node1 = new ListNode(1);
        ListNode node2 = new ListNode(2);
        node1.next = node2;
        node2.next = node1;
        Console.WriteLine(obj.DetectCycle(node1).val);
    }
    
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null) return null;
        ListNode fast = head, slow = head;
        do
        {
            if (fast == null || fast.next == null)
                return null;
            fast = fast.next.next;
            slow = slow.next;
        } while (fast != slow);

        if (slow == head) return head;
        slow = head;
        do
        {
            fast = fast.next;
            slow = slow.next;
        } while (fast != slow);

        return fast;
    }
}