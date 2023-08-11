using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

// 给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。
public class LeetCode_0236
{
    public static void Test()
    {
        LeetCode_0236 obj = new LeetCode_0236();
        var tree = Tools.ConstructTree("1,2");
        var node = obj.LowestCommonAncestor(tree, tree, tree.left);
        Console.WriteLine(node ==null?"null":node.val);
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q) return root;
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null) return root;
        if (left != null) return left;
        return right;
    }
}