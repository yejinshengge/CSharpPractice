
using CSharpPractice.Util.DLink;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR028
{
    public static void Test()
    {
        LeetCode_LCR028 obj = new LeetCode_LCR028();
    }
    
    public Node Flatten(Node head)
    {
        ExpandChild(head);
        return head;
    }

    private Node ExpandChild(Node head)
    {
        if (head == null) return head;
        if (head.child != null)
        {
            Node next = head.next;
            Node tail = ExpandChild(head.child);
            head.next = head.child;
            head.child.prev = head;
            head.child = null;
            if(tail != null)
                tail.next = next;
            if (next != null)
                next.prev = tail;
        }
        if(head.next != null)
            return ExpandChild(head.next);
        return head;
    }

}