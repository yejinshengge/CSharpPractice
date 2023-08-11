using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;
/**
 * 给出二叉 搜索 树的根节点，该树的节点值各不相同，请你将其转换为累加树（Greater Sum Tree），
 * 使每个节点 node 的新值等于原树中大于或等于 node.val 的值之和。
 */
public class LeetCode_0538
{
    public static void Test()
    {
        LeetCode_0538 obj = new LeetCode_0538();
        var tree1 = Tools.ConstructTree("4,1,6,0,2,5,7,null,null,null,3,null,null,null,8");
        var newTree1 = obj.ConvertBST(tree1);
        Tools.SequenceTraversalTree(newTree1);
        
        var tree2 = Tools.ConstructTree("0,null,1");
        var newTree2 = obj.ConvertBST(tree2);
        Tools.SequenceTraversalTree(newTree2);
        
        var tree3 = Tools.ConstructTree("1,0,2");
        var newTree3 = obj.ConvertBST(tree3);
        Tools.SequenceTraversalTree(newTree3);
        
        var tree4 = Tools.ConstructTree("3,2,4,1");
        var newTree4 = obj.ConvertBST(tree4);
        Tools.SequenceTraversalTree(newTree4);
    }

    public TreeNode ConvertBST1(TreeNode root)
    {
        TreeNode cur = root;
        TreeNode pre = null;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while (cur != null || stack.Count > 0)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.right;
            }
            else
            {
                cur = stack.Pop();
                if (pre != null)
                    cur.val += pre.val;
                pre = cur;
                cur = cur.left;
            }
        }

        return root;
    }

    private int pre = 0;
    public TreeNode ConvertBST(TreeNode root)
    {
        pre = 0;
        DoConvert(root);
        return root;
    }

    private void DoConvert(TreeNode root)
    {
        if(root == null) return;
        DoConvert(root.right);
        root.val += pre;
        pre = root.val;
        DoConvert(root.left);
    }
}