using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR046
{
    public static void Test()
    {
        LeetCode_LCR046 obj = new LeetCode_LCR046();
    }
    
    public IList<int> RightSideView(TreeNode root)
    {
        IList<int> res = new List<int>();
        if (root == null) return res;
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            res.Add(queue.Peek().val);
            var count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var treeNode = queue.Dequeue();
                if(treeNode.right != null)
                    queue.Enqueue(treeNode.right);
                if(treeNode.left != null)
                    queue.Enqueue(treeNode.left);
            }
        }

        return res;
    }
}