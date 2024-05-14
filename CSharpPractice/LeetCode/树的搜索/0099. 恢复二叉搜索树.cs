using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.树的搜索;

public class LeetCode_0099
{
    public static void Test()
    {
        LeetCode_0099 obj = new LeetCode_0099();
        var tree1 = Tools.ConstructTree("1,3,null,null,2");
        obj.RecoverTree(tree1);
        Tools.InorderTree(tree1);
        Console.WriteLine();
        var tree2 = Tools.ConstructTree("3,1,4,null,null,2");
        obj.RecoverTree(tree2);
        Tools.InorderTree(tree2);
    }

    #region 栈实现

    public void RecoverTree1(TreeNode root)
    {
        Stack<TreeNode> queue = new Stack<TreeNode>();
        TreeNode last = null, first = null, second = null;
        while (root != null || queue.Count > 0)
        {
            while (root != null)
            {
                queue.Push(root);
                root = root.left;
            }
            root = queue.Pop();
            if (last != null && last.val > root.val)
            {
                if (first == null)
                {
                    first = last;
                    second = root;
                }
                else
                {
                    second = root;
                }
            }
            last = root;
            root = root.right;
        }

        (first.val, second.val) = (second.val, first.val);
    }
    

    #endregion

    public void RecoverTree(TreeNode root)
    {
        TreeNode last = null, first = null, second = null;
        while (root != null)
        {
            // 没有左孩子，移动到右孩子
            if (root.left == null)
            {
                if (last != null && last.val > root.val)
                {
                    if (first == null)
                        first = last;
                    second = root;
                }
                last = root;
                root = root.right;
            }
            // 有左孩子，处理前驱节点
            else
            {
                // 找到左子树最右节点
                TreeNode pre = root.left;
                while (pre.right != null && pre.right != root)
                {
                    pre = pre.right;
                }
                // 设置线索
                if (pre.right == null)
                {
                    pre.right = root;
                    root = root.left;
                }
                // 回收线索
                else
                {
                    pre.right = null;
                    if (last != null && last.val > root.val)
                    {
                        if (first == null)
                            first = last;
                        second = root;
                    }
                    last = root;
                    root = root.right;
                }
            }
        }
        (first.val, second.val) = (second.val, first.val);
    }
}