using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer022GetKthFromEnd
{
    public static void Offer022GetKthFromEndMain()
    {
        Offer022GetKthFromEnd obj = new();
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);
        ListNode node = obj.GetKthFromEnd2(head, 2);
        Console.WriteLine(node);
    }

    public ListNode GetKthFromEnd(ListNode head, int k)
    {
        if (head == null)
            return head;
        Stack<ListNode> stack = new();
        ListNode cur = head;
        while (cur != null)
        {
            stack.Push(cur);
            cur = cur.next;
        }

        if (k > stack.Count)
            return null;
        
        for (int i = 1; i < k; i++)
        {
            stack.Pop();
        }

        return stack.Pop();
    }

    public ListNode GetKthFromEnd2(ListNode head, int k)
    {
        if (head == null)
            return head;
        ListNode left = head;
        ListNode right = head;
        while (right.next != null)
        {
            if (k-1 <= 0)
            {
                left = left.next;
            }
            right = right.next;
            k--;
        }
        return left;
    }
}