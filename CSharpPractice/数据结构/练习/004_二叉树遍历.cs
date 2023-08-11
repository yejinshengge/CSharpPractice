namespace CSharpPractice.数据结构.练习;

public class BinaryTreeTraversal {
    
    private class BinaryTreeTraversalTreeNode
    {
        public int Value;
        public BinaryTreeTraversalTreeNode Left;
        public BinaryTreeTraversalTreeNode Right;

        public BinaryTreeTraversalTreeNode(int value)
        {
            Value = value;
        }
    }

    public static void Test()
    {
        BinaryTreeTraversalTreeNode head = new BinaryTreeTraversalTreeNode(1);
        head.Left = new BinaryTreeTraversalTreeNode(2);
        head.Right = new BinaryTreeTraversalTreeNode(3);
        head.Left.Left = new BinaryTreeTraversalTreeNode(4);
        head.Left.Right = new BinaryTreeTraversalTreeNode(5);
        head.Right.Left = new BinaryTreeTraversalTreeNode(6);
        head.Right.Right = new BinaryTreeTraversalTreeNode(7);

        // LevelTraversal(head);
        // Preorder(head);
        // Inorder(head);
        // Postorder(head);
        LevelOrder(head);
    }
    
    /// <summary>
    /// 层序遍历递归实现
    /// </summary>
    private static List<List<int>> _res = new();
    private static void LevelTraversal(BinaryTreeTraversalTreeNode head)
    {
        _res.Clear();
        LevelTraversalProcess(head, 0);

        for (int i = 0; i < _res.Count; i++)
        {
            for (int j = 0; j < _res[i].Count; j++)
            {
                Console.Write(_res[i][j]+" ");
            }
            Console.WriteLine("");
        }
    }

    private static void LevelTraversalProcess(BinaryTreeTraversalTreeNode? root,int index)
    {
        if(root == null) return;
        if(_res.Count != index+1)
            _res.Add(new List<int>());
        _res[index].Add(root.Value);
        LevelTraversalProcess(root.Left,index+1);
        LevelTraversalProcess(root.Right,index+1);
    }

    /// <summary>
    /// 前序遍历
    /// </summary>
    /// <param name="root"></param>
    private static void Preorder(BinaryTreeTraversalTreeNode root)
    {
        Stack<BinaryTreeTraversalTreeNode> stack = new Stack<BinaryTreeTraversalTreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            Console.Write(node.Value+" ");
            if(node.Right != null)
                stack.Push(node.Right);
            if(node.Left != null)
                stack.Push(node.Left);
        }
    }

    /// <summary>
    /// 中序遍历
    /// </summary>
    /// <param name="root"></param>
    private static void Inorder(BinaryTreeTraversalTreeNode root)
    {
        Stack<BinaryTreeTraversalTreeNode> stack = new Stack<BinaryTreeTraversalTreeNode>();

        BinaryTreeTraversalTreeNode cur = root;
        while (stack.Count > 0 || cur != null)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.Left;
            }
            else
            {
                cur = stack.Pop();
                Console.Write(cur.Value+" ");
                cur = cur.Right;
            }
        }
    }

    private static void Postorder(BinaryTreeTraversalTreeNode root)
    {
        Stack<BinaryTreeTraversalTreeNode> stackA = new Stack<BinaryTreeTraversalTreeNode>();
        Stack<BinaryTreeTraversalTreeNode> stackB = new Stack<BinaryTreeTraversalTreeNode>();
        stackA.Push(root);

        while (stackA.Count>0)
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
            Console.Write(stackB.Pop().Value+" ");
        }
        
    }

    private static void LevelOrder(BinaryTreeTraversalTreeNode root)
    {
        Queue<BinaryTreeTraversalTreeNode> queue = new Queue<BinaryTreeTraversalTreeNode>();
        queue.Enqueue(root);

        while (queue.Count>0)
        {
            var node = queue.Dequeue();
            Console.Write(node.Value+" ");
            if(node.Left != null)
                queue.Enqueue(node.Left);
            if(node.Right != null)
                queue.Enqueue(node.Right);
        }
    }
}