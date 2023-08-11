using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 给你一个单链表的头节点 head ，请你判断该链表是否为回文链表。如果是，返回 true ；否则，返回 false 。
public class LeetCode_025
{
    public static void Test()
    {
        LeetCode_025 obj = new LeetCode_025();
        ListNode head = new ListNode(1);
        // head.next = new ListNode(0);
        // head.next.next = new ListNode(1);
        // head.next.next.next = new ListNode(1);
        // head.next.next.next.next = new ListNode(1);
        
        Console.WriteLine(obj.IsPalindrome2(head));
    }
    
    // 思路一:栈
    public bool IsPalindrome(ListNode head)
    {
        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode cur = head;

        while (cur != null)
        {
            stack.Push(cur);
            cur = cur.next;
        }

        while (stack.Count > 0)
        {
            if (stack.Pop().val != head.val) return false;
            head = head.next;
        }

        return true;
    }
    
    // 思路二:快慢指针,反转链表
    public bool IsPalindrome2(ListNode head)
    {
        ListNode fast = head;
        ListNode slow = head;

        bool flag = false;
        while (fast != null)
        {
            if (flag) slow = slow.next;
            fast = fast.next;
            flag = !flag;
        }
        
        // 反转链表
        ListNode cur = slow.next;
        ListNode pre = slow;
        while (cur != null)
        {
            var temp = cur.next;
            cur.next = pre;
            pre = cur;
            cur = temp;
        }

        slow.next = null;

        while (pre != null)
        {
            if (pre.val != head.val) return false;
            pre = pre.next;
            head = head.next;
        }

        return true;
    }
    
}