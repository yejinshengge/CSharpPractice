namespace CSharpPractice.LeetCode.二叉树;
using Util;

// 给你二叉树的根节点 root ，返回它节点值的 前序 遍历。
public class LeetCode_0144
{
    public static void Test()
    {
        LeetCode_0144 obj = new LeetCode_0144();
        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(3);
        Tools.PrintEnumerator(obj.PreorderTraversal(root));
    }

    public IList<int> PreorderTraversal(TreeNode root)
    {
        IList<int> res = new List<int>();
        Preorder(res,root);
        return res;
    }

    private void Preorder(IList<int> res,TreeNode node)
    {
        if(node == null) return;
        res.Add(node.val);
        Preorder(res,node.left);
        Preorder(res,node.right);
    }
}