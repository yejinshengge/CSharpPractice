using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

/**
给你一个含重复值的二叉搜索树（BST）的根节点 root ，找出并返回 BST 中的所有 众数（即，出现频率最高的元素）。

如果树中有不止一个众数，可以按 任意顺序 返回。
 */
public class LeetCode_0501
{
    public static void Test()
    {
        LeetCode_0501 obj = new LeetCode_0501();
        var tree = Tools.ConstructTree("1,null,2");
        Tools.PrintArr(obj.FindMode(tree));
    }

    public int[] FindMode(TreeNode root)
    {
        List<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;
        TreeNode pre = null;
        int maxCount = 0;
        int curCount = 0;
        
        while (stack.Count > 0 || cur != null)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                var node = stack.Pop();
                cur = node.right;
                if (pre == null)
                {
                    curCount = 1;
                    maxCount = 1;
                }
                else if (node.val == pre.val)
                {
                    curCount++;
                }
                else
                {
                    curCount = 1;
                }
                
                if (curCount > maxCount)
                {
                    maxCount = curCount;
                    res.Clear();
                    res.Add(node.val);
                }
                else if(curCount == maxCount)
                    res.Add(node.val);
                pre = node;
            }
        }

        return res.ToArray();
    }
}