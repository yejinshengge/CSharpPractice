using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针.链表;

/**
 * 给定一个已排序的链表的头 head ， 删除所有重复的元素，使每个元素只出现一次 。返回 已排序的链表 。
 */
public class LeetCode_0083
{
    public static void Test()
    {
        LeetCode_0083 obj = new LeetCode_0083();
        Tools.PrintLinkedList(obj.DeleteDuplicates(Tools.ConstructLinkedList(new []{1,1,2})));
        Tools.PrintLinkedList(obj.DeleteDuplicates(Tools.ConstructLinkedList(new []{1,1,2,3,3})));
    }
    
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode left = head, right = head;
        while (right != null)
        {
            if (left.val == right.val)
                right = right.next;
            else
            {
                left.next = right;
                left = left.next;
                right = right.next;
            }
        }

        left.next = right;
        return head;
    }
}