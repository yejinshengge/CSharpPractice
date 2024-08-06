using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR026
{
    public static void Test()
    {
        LeetCode_LCR026 obj = new LeetCode_LCR026();
        var head1 = Tools.ConstructLinkedList(new []{1,2,3,4});
        obj.ReorderList(head1);
        Tools.PrintLinkedList(head1);
        var head2 = Tools.ConstructLinkedList(new []{1,2,3,4,5});
        obj.ReorderList(head2);
        Tools.PrintLinkedList(head2);
    }
    
    public void ReorderList(ListNode head)
    {
        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode cur = head;
        while (cur != null)
        {
            stack.Push(cur);
            cur = cur.next;
        }
        
        cur = head;
        while (stack.Count > 0)
        {
            ListNode next = cur.next;
            cur.next = stack.Pop();
            cur = cur.next;
            if(cur == cur.next) break;
            cur.next = next;
            cur = cur.next;
            if(cur == cur.next) break;
        }

        cur.next = null;
    }
}