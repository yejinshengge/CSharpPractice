using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;
//给定一个非空二叉树的根节点 root , 以数组的形式返回每一层节点的平均值。与实际答案相差 10-5 以内的答案可以被接受。
public class LeetCode_0637
{
    public static void Test()
    {
        LeetCode_0637 obj = new LeetCode_0637();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        Util.Tools.PrintEnumerator(obj.AverageOfLevels(root));
    }

    public IList<double> AverageOfLevels(TreeNode root) {
        IList<double> res = new List<double>();
        if (root == null) return res;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count>0)
        {
            int count = queue.Count;
            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
                sum += node.val;
            }
            res.Add(sum/count);
        }
        return res;
    }
}