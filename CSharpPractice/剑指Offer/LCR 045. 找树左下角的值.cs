using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR045
{
    public static void Test()
    {
        LeetCode_LCR045 obj = new LeetCode_LCR045();
    }
    
    public int FindBottomLeftValue(TreeNode root)
    {
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        TreeNode left = null;
        while (queue.Count > 0)
        {
            var count = queue.Count;
            left = queue.Peek();
            for (int i = 0; i < count; i++)
            {
                var treeNode = queue.Dequeue();
                if(treeNode.left != null)
                    queue.Enqueue(treeNode.left);
                if(treeNode.right != null)
                    queue.Enqueue(treeNode.right);
            }
        }

        return left == null ? 0:left.val;
    }
}