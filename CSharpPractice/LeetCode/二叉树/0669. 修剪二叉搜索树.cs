using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

/**
给你二叉搜索树的根节点 root ，同时给定最小边界low 和最大边界 high。通过修剪二叉搜索树，
使得所有节点的值在[low, high]中。修剪树 不应该 改变保留在树中的元素的相对结构 (即，如果没有被移除，原有的父代子代关系都应当保留)。 
可以证明，存在 唯一的答案 。
所以结果应当返回修剪好的二叉搜索树的新的根节点。注意，根节点可能会根据给定的边界发生改变。
 */
public class LeetCode_0669
{
    public static void Test()
    {
        LeetCode_0669 obj = new LeetCode_0669();
        var tree1 = Tools.ConstructTree("1,0,2");
        var newTree1 = obj.TrimBST(tree1, 1, 2);
        Tools.SequenceTraversalTree(newTree1);
        
        var tree2 = Tools.ConstructTree("3,0,4,null,2,null,null,1");
        var newTree2 = obj.TrimBST(tree2, 1, 3);
        Tools.SequenceTraversalTree(newTree2);
        
        var tree3 = Tools.ConstructTree("3,1,4,null,2");
        var newTree3 = obj.TrimBST(tree3, 3, 4);
        Tools.SequenceTraversalTree(newTree3);
    }

    public TreeNode TrimBST(TreeNode root, int low, int high)
    {
        if (root == null) return null;
        if (root.val > high)
            return TrimBST(root.left, low, high);
        if (root.val < low)
            return TrimBST(root.right, low, high);
        root.left = TrimBST(root.left, low, high);
        root.right = TrimBST(root.right, low, high);
        return root;
    }
}