namespace CSharpPractice.数据结构.树.二叉搜索树;

public class AvlTreePractice
{
    public static void AvlTreePracticeMain()
    {
        AvlTree<int> tree = new AvlTree<int>();

        int[] a = {3, 2, 1, 4, 5, 6, 7, 10, 9, 8};
        for (int i = 0; i < a.Length; i++)
        {
            tree.Insert(a[i]);
        }
        tree.Delete(6);
        Console.WriteLine(tree);
    }
}

public class AvlTree<T>:BinarySearchTree<T> where T:IComparable<T>
{
    public override void Insert(T data)
    {
        // 插入好的节点
        var node = OnInsert(data);
        if(node == null) return;
        Balance(node, true);
    }

    public override void Delete(T data)
    {
        var node = OnDelete(data);
        if(node == null) return;
        Balance(node, false);
        
    }
    /// <summary>
    /// 平衡性调整
    /// </summary>
    /// <param name="node"></param>
    /// <param name="isInsert"></param>
    private void Balance(Node node,bool isInsert)
    {
        var parent = node.Parent;

        while (parent != null)
        {
            // 作为左孩子插入,平衡因子加一
            // 作为左孩子删除,平衡因子减一
            if (parent.Left == node)
                parent.BalanceFactor += isInsert?1:-1;
            // 作为右孩子插入,平衡因子减一
            // 作为右孩子删除,平衡因子加一
            else
                parent.BalanceFactor += isInsert?-1:1;

            // 如果是平衡状态,无需调整
            if(parent.BalanceFactor == 0) return;
            // 如果平衡因子为-1或1,需要回溯
            if (Math.Abs(parent.BalanceFactor) == 1)
            {
                node = parent;
                parent = parent.Parent;
            }
            // 如果平衡因子为-2或2,需要重新平衡
            else if (parent.BalanceFactor == 2)
            {
                LeftBalance(parent);
                break;
            }
            else if(parent.BalanceFactor == -2)
            {
                RightBalance(parent);
                break;
            }
        }
    }
    
    /// <summary>
    /// 左平衡处理
    /// </summary>
    /// <param name="root"></param>
    private void LeftBalance(Node root)
    {
        var lNode = root.Left;
        if(lNode == null) return;
        // 左孩子平衡因子为1,只需要右旋(LL)
        if (lNode.BalanceFactor == 1)
        {
            // 根节点和左孩子平衡因子都归零
            root.BalanceFactor = lNode.BalanceFactor = 0;
            RightRotate(root);
        }
        // 左孩子平衡因子为-1,需要先左旋后右旋(LR)
        else if (lNode.BalanceFactor == -1)
        {
            var lrNode = lNode.Right;
            if(lrNode == null) return;
            switch (lrNode.BalanceFactor)
            {
                // lr平衡因子为0
                case 0:
                    lNode.BalanceFactor = root.BalanceFactor = 0;
                    break;
                // lr平衡因子为-1
                case -1:
                    root.BalanceFactor = 0;
                    lNode.BalanceFactor = 1;
                    break;
                // lr平衡因子为1
                case 1:
                    root.BalanceFactor = -1;
                    lNode.BalanceFactor = 0;
                    break;
            }
            // lr平衡因子一定为0
            lrNode.BalanceFactor = 0;
            // 先左旋后右旋
            LeftRotate(lNode);
            RightRotate(root);
        }
    }
    
    /// <summary>
    /// 右平衡处理
    /// </summary>
    /// <param name="root"></param>
    private void RightBalance(Node root)
    {
        var rNode = root.Right;
        if(rNode == null) return;
        // 右孩子平衡因子为-1,只需要左旋(RR)
        if (rNode.BalanceFactor == -1)
        {
            // 根节点和左孩子平衡因子都归零
            root.BalanceFactor = rNode.BalanceFactor = 0;
            LeftRotate(root);
        }
        // 右孩子平衡因子为1,需要先右旋后左旋(RL)
        else if (rNode.BalanceFactor == 1)
        {
            var rlNode = rNode.Left;
            if(rlNode == null) return;
            switch (rlNode.BalanceFactor)
            {
                // rl平衡因子为0
                case 0:
                    rNode.BalanceFactor = root.BalanceFactor = 0;
                    break;
                // rl平衡因子为-1
                case -1:
                    rNode.BalanceFactor = 0;
                    root.BalanceFactor = 1;
                    break;
                // rl平衡因子为1
                case 1:
                    rNode.BalanceFactor = -1;
                    root.BalanceFactor = 0;
                    break;
            }
            // lr平衡因子一定为0
            rlNode.BalanceFactor = 0;
            // 先右旋后左旋
            RightRotate(rNode);
            LeftRotate(root);
        }
    }
    
}