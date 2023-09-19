using CSharpPractice.Util;
using CSharpPractice.Util.NChildNode;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0429
{
    public static void Test()
    {
        LeetCode_0429 obj = new LeetCode_0429();
        Node head = new Node(1);
        head.children = new List<Node>() { new Node(3), new Node(2), new(4) };
        head.children[0].children = new List<Node>() { new Node(5), new Node(6) };
        Util.Tools.PrintEnumerator(obj.LevelOrder(head));
    }

    public IList<IList<int>> LevelOrder(Node root)
    {
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null) return res;
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        
        while (queue.Count>0)
        {
            res.Add(new List<int>());
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if (node.children != null)
                {
                    for (int j = 0; j < node.children.Count; j++)
                    {
                        queue.Enqueue(node.children[j]);
                    }
                }
                res[^1].Add(node.val);
            }
        }
        
        return res;
    }
    
}