namespace CSharpPractice.LeetCode.二叉树;

/**
给定一个二叉树：

struct Node {
  int val;
  Node *left;
  Node *right;
  Node *next;
}
填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL 。

初始状态下，所有 next 指针都被设置为 NULL 。
 */
public class LeetCode_0117
{
    public static void Test()
    {
        LeetCode_0117 obj = new LeetCode_0117();
    }

    public Node Connect(Node root) {
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