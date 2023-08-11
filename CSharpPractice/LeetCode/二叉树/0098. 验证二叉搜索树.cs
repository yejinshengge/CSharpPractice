using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

/**
给你一个二叉树的根节点 root ，判断其是否是一个有效的二叉搜索树。

有效 二叉搜索树定义如下：

节点的左子树只包含 小于 当前节点的数。
节点的右子树只包含 大于 当前节点的数。
所有左子树和右子树自身必须也是二叉搜索树。
 */
public class LeetCode_0098
{
    public static void Test()
    {
        LeetCode_0098 obj = new LeetCode_0098();
        var node = Tools.ConstructTree("5,1,4,null,null,3,6");
        Console.WriteLine(obj.IsValidBST2(node));
    }

    public bool IsValidBST(TreeNode root)
    {
        List<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node != null)
            {
                if(node.right != null) stack.Push(node.right);
                stack.Push(node);
                stack.Push(null);
                if(node.left != null) stack.Push(node.left);
            }
            else
            {
                node = stack.Pop();
                res.Add(node.val);
            }
        }

        
        for (int i = 1; i < res.Count; i++)
        {
            if (res[i] <= res[i - 1]) return false;
        }

        return true;
    }

    private long max = long.MinValue;
    public bool IsValidBST2(TreeNode root)
    {
        if (root == null) return true;
        bool left = IsValidBST2(root.left);
        if (max < root.val) max = root.val;
        else return false;
        bool right = IsValidBST2(root.right);
        return left && right;
    }
}