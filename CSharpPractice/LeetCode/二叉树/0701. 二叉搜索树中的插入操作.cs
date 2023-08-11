using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0701
{
    public static void Test()
    {
        LeetCode_0701 obj = new LeetCode_0701();
        var tree = Tools.ConstructTree("4,2,7,1,3,null,null,null,null,null,null");
        var node = obj.InsertIntoBST(tree,5);
        Tools.SequenceTraversalTree(node);
        
    }

    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null) return new TreeNode(val);
        TreeNode cur = root;
        while (cur != null)
        {
            if (cur.val > val)
            {
                if (cur.left == null)
                {
                    cur.left = new TreeNode(val);
                    break;
                }
                cur = cur.left;
            }
            else if (cur.val < val)
            {
                if (cur.right == null)
                {
                    cur.right = new TreeNode(val);
                    break;
                }
                cur = cur.right;
            }
        }
        return root;
    }
}