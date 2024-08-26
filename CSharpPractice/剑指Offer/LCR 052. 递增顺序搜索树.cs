using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR052
{
    public static void Test()
    {
        LeetCode_LCR052 obj = new LeetCode_LCR052();
        Tools.PreorderTree(obj.IncreasingBST(Tools.ConstructTree("5,3,6,2,4,null,8,1,null,null,null,7,9")));
        Tools.PreorderTree(obj.IncreasingBST(Tools.ConstructTree("2,1,4,null,null,3")));
    }
    
    public TreeNode IncreasingBST(TreeNode root)
    {
        Stack<TreeNode> stack = new();
        TreeNode pre = null;
        TreeNode cur = root;
        TreeNode newHead = null;
        while (cur != null || stack.Count >0)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                cur = stack.Pop();
                if (pre == null)
                    newHead = cur;
                else
                {
                    pre.right = cur;
                }
                pre = cur;
                cur.left = null;
                cur = cur.right;
            }
        }

        return newHead;
    }
}