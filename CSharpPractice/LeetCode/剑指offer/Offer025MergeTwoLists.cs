using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer025MergeTwoLists
{
    public static void Offer025MergeTwoListsMain()
    {
        Offer025MergeTwoLists obj = new();
        ListNode l1 = new(1);
        l1.next = new (2);
        l1.next.next = new (4);
        l1.next.next.next = new (7);
        
        ListNode l2 = new(1);
        l2.next = new (3);
        l2.next.next = new (4);
        l2.next.next.next = new (8);
        var node = obj.MergeTwoLists2(l1,l2);
        Console.WriteLine(node);
    }

    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        ListNode head = null;
        ListNode cur = null;
        while (l1 != null && l2 != null)
        {
            if (l1.val > l2.val)
            {
                if (head == null)
                {
                    head = l2;
                    cur = l2;
                }
                else
                {
                    cur.next = l2;
                    cur = cur.next;
                }

                l2 = l2.next;
            }
            else
            {
                if (head == null)
                {
                    head = l1;
                    cur = l1;
                }
                else
                {
                    cur.next = l1;
                    cur = cur.next;
                }
                l1 = l1.next;
            }

        }

        if (l1 != null)
            cur.next = l1;
        if (l2 != null)
            cur.next = l2;
        return head;
    }

    public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        if (l1.val > l2.val)
        {
            l2.next = MergeTwoLists2(l1, l2.next);
            return l2;
        }
        else
        {
            l1.next = MergeTwoLists2(l1.next, l2);
            return l1;
        }
    }
}