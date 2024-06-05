using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_06
{
    public static void Test()
    {
        LeetCode_04_06 obj = new LeetCode_04_06();
    }
    
    public TreeNode InorderSuccessor1(TreeNode root, TreeNode p)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;
        bool flag = false;
        while (cur != null || stack.Count > 0)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                var node = stack.Pop();
                if (flag) return node;
                if (node == p) flag = true;
                cur = node.right;
                
            }
        }
        return null;
    }

    public TreeNode InorderSuccessor2(TreeNode root, TreeNode p)
    {
        TreeNode pre = null;
        if (p.right != null)
        {
            pre = p.right;
            while (pre.left != null)
            {
                pre = pre.left;
            }

            return pre;
        }

        TreeNode cur = root;
        while (cur != null)
        {
            if (cur.val > p.val)
            {
                pre = cur;
                cur = cur.left;
            }
            else
            {
                cur = cur.right;
            }
        }

        return pre;
    }
}