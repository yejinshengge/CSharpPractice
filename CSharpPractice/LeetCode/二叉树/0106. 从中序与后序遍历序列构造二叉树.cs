using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

//给定两个整数数组 inorder 和 postorder ，
//其中 inorder 是二叉树的中序遍历， postorder 是同一棵树的后序遍历，请你构造并返回这颗 二叉树 
public class LeetCode_0106
{
    public static void Test()
    {
        LeetCode_0106 obj = new LeetCode_0106();
        var tree1 = obj.BuildTree(new[] { 9, 3, 15, 20, 7 }, new[] { 9, 15, 7, 20, 3 });
        var tree2 = obj.BuildTree(new[] {-1}, new[] {-1});
    }

    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        return Build(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }

    private TreeNode Build(int[] inorder, int begin1, int end1, int[] postorder, int begin2, int end2)
    {
        if (begin2 > end2) return null;
        // 后序的尾元素为根节点
        TreeNode node = new TreeNode(postorder[end2]);
        // 找出中序中该元素的位置
        int index = begin1;
        for (int i = begin1; i <= end1; i++)
        {
            if (inorder[i] == node.val)
                index = i;
        }

        node.left = Build(inorder, begin1, index - 1, postorder, begin2, begin2 + index - 1 - begin1);
        node.right = Build(inorder, index +1, end1, postorder, begin2 + index - begin1, end2-1);
        return node;
    }
}