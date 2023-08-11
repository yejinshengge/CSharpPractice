using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer034LevelOrderIII
{
    public static void Offer034LevelOrderIIIMain()
    {
        Offer034LevelOrderIII obj = new();
        TreeNode root = new(3);
        
        root.left = new(9);
        root.right = new(20);
        
        root.left.left = new(25);
        root.left.right = new(30);
        root.right.left = new(15);
        root.right.right = new(7);
        
        root.right.right.left = new(45);
        root.right.right.right = new(50);
        var levelOrder = obj.LevelOrder2(root);
        Console.WriteLine(levelOrder);
    }

    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
            return new List<IList<int>>();
        var list = new List<IList<int>>();
        var queue = new Queue<TreeNode>();
        var stack = new Stack<TreeNode>();
        bool isLeftToRight = true;
        
        queue.Enqueue(root);
        while (queue.Count>0)
        {
            List<int> tmp = new List<int>();
            // 将队列的元素排入栈中
            for (int i = queue.Count; i > 0; i--)
            {
                var treeNode = queue.Dequeue();
                stack.Push(treeNode);
                tmp.Add(treeNode.val);
            }
            // 将栈内的元素弹出
            while (stack.Count > 0)
            {
                var treeNode = stack.Pop();
                // 如果当前行是从左到右,则下一行从右到左入队
                if (isLeftToRight)
                {
                    FromRightToLeft(treeNode,queue);
                }
                // 反之从左到右入队
                else
                {
                    FromLeftToRight(treeNode,queue);
                }
            }
            // 反转标志位
            isLeftToRight = !isLeftToRight;
            list.Add(tmp);
        }
        return list;
    }

    private void FromLeftToRight(TreeNode treeNode,Queue<TreeNode> queue)
    {
        if (treeNode.left != null)
        {
            queue.Enqueue(treeNode.left);
        }
        if (treeNode.right != null)
        {
            queue.Enqueue(treeNode.right);
        }
    }
    
    private void FromRightToLeft(TreeNode treeNode,Queue<TreeNode> queue)
    {
        if (treeNode.right != null)
        {
            queue.Enqueue(treeNode.right);
        }
        if (treeNode.left != null)
        {
            queue.Enqueue(treeNode.left);
        }
    }

    public IList<IList<int>> LevelOrder2(TreeNode root)
    {
        if (root == null)
            return new List<IList<int>>();
        var list = new List<IList<int>>();
        var queue = new Queue<TreeNode>();
        bool isLeftToRight = true;
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

            if (!isLeftToRight)
            {
                tmp.Reverse();
            }
            isLeftToRight = !isLeftToRight;
            list.Add(tmp);
        }
        return list;
    }
}