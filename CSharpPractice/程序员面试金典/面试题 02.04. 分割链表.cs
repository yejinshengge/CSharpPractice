using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_02_04
{
    public static void Test()
    {
        LeetCode_02_04 obj = new LeetCode_02_04();
        Tools.PrintLinkedList(obj.Partition(Tools.ConstructLinkedList(new []{1,4,3,2,5,2}),3));
    }
    
    public ListNode Partition(ListNode head, int x)
    {
        ListNode vHead = new ListNode(-1);
        vHead.next = head;
        ListNode small = vHead, big = head;
        while (big != null)
        {
            if (big.val < x)
            {
                small = small.next;
                (small.val, big.val) = (big.val, small.val);
            }
            big = big.next;
        }

        return vHead.next;
    }
}