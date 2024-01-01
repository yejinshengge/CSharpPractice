using System.Collections;
using System.Text;

namespace CSharpPractice.Util;

public static class Tools
{
    /// <summary>
    /// 产生随机数组
    /// </summary>
    /// <param name="length">长度</param>
    /// <param name="min">最小值（包含）</param>
    /// <param name="max">最大值（不包含）</param>
    /// <returns></returns>
    public static int[] RandomArr(int length,int min,int max)
    {
        int[] arr = new int[length];
        Random rd = new Random();
        for (int i = 0; i < length; i++)
        {
            arr[i] = rd.Next(min, max);
        }
        return arr;
    }

    /// <summary>
    /// 打印数组
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static void PrintArr<T>(T[] arr)
    {
        Console.WriteLine();
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();
    }
    /// <summary>
    /// 打印集合
    /// </summary>
    /// <param name="enumerable"></param>
    public static void PrintEnumerator(IEnumerable enumerable)
    {
        foreach (var item in enumerable)
        {
            if(item is IEnumerable)
                PrintEnumerator(item as IEnumerable);
            else
                Console.Write(item+" ");
        }
        Console.WriteLine();
    }
    /// <summary>
    /// 打印二维数组
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static void PrintArr<T>(T[][] arr)
    {
        Console.WriteLine();
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[0].Length; j++)
            {
                Console.Write(arr[i][j]+" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    /// <summary>
    /// 交换元素
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <typeparam name="T"></typeparam>
    public static void Swap<T>(T[] arr, int index1, int index2)
    {
        (arr[index1], arr[index2]) = (arr[index2], arr[index1]);
    }
    
    /// <summary>
    /// 判断两数组是否相同
    /// </summary>
    /// <param name="arr1"></param>
    /// <param name="arr2"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool Equals<T>(T[] arr1, T[] arr2)
    {
        if (arr1.Length != arr2.Length) return false;
        
        for (int i = 0; i < arr1.Length; i++)
        {
            if (!arr1[i].Equals(arr2[i])) return false;
        }
        return true;
    }

    /// <summary>
    /// 通过字符串构建二叉树
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static TreeNode ConstructTree(string str)
    {
        var values = str.Split(",");
        Queue<TreeNode> queue = new Queue<TreeNode>();

        TreeNode root = new TreeNode(int.Parse(values[0]));
        queue.Enqueue(root);
        int index = 1;

        while (index < values.Length)
        {
            var node = queue.Dequeue();
            if (node != null)
            {
                node.left = values[index] == "null" ? null : new TreeNode(int.Parse(values[index]));
                queue.Enqueue(node.left);
                index++;
                if (index < values.Length)
                {
                    node.right = values[index] == "null" ? null : new TreeNode(int.Parse(values[index]));
                    queue.Enqueue(node.right);
                    index++;
                }
            }
        }

        return root;

    }
    /// <summary>
    /// 前序遍历
    /// </summary>
    /// <param name="root"></param>
    public static void PreorderTree(TreeNode root)
    {
        if(root == null) return;
        Console.Write(root.val+" ");
        PreorderTree(root.left);
        PreorderTree(root.right);
    }
    /// <summary>
    /// 中序遍历
    /// </summary>
    /// <param name="root"></param>
    public static void InorderTree(TreeNode root)
    {
        if(root == null) return;
        InorderTree(root.left);
        Console.Write(root.val+" ");
        InorderTree(root.right);
    }
    /// <summary>
    /// 后续遍历
    /// </summary>
    /// <param name="root"></param>
    public static void PostorderTree(TreeNode root)
    {
        if(root == null) return;
        PostorderTree(root.left);
        PostorderTree(root.right);
        Console.Write(root.val+" ");
    }
    /// <summary>
    /// 层序遍历
    /// </summary>
    /// <param name="root"></param>
    public static void SequenceTraversalTree(TreeNode root)
    {
        if(root == null) return;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int count = queue.Count;
            string printStr = "";
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    printStr = node.val.ToString();
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                else
                    printStr = "null";
                Console.Write(printStr+" ");
            }
        }
        Console.WriteLine();
    }

    /// <summary>
    /// 构建二维数组
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int[][] ConstructTArray(string str)
    {
        List<int[]> res = new List<int[]>();
        str = str.Substring(1, str.Length - 2);
        int index = 0;
        int startIndex = 0;
        int endIndex = 0;
        while (index < str.Length)
        {
            if (str[index] == '[')
            {
                startIndex = index + 1;
            }
            else if (str[index] == ']')
            {
                endIndex = index - 1;
                if (endIndex - startIndex >= 0)
                {
                    var arrStr = str.Substring(startIndex, endIndex - startIndex + 1);
                    var arr = arrStr.Split(",");
                    res.Add(new int[arr.Length]);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        res[^1][i]=int.Parse(arr[i]);
                    }
                }
            }

            index++;
        }
        
        return res.ToArray();
    }

    /// <summary>
    /// 构造链表
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static ListNode ConstructLinkedList(int[] arr)
    {
        ListNode head = new ListNode();
        ListNode cur = head;
        for (int i = 0; i < arr.Length; i++)
        {
            ListNode node = new ListNode(arr[i]);
            cur.next = node;
            cur = node;
        }
        return head.next;
    }

    public static void PrintLinkedList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " ");
            head = head.next;
        }
        Console.WriteLine();
    }
}