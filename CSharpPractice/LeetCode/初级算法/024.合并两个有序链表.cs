using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 将两个升序链表合并为一个新的 升序 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
public class LeetCode_024
{
    public static void Test()
    {
        LeetCode_024 obj = new LeetCode_024();
        ListNode head1 = new ListNode(1);
        head1.next = new ListNode(2);
        head1.next.next = new ListNode(4);
        
        ListNode head2 = new ListNode(1);
        head2.next = new ListNode(3);
        head2.next.next = new ListNode(4);

        var node = obj.MergeTwoLists(null, new ListNode(0));
        Console.WriteLine(node);
    }

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        
        ListNode cur = null;
        ListNode head = null;

        while (list1!= null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                if (head == null)
                {
                    head = list1;
                    cur = list1;
                }
                else
                {
                    cur.next = list1;
                    cur = cur.next;
                }
                list1 = list1.next;

            }
            else
            {
                if (head == null)
                {
                    head = list2;
                    cur = list2;
                }
                else
                {
                    cur.next = list2;
                    cur = cur.next;
                }
                list2 = list2.next;
            }
        }

        if (list1 != null)
            cur.next = list1;
        
        if (list2 != null)
            cur.next = list2;

        return head;

    }

}