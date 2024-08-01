using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR021
{
    public static void Test()
    {
        LeetCode_LCR021 obj = new LeetCode_LCR021();
        Tools.PrintLinkedList(obj.RemoveNthFromEnd(Tools.ConstructLinkedList(new []{1,2,3,4,5}),2));
        Tools.PrintLinkedList(obj.RemoveNthFromEnd(Tools.ConstructLinkedList(new []{1}),1));
        Tools.PrintLinkedList(obj.RemoveNthFromEnd(Tools.ConstructLinkedList(new []{1,2}),1));
    }
    
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode vHead = new ListNode();
        vHead.next = head;
        ListNode slow = vHead, fast = vHead;
        for (int i = 0; i < n; i++)
        {
            fast = fast.next;
        }

        while (fast.next != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        return vHead.next;
    }
}