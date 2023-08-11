using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 给定一个二叉树，找出其最大深度。二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
public class LeetCode_027
{
    public static void Test()
    {
        LeetCode_027 obj = new LeetCode_027();
        TreeNode head = new TreeNode(3);
        head.left = new TreeNode(9);
        head.right = new TreeNode(20);
        head.right.left = new TreeNode(15);
        head.right.right = new TreeNode(7);

        Console.WriteLine(obj.MaxDepth(head));
    }
    // 思路一:递归
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        return Math.Max(MaxDepth(root.left), MaxDepth(root.right))+1;
    }
    
}