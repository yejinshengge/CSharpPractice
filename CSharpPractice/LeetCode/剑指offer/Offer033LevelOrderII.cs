using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer033LevelOrderII
{
    public static void Offer033LevelOrderIIMain()
    {
        Offer033LevelOrderII obj = new();
        TreeNode root = new(3);
        
        root.left = new(9);
        root.right = new(20);
        
        root.left.left = new(25);
        root.left.right = new(30);
        root.right.left = new(15);
        root.right.right = new(7);
        
        root.right.right.left = new(45);
        root.right.right.right = new(50);
        //var levelOrder = obj.LevelOrder(root);
        var levelOrder = obj.LevelOrder2(root);
        Console.WriteLine(levelOrder);
    }

    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
            return new List<IList<int>>();
        var list = new List<IList<int>>();
        var queue = new Queue<TreeNode>();
        int preCount = 1;
        int curCount = 0;
        int num = 0;
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            if (preCount == 0)
            {
                preCount = curCount;
                curCount = 0;
                num++;
            }
            if (list.Count < num+1)
            {
                list.Add(new List<int>());
            }
            var treeNode = queue.Dequeue();
            list[num].Add(treeNode.val);
            preCount--;
            if (treeNode.left != null)
            {
                queue.Enqueue(treeNode.left);
                curCount++;
            }

            if (treeNode.right != null)
            {
                queue.Enqueue(treeNode.right);
                curCount++;
            }
        }
        return list;
    }
    
    public IList<IList<int>> LevelOrder2(TreeNode root){
        if (root == null)
            return new List<IList<int>>();
        var list = new List<IList<int>>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count>0)
        {
            List<int> tmp = new List<int>();
            for (int i = queue.Count; i > 0; i--)
            {
                var treeNode = queue.Dequeue();
                tmp.Add(treeNode.val);
                if (treeNode.left != null)
                {
                    queue.Enqueue(treeNode.left);
                }
                if (treeNode.right != null)
                {
                    queue.Enqueue(treeNode.right);
                }
            }
            list.Add(tmp);
        }
        return list;
    }
}