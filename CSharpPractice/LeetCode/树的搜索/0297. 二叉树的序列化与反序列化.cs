using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.树的搜索;

public class LeetCode_0297
{
    public static void Test()
    {
        LeetCode_0297 obj = new LeetCode_0297();
        Tools.SequenceTraversalTree(obj.deserialize(obj.serialize(Tools.ConstructTree("1,2,3,null,null,4,5"))));
        Tools.SequenceTraversalTree(obj.deserialize(obj.serialize(Tools.ConstructTree("1,2,3,null,null,4,5,6,7"))));
    }
    
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root == null) return string.Empty;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        StringBuilder res = new StringBuilder();
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node != null)
            {
                res.Append(node.val);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            else
            {
                res.Append("null");
            }
            res.Append(",");
        }
        return res.ToString(0, res.Length - 1);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrEmpty(data)) return null;
        var arr = data.Split(",");
        Queue<TreeNode> queue = new Queue<TreeNode>();
        var root = new TreeNode(int.Parse(arr[0]));
        queue.Enqueue(root);
        int index = 1;

        while (index < arr.Length)
        {
            var node = queue.Dequeue();
            if (node != null)
            {
                node.left = arr[index] == "null" ? null : new TreeNode(int.Parse(arr[index]));
                queue.Enqueue(node.left);
                index++;
                if (index < arr.Length)
                {
                    node.right = arr[index] == "null" ? null : new TreeNode(int.Parse(arr[index]));
                    queue.Enqueue(node.right);
                    index++;
                }
            }
        }

        return root;
    }
}