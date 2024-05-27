using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_02_01
{
    public static void Test()
    {
        LeetCode_02_01 obj = new LeetCode_02_01();
        Tools.PrintLinkedList(obj.RemoveDuplicateNodes(
            Tools.ConstructLinkedList(new []{1, 2, 3, 3, 2, 1})));
        Tools.PrintLinkedList(obj.RemoveDuplicateNodes(
            Tools.ConstructLinkedList(new []{1, 1, 1, 1, 2})));
    }
    
    public ListNode RemoveDuplicateNodes(ListNode head)
    {
        HashSet<int> set = new HashSet<int>();
        ListNode cur = head;
        ListNode pre = head;
        while (cur != null)
        {
            if (!set.Add(cur.val))
                pre.next = cur.next;
            else
                pre = cur;
            cur = cur.next;
        }

        return head;
    }
}