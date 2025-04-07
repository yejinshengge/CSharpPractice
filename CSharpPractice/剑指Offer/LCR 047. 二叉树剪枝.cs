using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR047
{
    public static void Test()
    {
        LeetCode_LCR047 obj = new LeetCode_LCR047();
    }
    
    public TreeNode PruneTree(TreeNode root)
    {
        if (_pruneTree(root))
            return null;
        return root;
    }

    private bool _pruneTree(TreeNode node)
    {
        if (node == null) return true;
        // 后序遍历
        var pruneLeft = _pruneTree(node.left);
        var pruneRight = _pruneTree(node.right);
        if (pruneLeft)
            node.left = null;
        if (pruneRight)
            node.right = null;
        return node.val == 0 && pruneLeft && pruneRight;
    }
}