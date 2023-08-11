using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

// 给定二叉树的根节点 root ，返回所有左叶子之和。
public class LeetCode_0404
{
    public static void Test()
    {
        LeetCode_0404 obj = new LeetCode_0404();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.left.left = new TreeNode(15);
        root.left.right = new TreeNode(7);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(7);
        Console.WriteLine(obj.SumOfLeftLeaves(root));
    }

    public int SumOfLeftLeaves(TreeNode root)
    {
        if (root == null) return 0;
        int leftSum = 0;
        if (root.left != null && root.left.left == null && root.left.right == null)
            leftSum = root.left.val;
        return leftSum + SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
    }
}