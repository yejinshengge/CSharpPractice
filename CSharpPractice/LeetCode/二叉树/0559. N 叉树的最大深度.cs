namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0559
{
    public static void Test()
    {
        LeetCode_0559 obj = new LeetCode_0559();
        Node head = new Node(1);
        head.children = new List<Node>() { new Node(3), new Node(2), new(4) };
        head.children[0].children = new List<Node>() { new Node(5), new Node(6) };
        Console.WriteLine(obj.MaxDepth(head));
    }

    public int MaxDepth(Node root)
    {
        if (root == null) return 0;
        int maxDepth = 0;
        if (root.children != null)
        {
            for (int i = 0; i < root.children.Count; i++)
            {
                maxDepth = Math.Max(maxDepth, MaxDepth(root.children[i]));
            }
        }

        return maxDepth+1;
    }


    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}