
using CSharpPractice.Util.NormalNode;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR029
{
    public static void Test()
    {
        LeetCode_LCR029 obj = new LeetCode_LCR029();
    }
    
    public Node Insert(Node head, int insertVal)
    {
        Node newNode = new Node(insertVal);
        newNode.next = newNode;
        if (head == null)
        {
            return newNode;
        }
        Node pre = head;
        Node next = head.next;

        while (next != head)
        {
            if (pre.val <= insertVal && next.val >= insertVal)
                break;
            if(pre.val > next.val && (insertVal <= next.val||insertVal >= pre.val))
                break;
            pre = next;
            next = next.next;
        }

        pre.next = newNode;
        newNode.next = next;
        return head;
    }
}