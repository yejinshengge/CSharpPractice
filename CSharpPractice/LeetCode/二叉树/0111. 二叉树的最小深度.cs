using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0111
{
    public static void Test()
    {
        LeetCode_0111 obj = new LeetCode_0111();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);
        Console.WriteLine(obj.MinDepth(root));
    }
    
    public int MinDepth(TreeNode root) {
        if (root == null) return 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        int depth = 0;
        while (queue.Count>0)
        {
            int count = queue.Count;
            depth++;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
                if (node.right == null && node.left == null)
                    return depth;
            }
        }
        return depth;
    }
}