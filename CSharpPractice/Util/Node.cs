

namespace CSharpPractice.Util.NChildNode
{
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

namespace CSharpPractice.Util.DLink
{
    public class Node {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
    }
}
