using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR025
{
    public static void Test()
    {
        LeetCode_LCR025 obj = new LeetCode_LCR025();
    }
    
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        Stack<ListNode> stack1 = new Stack<ListNode>();
        Stack<ListNode> stack2 = new Stack<ListNode>();

        while (l1 != null)
        {
            stack1.Push(l1);
            l1 = l1.next;
        }
        while (l2 != null)
        {
            stack2.Push(l2);
            l2 = l2.next;
        }

        ListNode pre = null;
        int flag = 0;
        while (stack1.Count > 0 && stack2.Count > 0)
        {
            var node1 = stack1.Pop();
            var node2 = stack2.Pop();

            ListNode newNode = new ListNode((node1.val + node2.val + flag)%10);
            flag = (node1.val + node2.val + flag) / 10;
            newNode.next = pre;
            pre = newNode;
        }

        while (stack1.Count > 0)
        {
            var curNode = stack1.Pop();
            ListNode newNode = new ListNode((curNode.val + flag)%10);
            flag = (curNode.val + flag) / 10;
            newNode.next = pre;
            pre = newNode;
        }
        
        while (stack2.Count > 0)
        {
            var curNode = stack2.Pop();
            ListNode newNode = new ListNode((curNode.val + flag)%10);
            flag = (curNode.val + flag) / 10;
            newNode.next = pre;
            pre = newNode;
        }

        if (flag > 0)
        {
            ListNode newNode = new ListNode(flag);
            newNode.next = pre;
            pre = newNode;
        }

        return pre;
    }
}