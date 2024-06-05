using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_05
{
    public static void Test()
    {
        LeetCode_04_05 obj = new LeetCode_04_05();
    }
    
    public bool IsValidBST(TreeNode root)
    {
        List<int> list = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curNode = root;

        while (stack.Count > 0 || curNode != null)
        {
            if (curNode != null)
            {
                stack.Push(curNode);
                curNode = curNode.left;
            }
            else
            {
                var node = stack.Pop();
                list.Add(node.val);
                curNode = node.right;
            }
        }

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] <= list[i - 1])
                return false;
        }

        return true;
    }
}