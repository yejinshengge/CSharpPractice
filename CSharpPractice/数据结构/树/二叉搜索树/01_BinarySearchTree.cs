namespace CSharpPractice.数据结构.树.二叉搜索树;

public class BinarySearchTreeTest
{
    public static void BinarySearchTreeTestMain()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        int[] a={62,88,58,47,35,73,51,99,37,93};
        for (int i = 0; i < a.Length; i++)
        {
            tree.Insert(a[i]);
        }
        tree.Delete(47);
        Console.WriteLine(tree);
    }
}

public class BinarySearchTree<T> where T:IComparable<T>
{
    protected class Node
    {
        public T Data;
        public Node? Left;
        public Node? Right;
        public Node? Parent;
        // 平衡因子
        public int BalanceFactor;
        
        public Node(T data)
        {
            Data = data;
        }
    }

    protected Node? Head;
    
    /// <summary>
    /// 查找元素
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool Search(T target)
    {
        var node = Search(target, Head,out _);
        return node == null;
    }

    /// <summary>
    /// 查找节点
    /// </summary>
    /// <param name="target"></param>
    /// <param name="node"></param>
    /// <param name="preNode">返回前驱节点</param>
    /// <param name="pre"></param>
    protected Node? Search(T target, Node? node, out Node? preNode, Node? pre = null)
    {
        preNode = pre;
        if (node == null) return null;
        if (node.Data.Equals(target))
        {
            preNode = node.Parent;
            return node;
        }
        // 当前节点小于目标值,查询右子树
        if (node.Data.CompareTo(target) < 0)
            return Search(target, node.Right,out preNode,node);
        // 当前节点大于目标值,查询左子树
        return Search(target, node.Left,out preNode,node);
    }

    /// <summary>
    /// 插入元素
    /// </summary>
    /// <param name="data"></param>
    public virtual void Insert(T data)
    {
        OnInsert(data);
    }

    protected Node? OnInsert(T data)
    {
        var node = Search(data, Head,out Node? parent);
        if(node != null) return null;

        Node newNode = new Node(data);
        newNode.Parent = parent;
        // parent为空,说明根节点为空
        if (parent == null)
            Head = newNode;
        // 新节点比parent大,作为右孩子
        else if (data.CompareTo(parent.Data) > 0)
            parent.Right = newNode;
        // 新节点比parent小,作为左孩子
        else
            parent.Left = newNode;
        return newNode;
    }
    
    /// <summary>
    /// 删除元素
    /// </summary>
    /// <param name="data"></param>
    public virtual void Delete(T data)
    {
        OnDelete(data);
    }

    protected Node? OnDelete(T data)
    {
        var node = Search(data, Head,out Node? parent);
        if(node == null) return null;
        
        // 当前节点没有左子树
        if (node.Left == null)
        {
            // 删除的是根节点
            if (parent == null)
                Head = node.Right;
            // 删除节点是父节点的左孩子
            else if (parent.Left == node)
                parent.Left = node.Right;
            // 删除节点是父节点的右孩子
            else
                parent.Right = node.Right;
            // 设置父节点
            if (node.Right != null) node.Right.Parent = parent;
        }
        // 当前节点没有右子树
        else if (node.Right == null)
        {
            // 删除的是根节点
            if (parent == null)
                Head = node.Left;
            // 删除节点是父节点的左孩子
            else if (parent.Left == node)
                parent.Left = node.Left;
            // 删除节点是父节点的右孩子
            else
                parent.Right = node.Left;
            // 设置父节点
            if (node.Left != null) node.Left.Parent = parent;
        }
        // 当前节点既有左子树,又有右子树
        else
        {
            // 先找到左子树的最右节点
            var curNode = node.Left;
            var curParent = node;
            while (curNode.Right != null)
            {
                curParent = curNode;
                curNode = curNode.Right;
            }
            // 将最右节点替换到删除节点的位置
            node.Data = curNode.Data;
            // 如果最右节点就是删除节点的左孩子,则把左子树接到左侧
            if (curNode == node.Left)
                curParent.Left = curNode.Left;
            // 否则把左子树接到右侧
            else
                curParent.Right = curNode.Left;
            // 设置父节点
            if (curNode.Left != null) curNode.Left.Parent = curParent;
        }
        return node;
    }
    /// <summary>
    /// 左旋
    /// </summary>
    /// <param name="root"></param>
    protected void LeftRotate(Node root)
    {
        var newRoot = root.Right;
        if(newRoot == null) return;
        
        var parent = root.Parent;
        // newRoot的左子树挂在root的右子树上
        root.Right = newRoot.Left;
        if (newRoot.Left != null) newRoot.Left.Parent = root.Right;
        // root挂在newRoot左子树上
        newRoot.Left = root;
        root.Parent = newRoot;
        // 如果父节点为空,说明root是根节点
        if (parent == null)
            Head = newRoot;
        // 否则更新parent的孩子
        else if (parent.Left == root)
            parent.Left = newRoot;
        else if (parent.Right == root)
            parent.Right = newRoot;
        newRoot.Parent = parent;
    }

    /// <summary>
    /// 右旋
    /// </summary>
    /// <param name="root"></param>
    protected void RightRotate(Node root)
    {
        var newRoot = root.Left;
        if(newRoot == null) return;
        
        var parent = root.Parent;
        // newRoot的右子树挂在root的左子树上
        root.Left = newRoot.Right;
        if (newRoot.Right != null) newRoot.Right.Parent = root.Left;
        // root挂在newRoot右子树上
        newRoot.Right = root;
        root.Parent = newRoot;
        // 如果父节点为空,说明root是根节点
        if (parent == null)
            Head = newRoot;
        // 否则更新parent的孩子
        else if (parent.Left == root)
            parent.Left = newRoot;
        else if (parent.Right == root)
            parent.Right = newRoot;
        newRoot.Parent = parent;
    }
}