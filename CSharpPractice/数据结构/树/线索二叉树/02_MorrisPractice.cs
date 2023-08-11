namespace CSharpPractice.数据结构.树.线索二叉树;

public class MorrisPractice {

    public static void MorrisPracticeMain()
    {
        MorrisPractice obj = new MorrisPractice();
        MorrisTreeNode<int> head = new MorrisTreeNode<int>(1);
        head.Left = new MorrisTreeNode<int>(2);
        head.Right = new MorrisTreeNode<int>(3);
        head.Left.Left = new MorrisTreeNode<int>(4);
        head.Left.Right = new MorrisTreeNode<int>(5);
        
        obj.Morris_Preorder(head);
        Console.WriteLine("");
        obj.Morris_Inorder(head);
        Console.WriteLine("");
        obj.Morris_Postorder(head);
    }
    
    // 寻找左子树最右节点
    private MorrisTreeNode<T> FindMostRightParentInLeftTree<T>(MorrisTreeNode<T> head)
    {
        if (head?.Left == null) throw new NullReferenceException();
        MorrisTreeNode<T> cur = head.Left;

        while (cur != null && cur.Right != null && cur.Right != head)
        {
            cur = cur.Right;
        }
        return cur;
    }
    
    /// <summary>
    /// Morris前序遍历
    /// </summary>
    /// <param name="head"></param>
    /// <typeparam name="T"></typeparam>
    public void Morris_Preorder<T>(MorrisTreeNode<T> head)
    {
        MorrisTreeNode<T>? cur = head;
        while (cur != null)
        {
            // 如果cur有左孩子
            if (cur.Left != null)
            {
                // 寻找左子树最右节点的父节点
                MorrisTreeNode<T> rightParent = FindMostRightParentInLeftTree(cur);
                // 如果最右节点为空,则右指针指向cur,cur左移
                if (rightParent.Right == null)
                {
                    Console.Write(cur.Data+" ");
                    rightParent.Right = cur;
                    cur = cur.Left;
                }
                // 如果最右节点为cur,则右指针指向空,cur右移
                else if (rightParent.Right == cur)
                {
                    rightParent.Right = null;
                    cur = cur.Right;
                }
            }
            // cur没有左孩子,右移
            else
            {
                Console.Write(cur.Data+" ");
                cur = cur.Right;
            }
        }
    }
    
    /// <summary>
    /// Morris中序遍历
    /// </summary>
    /// <param name="head"></param>
    /// <typeparam name="T"></typeparam>
    public void Morris_Inorder<T>(MorrisTreeNode<T> head)
    {
        MorrisTreeNode<T>? cur = head;
        while (cur != null)
        {
            // 如果cur有左孩子
            if (cur.Left != null)
            {
                // 寻找左子树最右节点的父节点
                MorrisTreeNode<T> rightParent = FindMostRightParentInLeftTree(cur);
                // 如果最右节点为空,则右指针指向cur,cur左移
                if (rightParent.Right == null)
                {
                    rightParent.Right = cur;
                    cur = cur.Left;
                }
                // 如果最右节点为cur,则右指针指向空,cur右移
                else if (rightParent.Right == cur)
                {
                    Console.Write(cur.Data+" ");
                    rightParent.Right = null;
                    cur = cur.Right;
                }
            }
            // cur没有左孩子,右移
            else
            {
                Console.Write(cur.Data+" ");
                cur = cur.Right;
            }
        }
    }
    
    /// <summary>
    /// Morris后序遍历
    /// </summary>
    /// <param name="head"></param>
    /// <typeparam name="T"></typeparam>
    public void Morris_Postorder<T>(MorrisTreeNode<T> head)
    {
        MorrisTreeNode<T>? cur = head;
        while (cur != null)
        {
            // 如果cur有左孩子
            if (cur.Left != null)
            {
                // 寻找左子树最右节点的父节点
                MorrisTreeNode<T> rightParent = FindMostRightParentInLeftTree(cur);
                // 如果最右节点为空,则右指针指向cur,cur左移
                if (rightParent.Right == null)
                {
                    rightParent.Right = cur;
                    cur = cur.Left;
                }
                // 如果最右节点为cur,则右指针指向空,cur右移
                else if (rightParent.Right == cur)
                {
                    rightParent.Right = null;
                    // 逆序打印左树右边界
                    ReversePrintRightBorder(cur.Left);
                    cur = cur.Right;
                }
            }
            // cur没有左孩子,右移
            else
            {
                cur = cur.Right;
            }
        }
        // 逆序打印头结点的右边界
        ReversePrintRightBorder(head);
    }

    // 逆序打印右边界
    private void ReversePrintRightBorder<T>(MorrisTreeNode<T> head)
    {
        // 反转右边界
        var tail = ReverseRightBorder(head);
        MorrisTreeNode<T> cur = tail;
        // 遍历
        while (cur != null)
        {
            Console.Write(cur.Data+" ");
            cur = cur.Right;
        }
        // 再反转回来
        ReverseRightBorder(tail);
    }

    // 逆序右边界
    private MorrisTreeNode<T> ReverseRightBorder<T>(MorrisTreeNode<T> head)
    {
        MorrisTreeNode<T>? pre = null;
        while (head != null)
        {
            MorrisTreeNode<T>? next = head.Right;
            head.Right = pre;
            pre = head;
            head = next;
        }

        return pre;
    }
}

public class MorrisTreeNode<T>
{
    public T Data;
    public MorrisTreeNode<T>? Left;
    public MorrisTreeNode<T>? Right;

    public MorrisTreeNode(T e)
    {
        Data = e;
    }
}

