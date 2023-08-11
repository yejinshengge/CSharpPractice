using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer027MirrorTree
{
    public static void Offer027MirrorTreeMain()
    {
        Offer027MirrorTree obj = new();
        TreeNode head = new(4);
        head.left = new(1);
        head.right = new(2);
        head.left.left = new(3);
        head.right.right = new(5);

        obj.MirrorTree(head);
        Console.WriteLine(head);
    }

    public TreeNode MirrorTree(TreeNode root)
    {
        ReverseTree(root);
        return root;
    }

    public void ReverseTree(TreeNode root)
    {
        if(root == null)
            return;
        if (root.left != null || root.right != null)
            (root.left, root.right) = (root.right, root.left);
        ReverseTree(root.left);
        ReverseTree(root.right);
    }
}