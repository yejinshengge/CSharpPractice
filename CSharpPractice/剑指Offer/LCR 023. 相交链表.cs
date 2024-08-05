using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR023
{
    public static void Test()
    {
        LeetCode_LCR023 obj = new LeetCode_LCR023();
    }
    
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null) return null;
        ListNode ptr1 = headA, ptr2 = headB;

        while (ptr1 != null && ptr2 != null)
        {
            ptr1 = ptr1.next;
            ptr2 = ptr2.next;
        }

        while (ptr1 != null)
        {
            ptr1 = ptr1.next;
            headA = headA.next;
        }
        
        while (ptr2 != null)
        {
            ptr2 = ptr2.next;
            headB = headB.next;
        }

        while (headA != headB)
        {
            headA = headA.next;
            headB = headB.next;
        }

        return headA == headB ? headA : null;
    }
}