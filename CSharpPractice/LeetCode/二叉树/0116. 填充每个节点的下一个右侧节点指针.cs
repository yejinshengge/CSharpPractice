namespace CSharpPractice.LeetCode.二叉树;
// 给定一个 完美二叉树 ，其所有叶子节点都在同一层，每个父节点都有两个子节点。二叉树定义如下：
public class LeetCode_0116
{
    public static void Test()
    {
        LeetCode_0116 obj = new LeetCode_0116();
        Node root = new Node(1);
        root.left = new Node(3);
        root.right = new Node(2);
        root.left.left = new Node(5);
        root.left.right = new Node(3);
        root.right.left = new Node(6);
        root.right.right = new Node(9);
        var head = obj.Connect(root);
    }

    public Node Connect(Node root)
    {
        if (root == null) return null;
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        
        while (queue.Count>0)
        {
            int count = queue.Count;
            Node pre = null;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
                if (pre != null)
                    pre.next = node;
                pre = node;
            }

        }
        return root;
    }


    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}