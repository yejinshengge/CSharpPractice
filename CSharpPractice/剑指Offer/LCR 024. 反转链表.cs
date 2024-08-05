using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR024
{
    public static void Test()
    {
        LeetCode_LCR024 obj = new LeetCode_LCR024();
    }
    
    public ListNode ReverseList(ListNode head)
    {
        if (head == null) return head;
        ListNode pre = null;
        while (head.next != null)
        {
            var next = head.next;
            head.next = pre;
            pre = head;
            head = next;
        }
        head.next = pre;
        return head;
    }
}