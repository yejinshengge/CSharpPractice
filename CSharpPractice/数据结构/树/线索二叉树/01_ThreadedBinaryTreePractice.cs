namespace CSharpPractice.数据结构.树.线索二叉树;

public class ThreadedBinaryTreePractice
{
    public static void ThreadedBinaryTreeMain()
    {
        ThreadedBinaryTree<int> tree = new ThreadedBinaryTree<int>(1);
        tree.Left = new ThreadedBinaryTreeNode<int>(2);
        tree.Right = new ThreadedBinaryTreeNode<int>(3);
        tree.Left.Left = new ThreadedBinaryTreeNode<int>(4);
        tree.Left.Right = new ThreadedBinaryTreeNode<int>(5);
        tree.Left.Right.Left = new ThreadedBinaryTreeNode<int>(6);
        tree.Left.Right.Right = new ThreadedBinaryTreeNode<int>(7);
        tree.InThreading();
        Console.WriteLine(tree.GetPre(tree.Head)?.Data);
        tree.Traverse();
    }
}

public class ThreadedBinaryTree<T> {
    public ThreadedBinaryTreeNode<T> Head { get; }
    public ThreadedBinaryTreeNode<T> Left
    {
        get => Head.Left;
        set => Head.Left = value;
    }
    public ThreadedBinaryTreeNode<T> Right
    {
        get => Head.Right;
        set => Head.Right = value;
    }
    
    public ThreadedBinaryTree(T e)
    {
        Head = new ThreadedBinaryTreeNode<T>(e);
    }

    public void InThreading()
    {
        InThreadingMethod(Head);
        // 处理遍历的最后一个节点
        if (_pre != null) _pre.RightTag = true;
    }

    private ThreadedBinaryTreeNode<T>? _pre;
    private void InThreadingMethod(ThreadedBinaryTreeNode<T>? head)
    {
        if(head == null) return;
        InThreadingMethod(head.Left);
        // 前驱线索
        if (head.Left == null)
        {
            head.Left = _pre;
            head.LeftTag = true;
        }
        // 后继线索
        if (_pre != null && _pre.Right == null)
        {
            _pre.Right = head;
            _pre.RightTag = true;
        }
        _pre = head;
        InThreadingMethod(head.Right);
    }

    public ThreadedBinaryTreeNode<T>? GetNext(ThreadedBinaryTreeNode<T> node)
    {
        // 有后继指针,直接返回
        if (node.RightTag) return node.Right;
        // 否则返回右子树按中序遍历的第一个节点
        var root = node.Right;
        while (root != null && !root.LeftTag)
        {
            root = root.Left;
        }
        return root;
    }
    
    public ThreadedBinaryTreeNode<T>? GetPre(ThreadedBinaryTreeNode<T> node)
    {
        // 有前驱指针,直接返回
        if (node.LeftTag) return node.Left;
        // 否则返回左子树按中序遍历的最后一个节点
        var root = node.Left;
        while (root != null && !root.RightTag)
        {
            root = root.Right;
        }
        return root;
    }

    public void Traverse()
    {
        // 先找到中序遍历的起始节点
        var cur = Head;
        while (cur != null && !cur.LeftTag)cur = cur.Left;

        // 依次寻找后继节点
        while (cur!=null)
        {
            Console.Write(cur.Data);
            cur = GetNext(cur);
        }
    }
}
public class ThreadedBinaryTreeNode<T>
{
    public T Data;
    public ThreadedBinaryTreeNode<T>? Left;
    public ThreadedBinaryTreeNode<T>? Right;
    public bool LeftTag;
    public bool RightTag;

    public ThreadedBinaryTreeNode(T e)
    {
        Data = e;
    }
}