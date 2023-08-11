using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0226
{
    public static void Test()
    {
        LeetCode_0226 obj = new LeetCode_0226();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);
            
        var res = obj.InvertTree(root);
    }

    public TreeNode InvertTree(TreeNode root) {
        if (root == null) return null;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count>0)
        {
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
                (node.left, node.right) = (node.right, node.left);
            }
        }

        return root;
    }
}