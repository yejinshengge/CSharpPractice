using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer007BuildTree
{
    public static void Offer007BuildTreeMain()
    {
        Offer007BuildTree obj = new();
        int[] preorder = {3, 9, 20, 15, 7};
        int[] inorder = {9, 3, 15, 20, 7};
        TreeNode tree = obj.BuildTree(preorder, inorder);
        Console.WriteLine(tree);
    }
    private Dictionary<int, int> _dic = new();
    private int[] _preorder;
    private int[] _inorder;
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder == null  || inorder == null)
            return null;
        int preLen = preorder.Length;
        int inLen = inorder.Length;
        if (preLen == 0 || inLen == 0)
            return null;
        _preorder = preorder;
        _inorder = inorder;
        // 将中序数组的 元素-下标 存入字典
        for (int i = 0; i < inorder.Length; i++)
        {
            _dic[inorder[i]] = i;
        }
        return GetHead(0,inLen-1,0,preLen-1);
    }
    
    private TreeNode GetHead(int inLeft,int inRight,int preLeft,int preRight)
    {
        // 左指针超过右指针,跳出递归
        if (preLeft > preRight)
            return null;
        // 前序数组第一个元素是整棵树的根节点
        TreeNode node = new TreeNode(_preorder[preLeft]);
        // 根节点位置
        int root = _dic[_preorder[preLeft]];
        // 左树长度
        int leftLen = root - inLeft;
        node.left = GetHead(inLeft, root - 1, preLeft + 1, preLeft + leftLen);
        node.right = GetHead(root+1,inRight,preLeft+leftLen+1,preRight);
        return node;
    }
    
}