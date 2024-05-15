namespace CSharpPractice.LeetCode.树的搜索;

public class LeetCode_0117
{
    
    public static void Test()
    {
        LeetCode_0117 obj = new LeetCode_0117();
    }
    
    public Node Connect(Node root)
    {
        Node cur = root, head = new Node(), tail = head;
        while (cur != null)
        {
            if (cur.left != null)
            {
                tail.next = cur.left;
                tail = tail.next;
            }

            if (cur.right != null)
            {
                tail.next = cur.right;
                tail = tail.next;
            }

            if (cur.next == null)
            {
                cur = head.next;
                head.next = null;
                tail = head;
            }
            else
            {
                cur = cur.next;
            }
        }
        return root;
    }
    
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}