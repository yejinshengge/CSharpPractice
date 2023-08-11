using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 给你一个链表的头节点 head ，判断链表中是否有环。
public class LeetCode_026
{
    public static void Test()
    {
        LeetCode_026 obj = new LeetCode_026();
        ListNode head = new ListNode(3);
        head.next = new ListNode(2);
        head.next.next = new ListNode(0);
        head.next.next.next = new ListNode(-4);
        head.next.next.next.next = head.next;
        
        Console.WriteLine(obj.HasCycle(null));
    }

    // 思路一:快慢指针
    public bool HasCycle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        bool flag = false;
        while (fast != null)
        {
            if (flag) slow = slow.next;
            flag = !flag;
            fast = fast.next;
            if (fast == slow) return true;
        }

        return false;
    }
    
}