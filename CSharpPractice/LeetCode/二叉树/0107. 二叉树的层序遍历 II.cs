using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

// 给你二叉树的根节点 root ，返回其节点值 自底向上的层序遍历 。
// （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）
public class LeetCode_0107
{
    public static void Test()
    {
        LeetCode_0107 obj = new LeetCode_0107();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);
        
        Util.Tools.PrintEnumerator(obj.LevelOrderBottom(root));
    }

    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null) return res;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count>0)
        {
            res.Add(new List<int>());
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
                res[^1].Add(node.val);
            }
        }
        
        return res.Reverse().ToList();
    }
}