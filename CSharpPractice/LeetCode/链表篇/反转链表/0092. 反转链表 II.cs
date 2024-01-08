using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.链表篇.反转链表;

/**
 * 给你单链表的头指针 head 和两个整数 left 和 right ，
 * 其中 left <= right 。请你反转从位置 left 到位置 right 的链表节点，返回 反转后的链表 。
 */
public class LeetCode_0092
{
    public static void Test()
    {
        LeetCode_0092 obj = new LeetCode_0092();
        Tools.PrintLinkedList(obj.ReverseBetween(
            Tools.ConstructLinkedList(new []{1,2,3,4,5}),2,5));
        
        Tools.PrintLinkedList(obj.ReverseBetween(
            Tools.ConstructLinkedList(new []{5}),1,1));
        
        Tools.PrintLinkedList(obj.ReverseBetween(
            Tools.ConstructLinkedList(new []{1,2,3,4,5}),1,5));
    }
    
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (left == right) return head;
        int index = 1;
        ListNode vHead = new ListNode(0);
        vHead.next = head;
        ListNode preLeftNode = null;
        ListNode preRightNode = null;
        ListNode nextRightNode = null;
        ListNode rightNode = vHead;
        ListNode leftNode = vHead;

        while (index <= right)
        {
            if (index < left)
            {
                preLeftNode = leftNode;
                leftNode = leftNode.next;
                rightNode = rightNode.next;
            }
            else if(index == left)
            {
                preLeftNode = leftNode;
                leftNode = leftNode.next;
                preRightNode = rightNode;
                rightNode = rightNode.next;
                nextRightNode = rightNode.next;
                rightNode.next = preRightNode;
            }
            else
            {
                preRightNode = rightNode;
                rightNode = nextRightNode;
                nextRightNode = rightNode.next;
                rightNode.next = preRightNode;
            }
            index++;
        }

        preLeftNode.next = rightNode;
        leftNode.next = nextRightNode;
        return vHead.next;
    }
}