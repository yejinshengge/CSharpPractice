using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;
// 给定一个二叉搜索树, 找到该树中两个指定节点的最近公共祖先。
public class LeetCode_0235
{
    public static void Test()
    {
        LeetCode_0235 obj = new LeetCode_0235();
        var tree = Tools.ConstructTree("6,2,8,0,4,7,9,null,null,3,5");
        var node = obj.LowestCommonAncestor(tree, tree.left, tree.left.right);
        Console.WriteLine(node==null?"null":node.val);
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode small = p.val < q.val ? p : q;
        TreeNode big = p.val > q.val ? p : q;
        
        TreeNode cur = root;
        while (cur != null)
        {
            if (cur.val >= small.val && cur.val <= big.val)
                return cur;
            if (cur.val < small.val)
                cur = cur.right;
            else if (cur.val > big.val)
                cur = cur.left;
        }
        return null;
    }
}