using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR054
{
    public static void Test()
    {
        LeetCode_LCR054 obj = new LeetCode_LCR054();
        Tools.SequenceTraversalTree(obj.ConvertBST(Tools.ConstructTree("4,1,6,0,2,5,7,null,null,null,3,null,null,null,8")));
    }
    
    public TreeNode ConvertBST(TreeNode root)
    {
        Stack<TreeNode> stack = new();
        TreeNode cur = root;
        int prefixSum = 0;
        while (stack.Count > 0 || cur != null)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.right;
            }
            else
            {
                cur = stack.Pop();
                prefixSum += cur.val;
                cur.val = prefixSum;
                cur = cur.left;
            }
        }

        return root;
    }
}