using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针.链表;

/**
 * 给定一个已排序的链表的头 head ， 删除原始链表中所有重复数字的节点，只留下不同的数字 。返回 已排序的链表 。
 */
public class LeetCode_0082
{
    public static void Test()
    {
        LeetCode_0082 obj = new LeetCode_0082();
        var list = Tools.ConstructLinkedList(new[] { 1, 2, 3, 3, 4, 4, 5 });
        Tools.PrintLinkedList(obj.DeleteDuplicates(list));
        list = Tools.ConstructLinkedList(new[] { 1, 1, 1, 2, 3 });
        Tools.PrintLinkedList(obj.DeleteDuplicates(list));
        list = Tools.ConstructLinkedList(new[] { 1, 1});
        Tools.PrintLinkedList(obj.DeleteDuplicates(list));
    }
    
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null||head.next == null) return head;
        ListNode vHead = new ListNode(-101);
        vHead.next = head;
        ListNode left = vHead, right = head.next;
        while (right != null)
        {
            if (left.next.val == right.val)
                right = right.next;
            else if (left.next.next != right)
                left.next = right;
            else
            {
                left = left.next;
                right = right.next;
            }
        }
        if (left.next.next != right)
            left.next = right;
        return vHead.next;
    }
}