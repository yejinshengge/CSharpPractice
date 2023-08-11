using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

// 给定两个整数数组 preorder 和 inorder ，
// 其中 preorder 是二叉树的先序遍历， inorder 是同一棵树的中序遍历，请构造二叉树并返回其根节点。
public class LeetCode_0105
{
    public static void Test()
    {
        LeetCode_0105 obj = new LeetCode_0105();
        var node = obj.BuildTree(new[] { 3, 9, 20, 15, 7 }, new[] { 9, 3, 15, 20, 7 });
        
    }

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return DoBuild(preorder, 0, preorder.Length-1, inorder, 0, inorder.Length-1);
    }

    private TreeNode DoBuild(int[] preorder, int start1, int end1, int[] inorder, int start2, int end2)
    {
        if (end2 < start2) return null;
        TreeNode node = new TreeNode(preorder[start1]);
        
        int index = start1;
        for (int i = start2; i <= end2; i++)
        {
            if (inorder[i] == node.val) index = i;
        }

        node.left = DoBuild(preorder, start1+1, index-start2+start1,inorder,start2,index-1);
        node.right = DoBuild(preorder, index-start2+start1+1, end1,inorder,index+1,end2);

        return node;
    }
}