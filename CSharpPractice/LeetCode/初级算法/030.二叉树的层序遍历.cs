using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 给你二叉树的根节点 root ，返回其节点值的 层序遍历 。 （即逐层地，从左到右访问所有节点）。
public class LeetCode_030
{
    public static void Test()
    {
        LeetCode_030 obj = new LeetCode_030();
        TreeNode head = new TreeNode(1);
        head.left = new TreeNode(2);
        head.right = new TreeNode(3);
        head.right.left = new TreeNode(4);
        head.right.right = new TreeNode(5);
        head.left.left = new TreeNode(6);
        head.left.right = new TreeNode(7);

        var res = obj.LevelOrder2(head);
        
        Console.WriteLine(res);
    }
    
    // 思路一:队列
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null) return res;
        
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            List<int> temp = new List<int>();
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                temp.Add(node.val);
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
            }
            res.Add(temp);
        }

        return res;
    }

    // 思路二:深度优先
    public IList<IList<int>> LevelOrder2(TreeNode root)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Process(res,0,root);
        return res;
    }

    private void Process(IList<IList<int>> list, int level,TreeNode root)
    {
        if(root == null) return;
        
        if(level >= list.Count)
            list.Add(new List<int>());
        list[level].Add(root.val);
        Process(list,level+1,root.left);
        Process(list,level+1,root.right);
    }

}