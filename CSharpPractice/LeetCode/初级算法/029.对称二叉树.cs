using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

// 给你一个二叉树的根节点 root ， 检查它是否轴对称。
public class LeetCode_029
{
    public static void Test()
    {
        LeetCode_029 obj = new LeetCode_029();
        
        TreeNode head = new TreeNode(1);
        head.left = new TreeNode(2);
        head.right = new TreeNode(2);
        head.right.left = new TreeNode(3);
        head.right.right = new TreeNode(4);
        head.left.left = new TreeNode(4);
        head.left.right = new TreeNode(3);
        
        Console.WriteLine(obj.IsSymmetric2(head));
    }

    #region 错误解答

    // 思路一:中序遍历
    public bool IsSymmetric(TreeNode root)
    {
        var list1 = Process(root.left);
        var list2 = Process(root.right);
        list2.Reverse();
        
        if (list1.Count != list2.Count) return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if(list1[i] == list2[i]) continue;
            
            if (list1[i] == null || list2[i] == null) return false;
            
            else if (list1[i].val != list2[i].val) return false;
        }

        return true;
    }

    private List<TreeNode> Process(TreeNode root)
    {
        List<TreeNode> res = new List<TreeNode>();
        if (root == null) return res;
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;

        while (stack.Count > 0 || cur != null)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                res.Add(cur);
                cur = stack.Pop();
                res.Add(cur);
                cur = cur.right;
            }

        }
        res.Add(null);
        return res;
    }

    #endregion

    public bool IsSymmetric2(TreeNode root)
    {
        return Process2(root.left, root.right);
    }

    private bool Process2(TreeNode left, TreeNode right)
    {
        if (left == null && right == null) return true;

        if (left == null || right == null || left.val != right.val) return false;

        return Process2(left.left, right.right) && Process2(left.right, right.left);
    }

    
}