using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

/**
给定二叉搜索树（BST）的根节点 root 和一个整数值 val。

你需要在 BST 中找到节点值等于 val 的节点。 返回以该节点为根的子树。 如果节点不存在，则返回 null 。
 */
public class LeetCode_0700
{
    public static void Test()
    {
        LeetCode_0700 obj = new LeetCode_0700();
        var tree1 = Tools.ConstructTree("4,2,7,1,3");
        var node1 = obj.SearchBST(tree1, 2);        
        
        var tree2 = Tools.ConstructTree("4,2,7,1,3");
        var node2 = obj.SearchBST(tree2, 5);
        
    }

    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root == null) return null;
        if (val > root.val)
            return SearchBST(root.right, val);
        if (val < root.val)
            return SearchBST(root.left, val);
        return root;
    }
}