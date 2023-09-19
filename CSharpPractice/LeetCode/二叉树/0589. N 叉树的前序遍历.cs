using CSharpPractice.Util;
using CSharpPractice.Util.NChildNode;

namespace CSharpPractice.LeetCode.二叉树;

/**
给定一个 n 叉树的根节点  root ，返回 其节点值的 前序遍历 。

n 叉树 在输入中按层序遍历进行序列化表示，每组子节点由空值 null 分隔（请参见示例）。
 */
public class LeetCode_0589
{
    public static void Test()
    {
        LeetCode_0589 obj = new LeetCode_0589();
        Node root = new Node(1);
        Node node1 = new Node(3);
        node1.children = new List<Node>()
        {
            new Node(5),
            new Node(6)
        };
        root.children = new List<Node>()
        {
            node1,
            new Node(2),
            new Node(4)
        };
        
        Tools.PrintEnumerator(obj.Preorder(root));
    }
    
    public IList<int> Preorder(Node root)
    {
        IList<int> res = new List<int>();
        if (root == null) return res;
        Stack<Node> stack = new Stack<Node>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            res.Add(node.val);
            if (node.children != null)
            {
                for (int i = node.children.Count-1; i >= 0 ; i--)
                {
                    stack.Push(node.children[i]);
                }
            }
        }

        return res;
    }
}