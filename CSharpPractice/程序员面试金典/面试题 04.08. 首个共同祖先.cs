using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_08
{
    public static void Test()
    {
        LeetCode_04_08 obj = new LeetCode_04_08();
    }
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == q || root == p || root == null) return root;
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null)
            return root;
        return left != null ? left : right;
    }
}