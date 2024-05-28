using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_02_07
{
    public static void Test()
    {
        LeetCode_02_07 obj = new LeetCode_02_07();
    }
    
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null) return null;
        ListNode pA = headA, pB = headB;
        while (pA != pB)
        {
            pA = pA == null ? headB : pA.next;
            pB = pB == null ? headA : pB.next;
        }

        return pA;
    }
}