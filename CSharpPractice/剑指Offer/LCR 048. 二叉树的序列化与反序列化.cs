using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR048
{
    public static void Test()
    {
        LeetCode_LCR048 obj = new LeetCode_LCR048();
        var tree = Tools.ConstructTree("1,2,3,null,null,4,5");
        Codec dec = new();
        string se = dec.serialize(tree);
        dec.deserialize(se);
    }
    
    public class Codec {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            StringBuilder sb = new();
            Stack<TreeNode> stack = new();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node == null)
                    sb.Append("null");
                else
                {
                    sb.Append(node.val);
                    stack.Push(node.right);
                    stack.Push(node.left);
                }
                sb.Append(",");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            var nodes = data.Split(",");
            int index = 0;
            return _deserialize(nodes, ref index);
        }

        private TreeNode _deserialize(string[] nodes, ref int index)
        {
            if (index >= nodes.Length) return null;
            var nodeStr = nodes[index];
            index++;
            if (nodeStr == "null") return null;
            TreeNode node = new TreeNode(int.Parse(nodeStr));
            Console.Write(index+" ");
            node.left = _deserialize(nodes, ref index);
            node.right = _deserialize(nodes, ref index);
            return node;
        }
    }
}