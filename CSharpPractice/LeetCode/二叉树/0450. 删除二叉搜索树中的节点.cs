using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

// 给定一个二叉搜索树的根节点 root 和一个值 key，删除二叉搜索树中的 key 对应的节点，
// 并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的根节点的引用。
public class LeetCode_0450
{
    public static void Test()
    {
        LeetCode_0450 obj = new LeetCode_0450();
        var tree = Tools.ConstructTree("5,3,6,2,4,null,7");
        var node = obj.DeleteNode(tree, 5);
        Tools.SequenceTraversalTree(node);
    }

    public TreeNode DeleteNode2(TreeNode root, int key)
    {
        if (root == null) return null;
        TreeNode virtualRoot = new TreeNode(-1000001);
        virtualRoot.right = root;
        TreeNode target = virtualRoot;
        TreeNode pre = null;
        // 先找到节点
        while (target != null)
        {
            if (target.val > key)
            {
                pre = target;
                target = target.left;
            }
            else if (target.val < key)
            {
                pre = target;
                target = target.right;
            }
            else
                break;
        }
        // 没找到原样返回
        if (target == null) return virtualRoot.right;
        
        if (target.left != null && target.right != null)
        {
            // 寻找右子树最左节点
            TreeNode left = target.right;
            TreeNode pre2 = target.right;
            while (left.left != null)
            {
                pre2 = left;
                left = left.left;
            }
            target.val = left.val;
            // 如果最左节点就是它自己,把右树接到target右树上
            if (target.right == left)
            {
                target.right = left.right;
            }
            // 否则把最左节点的值复制到target,并删除最左节点
            else
            {
                pre2.left = left.right;
            }
        }
        else if (target.left != null)
        {
            if (pre.left == target)
                pre.left = target.left;
            else if (pre.right == target)
                pre.right = target.left;
        }
        else if (target.right != null)
        {
            if (pre.left == target)
                pre.left = target.right;
            else if (pre.right == target)
                pre.right = target.right;
        }
        else
        {
            if (pre.left == target)
                pre.left = null;
            else if (pre.right == target)
                pre.right = null;
        }

        return virtualRoot.right;
    }

    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null) return root;
        if (root.val > key)
            root.left = DeleteNode(root.left, key);
        else if (root.val < key)
            root.right = DeleteNode(root.right, key);
        else
        {
            if (root.left == null && root.right == null)
                return null;
            if (root.left == null)
                return root.right;
            if (root.right == null)
                return root.left;
            TreeNode node = root.right;
            while (node.left != null)
            {
                node = node.left;
            }

            node.left = root.left;
            return root.right;  
        }

        return root;
    }
}