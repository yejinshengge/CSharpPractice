using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR027
{
    public static void Test()
    {
        LeetCode_LCR027 obj = new LeetCode_LCR027();
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(new []{1,2,3,3,2,1})));
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(new []{1,2})));
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(new []{1})));
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(new []{0,0})));
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(new []{1,1,2,1})));
    }
    
    public bool IsPalindrome(ListNode head)
    {
        if (head.next == null) return true;
        ListNode fast = head, slow = head;
        while (fast != null && fast.next != null)
        {
            fast = fast.next;
            fast = fast.next;
            slow = slow.next;
        }
        ListNode pre = null;
        while (slow != null)
        {
            ListNode next = slow.next;
            slow.next = pre;
            pre = slow;
            slow = next;
        }
        
        fast = head;
        slow = pre;
        while (slow!= null)
        {
            if (fast.val != slow.val) return false;
            fast = fast.next;
            slow = slow.next;
        }

        return true;
    }
}