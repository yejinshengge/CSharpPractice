using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;
// 给你一棵所有节点为非负值的二叉搜索树，请你计算树中任意两节点的差的绝对值的最小值。
public class LeetCode_0530
{
    public static void Test()
    {
        LeetCode_0530 obj = new LeetCode_0530();
        var tree = Tools.ConstructTree("236,104,701,null,227,null,911");
        Console.WriteLine(obj.GetMinimumDifference(tree));
    }
    
    public int GetMinimumDifference(TreeNode root)
    {
        List<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node != null)
            {
                if(node.right != null)
                    stack.Push(node.right);
                stack.Push(node);
                stack.Push(null);
                if(node.left != null)
                    stack.Push(node.left);
            }
            else
            {
                node = stack.Pop();
                res.Add(node.val);
            }
        }

        int min = int.MaxValue;
        for (int i = 1; i < res.Count; i++)
        {
            min = Math.Min(Math.Abs(res[i] - res[i - 1]), min);
        }

        return min;
    }

}