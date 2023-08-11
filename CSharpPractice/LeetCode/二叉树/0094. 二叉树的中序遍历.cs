using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

// 给定一个二叉树的根节点 root ，返回 它的 中序 遍历 。
public class LeetCode_0094
{
    public static void Test()
    {
        LeetCode_0094 obj = new LeetCode_0094();
        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(3);
        Util.Tools.PrintEnumerator(obj.InorderTraversal(root));
    }
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> res = new List<int>();
        Inorder(res,root);
        return res;
    }
    
    private void Inorder(IList<int> res,TreeNode node)
    {
        if(node == null) return;
        Inorder(res,node.left);
        res.Add(node.val);
        Inorder(res,node.right);
    }
}