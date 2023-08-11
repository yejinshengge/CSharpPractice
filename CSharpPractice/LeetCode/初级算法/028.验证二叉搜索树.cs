using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;


/**
 * 给你一个二叉树的根节点 root ，判断其是否是一个有效的二叉搜索树。
 * 有效 二叉搜索树定义如下：
节点的左子树只包含 小于 当前节点的数。
节点的右子树只包含 大于 当前节点的数。
所有左子树和右子树自身必须也是二叉搜索树。
 */
public class LeetCode_028
{
    public static void Test()
    {
        LeetCode_028 obj = new LeetCode_028();
        TreeNode head = new TreeNode(5);
        head.left = new TreeNode(1);
        head.right = new TreeNode(7);
        head.right.left = new TreeNode(6);
        head.right.right = new TreeNode(8);
        
        Console.WriteLine(obj.IsValidBST2(head));
    }

    // 思路一:中序遍历,判断数组是否升序
    public bool IsValidBST(TreeNode root)
    {
        List<int> valList = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;
        
        while (stack.Count > 0 || cur != null)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                cur = stack.Pop();
                valList.Add(cur.val);
                cur = cur.right;
            }
            
        }

        long num = (long)int.MinValue-1;
        for (int i = 0; i < valList.Count; i++)
        {
            if (num < valList[i])
                num = valList[i];
            else
                return false;
        }

        return true;
    }

    // 思路二:递归,需要添加范围限制
    public bool IsValidBST2(TreeNode root)
    {
        return Process(root, long.MinValue, long.MaxValue);
    }

    private bool Process(TreeNode root, long min, long max)
    {
        if (root == null) return true;
        if (root.val <= min || root.val >= max)
            return false;
        return Process(root.left, min, root.val) && Process(root.right, root.val, max);
    }
}