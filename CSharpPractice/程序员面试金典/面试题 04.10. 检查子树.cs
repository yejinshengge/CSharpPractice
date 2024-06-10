using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_10
{
    public static void Test()
    {
        LeetCode_04_10 obj = new LeetCode_04_10();
        // Console.WriteLine(obj.CheckSubTree1(Tools.ConstructTree("4,2,6,1,3,5,7"), Tools.ConstructTree("5,2,6,1,3,null,7,null,null,null,null,4")));
        obj._inOrder(Tools.ConstructTree("4,2,6,1,3,5,7"));
        Console.WriteLine();
        obj._inOrder(Tools.ConstructTree("5,2,6,1,3,null,7,null,null,null,null,4"));
    }

    private void _inOrder(TreeNode node)
    {
        if (node == null)
        {
            Console.Write("N,");
            return;
        }
        _inOrder(node.left);
        Console.Write(node.val+",");
        _inOrder(node.right);
    }

    #region 前序遍历+kmp
    public bool CheckSubTree1(TreeNode t1, TreeNode t2)
    {
        string s1 = _preOrder(t1);
        Console.WriteLine(s1);
        string s2 = _preOrder(t2);
        Console.WriteLine(s2);
        return _kmp(s1, s2);
    }

    private string _preOrder(TreeNode t)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        StringBuilder sb = new StringBuilder();
        sb.Append(',');
        stack.Push(t);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node != null)
            {
                sb.Append(node.val);
                stack.Push(node.right);
                stack.Push(node.left);
            }
            else
                sb.Append('N');
            sb.Append(',');
        }
        return sb.ToString();
    }

    private bool _kmp(string s1, string s2)
    {
        int[] next = new int[s2.Length+1];
        int left = 0, right = 1;
        while (right < s2.Length)
        {
            if (s2[left] == s2[right])
                next[++right] = ++left;
            else if (left > 0)
                left = next[left];
            else
                next[++right] = 0;
        }

        left = right = 0;
        while (left < s1.Length && right < s2.Length)
        {
            if (s1[left] == s2[right])
            {
                left++;
                right++;
            }
            else if (right > 0)
                right = next[right];
            else
                left++;
        }

        return right == s2.Length;
    }

    

    #endregion

    #region 递归
    public bool CheckSubTree(TreeNode t1, TreeNode t2)
    {
        if (t1 == null) return false;
        if (t2 == null) return true;
        return _checkIsEqual(t1, t2) || CheckSubTree(t1.left, t2) || CheckSubTree(t1.right, t2);
    }
    private bool _checkIsEqual(TreeNode t1, TreeNode t2)
    {
        if (t1 == t2) return true;
        if (t1 == null || t2 == null) return false;
        return t1.val == t2.val && _checkIsEqual(t1.left, t2.left) && _checkIsEqual(t1.right, t2.right);
    }
    
    #endregion
}