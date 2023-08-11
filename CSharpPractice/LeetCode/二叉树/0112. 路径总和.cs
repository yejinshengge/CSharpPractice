using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0112
{
    public static void Test()
    {
        LeetCode_0112 obj = new LeetCode_0112();
        var tree = Tools.ConstructTree("5,4,8,11,null,13,4,7,2,null,null,null,1");
        Console.WriteLine(obj.HasPathSum(tree,22));
    }

    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null) return false;
        if (root.left == null && root.right == null 
                              && targetSum == root.val) return true;
        return HasPathSum(root.left, targetSum-root.val) 
               || HasPathSum(root.right, targetSum-root.val);
        
    }
}