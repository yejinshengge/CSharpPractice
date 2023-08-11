using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

// 给定一个二叉树的 根节点 root，请找出该二叉树的 最底层 最左边 节点的值。
public class LeetCode_0513
{
    public static void Test()
    {
        LeetCode_0513 obj = new LeetCode_0513();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.left.left = new TreeNode(4);
        root.right.left = new TreeNode(5);
        root.right.right = new TreeNode(6);
        root.right.left.left = new TreeNode(7);

        Console.WriteLine(obj.FindBottomLeftValue(root));
    }

    public int FindBottomLeftValue(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int left = root.val;
        while (queue.Count > 0)
        {
            int count = queue.Count;
            left = queue.Peek().val;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }

        }
        return left;
    }
}