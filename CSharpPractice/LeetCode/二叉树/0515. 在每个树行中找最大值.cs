using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0515
{
    public static void Test()
    {
        LeetCode_0515 obj = new LeetCode_0515();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(3);
        root.right = new TreeNode(2);
        root.left.left = new TreeNode(5);
        root.left.right = new TreeNode(3);
        root.right.right = new TreeNode(9);
        
        Util.Tools.PrintEnumerator(obj.LargestValues(root));
    }

    public IList<int> LargestValues(TreeNode root) {
        IList<int> res = new List<int>();
        if (root == null) return res;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count>0)
        {
            int count = queue.Count;
            int max = int.MinValue;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
                max = Math.Max(max, node.val);
            }
            res.Add(max);
        }
        return res;
    }
}