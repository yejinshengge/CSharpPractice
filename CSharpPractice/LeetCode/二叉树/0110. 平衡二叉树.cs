using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0110
{
    public static void Test()
    {
        LeetCode_0110 obj = new LeetCode_0110();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.left.left = new TreeNode(15);
        root.left.right = new TreeNode(7);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(7);
        Console.WriteLine(obj.IsBalanced(root));
    }

    public bool IsBalanced(TreeNode root)
    {
        return GetHeight(root) != -1;
    }

    private int GetHeight(TreeNode root)
    {
        if (root == null) return 0;
        int leftHeight = GetHeight(root.left);
        if (leftHeight == -1) return -1;
        int rightHeight = GetHeight(root.right);
        if (rightHeight == -1) return -1;

        return Math.Abs(leftHeight - rightHeight) > 1 ? -1 : Math.Max(leftHeight, rightHeight) + 1;
    }
}