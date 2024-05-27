using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_02_05
{
    public static void Test()
    {
        LeetCode_02_05 obj = new LeetCode_02_05();
        Tools.PrintLinkedList(
            obj.AddTwoNumbers(Tools.ConstructLinkedList(new []{2,4,3})
                ,Tools.ConstructLinkedList(new []{5,6,4})));
    }
    
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode vHead = new ListNode();
        ListNode cur = vHead;
        int carry = 0;
        while (l1 != null || l2 != null || carry != 0)
        {
            int sum = 0;
            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            if (carry != 0)
            {
                sum += carry;
                carry = 0;
            }

            carry = sum / 10;
            sum = sum % 10;
            cur.next = new ListNode(sum);
            cur = cur.next;
        }

        return vHead.next;
    }
}