using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR044
{
    public static void Test()
    {
        LeetCode_LCR044 obj = new LeetCode_LCR044();
    }
    
    public IList<int> LargestValues(TreeNode root)
    {
        IList<int> res = new List<int>();
        if (root == null) return res;
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var count = queue.Count;
            int max = int.MinValue;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                max = Math.Max(node.val, max);
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
            }
            res.Add(max);
        }

        return res;
    }
}