using System.Collections;
using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR053
{
    public static void Test()
    {
        LeetCode_LCR053 obj = new LeetCode_LCR053();
        
    }
    
    public TreeNode InorderSuccessor1(TreeNode root, TreeNode p)
    {
        Stack<TreeNode> stack = new();
        TreeNode cur = root;
        TreeNode pre = null;

        while (cur != null || stack.Count > 0)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                cur = stack.Pop();
                if (pre == p)
                    return cur;
                pre = cur;
                cur = cur.right;
            }
        }

        return null;
    }

    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        TreeNode cur = root;
        TreeNode res = null;
        while (cur != null)
        {
            if (cur.val <= p.val)
                cur = cur.right;
            else
            {
                res = cur;
                cur = cur.left;
            }
        }

        return res;
    }
}