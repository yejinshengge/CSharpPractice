using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0222
{
    public static void Test()
    {
        LeetCode_0222 obj = new LeetCode_0222();
        
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.left.left = new TreeNode(15);
        root.left.right = new TreeNode(7);
        
        Console.WriteLine(obj.CountNodes2(root));
    }

    public int CountNodes(TreeNode root)
    {
        if (root == null) return 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int res = 0;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if(node.left != null)
                queue.Enqueue(node.left);
            if(node.right != null)
                queue.Enqueue(node.right);
            res++;
        }

        return res;
    }

    public int CountNodes2(TreeNode root)
    {
        if (root == null) return 0;
        
        int rightDepth = 0;
        var right = root.right;
        while (right != null)
        {
            right = right.right;
            rightDepth++;
        }
        
        int leftDepth = 0;
        var left = root.left;
        while (left != null)
        {
            left = left.left;
            leftDepth++;
        }

        if (leftDepth == rightDepth)
            return (2<<leftDepth) - 1;
        return CountNodes2(root.left) + CountNodes2(root.right) + 1;
    }
}