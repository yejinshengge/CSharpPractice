using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_02_02
{
    public static void Test()
    {
        LeetCode_02_02 obj = new LeetCode_02_02();
        Console.WriteLine(obj.KthToLast(Tools.ConstructLinkedList(new []{1,2,3,4,5}),2));
    }
    
    public int KthToLast(ListNode head, int k)
    {
        ListNode fast = head, slow = head;
        for (int i = 0; i < k; i++)
        {
            fast = fast.next;
        }

        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        return slow.val;
    }
}