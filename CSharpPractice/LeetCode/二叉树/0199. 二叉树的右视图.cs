using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;
// 给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
public class LeetCode_0199
{
    public static void Test()
    {
        LeetCode_0199 obj = new LeetCode_0199();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        Util.Tools.PrintEnumerator(obj.RightSideView(root));
    }

    public IList<int> RightSideView(TreeNode root) {
        IList<int> res = new List<int>();
        if (root == null) return res;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count>0)
        {
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
                if(i == count-1)
                    res.Add(node.val);
            }
        }
        return res;
    }
}