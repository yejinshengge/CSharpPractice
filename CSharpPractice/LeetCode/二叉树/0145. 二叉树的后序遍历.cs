using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0145
{
    public static void Test()
    {
        LeetCode_0145 obj = new LeetCode_0145();
        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(3);
        Util.Tools.PrintEnumerator(obj.PostorderTraversal(root));
    }
    public IList<int> PostorderTraversal(TreeNode root) {
        IList<int> res = new List<int>();
        Postorder(res,root);
        return res;
    }
    
    private void Postorder(IList<int> res,TreeNode node)
    {
        if(node == null) return;
        Postorder(res,node.left);
        Postorder(res,node.right);
        res.Add(node.val);
    }
}