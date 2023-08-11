namespace CSharpPractice.Class01;

public class Tree {
    public static void TreeMain()
    {
        Tree obj = new Tree();
        TreeTreeNode root = new TreeTreeNode(7);
        root.Left = new TreeTreeNode(6);
        root.Right = new TreeTreeNode(5);
        root.Right.Left = new TreeTreeNode(2);
        root.Left.Left = new TreeTreeNode(4);
        root.Left.Right = new TreeTreeNode(3);
        root.Left.Right.Left = new TreeTreeNode(8);
        root.Left.Right.Left.Left = new TreeTreeNode(9);

        // obj.TraverseTree(root);
        // obj.LevelOrder1(root);
        // Console.WriteLine(obj.res);
        // obj.TraverseTree(root);
        obj.LevelOrder2En(root);
        Console.WriteLine();
        // obj.Preorder(root);
        // obj.Inorder(root);
        // obj.Postorder(root);
        obj.LevelOrder(root);
    }
    private class TreeTreeNode
    {
        public int Val;
        public TreeTreeNode Left;
        public TreeTreeNode Right;

        public TreeTreeNode(int x)
        {
            Val = x;
        }
    }

    private void TraverseTree(TreeTreeNode? root)
    {
        if(root == null)
            return;
        TraverseTree(root.Left);
        TraverseTree(root.Right);
        Console.Write(root.Val+" ");
    }

    private List<List<int>> res = new();
    private void LevelOrder1(TreeTreeNode? root, int i = 0)
    {
        if(root == null)
            return;
        if(res.Count < i+1)
            res.Add(new List<int>());
        res[i].Add(root.Val);
        LevelOrder1(root.Left,i+1);
        LevelOrder1(root.Right,i+1);
    }

    private void LevelOrder2En(TreeTreeNode? root)
    {
        int height = GetTreeHeight(root);
        for (int i = 0; i < height; i++)
        {
            LevelOrder2(root, i);
        }
    }
    
    private void LevelOrder2(TreeTreeNode? root, int i)
    {
        if(root == null)
            return;
        if(i == 0)
            Console.Write(root.Val+" ");
        LevelOrder2(root.Left,i-1);
        LevelOrder2(root.Right,i-1);
    }

    /// <summary>
    /// 获取树的高度
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    private int GetTreeHeight(TreeTreeNode? root)
    {
        if (root == null)
            return 0;
        return Math.Max(GetTreeHeight(root.Left), GetTreeHeight(root.Right))+1;
    }

    private void Preorder(TreeTreeNode? root)
    {
        if(root == null)
            return;
        var stack = new Stack<TreeTreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            Console.Write(node.Val+" ");
            if(node.Right != null)
                stack.Push(node.Right);
            if(node.Left != null)
                stack.Push(node.Left);
        }
    }

    private void Inorder(TreeTreeNode? root)
    {
        if(root == null)
            return;
        var stack = new Stack<TreeTreeNode>();
        var curNode = root;
        while (stack.Count > 0 || curNode != null)
        {
            // 不为空则入栈,继续寻找左孩子
            if (curNode != null)
            {
                stack.Push(curNode);
                curNode = curNode.Left;
            }
            // 为空则弹出栈顶元素,对右孩子进行上述操作
            else
            {
                curNode = stack.Pop();
                Console.Write(curNode.Val+" ");
                curNode = curNode.Right;
            }
        }
    }

    private void Postorder(TreeTreeNode? root)
    {
        if(root == null)
            return;
        var stackA = new Stack<TreeTreeNode>();
        var stackB = new Stack<TreeTreeNode>();
        stackA.Push(root);
        while (stackA.Count > 0)
        {
            var node = stackA.Pop();
            stackB.Push(node);
            if(node.Left != null)
                stackA.Push(node.Left);
            if(node.Right != null)
                stackA.Push(node.Right);
        }

        while (stackB.Count > 0)
        {
            Console.Write(stackB.Pop().Val+" ");
        }
    }

    private void LevelOrder(TreeTreeNode? root)
    {
        if(root == null)
            return;
        var queue = new Queue<TreeTreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            Console.Write(node.Val+" ");
            if(node.Left != null)
                queue.Enqueue(node.Left);
            if(node.Right != null)
                queue.Enqueue(node.Right);
        }
    }
}