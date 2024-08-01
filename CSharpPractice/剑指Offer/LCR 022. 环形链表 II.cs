using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR022
{
    public static void Test()
    {
        LeetCode_LCR022 obj = new LeetCode_LCR022();
    }
    
    public ListNode DetectCycle(ListNode head)
    {
        ListNode fast = head, slow = head;
        while (fast != null )
        {
            slow = slow.next;
            fast = fast.next;
            fast = fast?.next;
            if(slow == fast)
                break;
        }

        if (fast == null) return null;
        fast = head;
        while (fast != slow)
        {
            fast = fast.next;
            slow = slow.next;
        }

        return fast;
    }
}