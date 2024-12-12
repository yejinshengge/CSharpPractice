using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0103
{
    public static void Test()
    {
        LeetCode_0103 obj = new LeetCode_0103();
        Tools.PrintEnumerator(obj.ZigzagLevelOrder(Tools.ConstructTree("3,9,20,null,null,15,7")));
        Tools.PrintEnumerator(obj.ZigzagLevelOrder(Tools.ConstructTree("1")));
        Tools.PrintEnumerator(obj.ZigzagLevelOrder(Tools.ConstructTree("")));
    }
    
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null) return res;
        Queue<TreeNode> queue = new();
        Stack<TreeNode> stack = new();
        bool flag = false;
        
        
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            res.Add(new List<int>());
            var count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(flag)
                    stack.Push(node);
                else
                    res[^1].Add(node.val);
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
            }

            flag = !flag;
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                res[^1].Add(node.val);
            }
        }

        return res;
    }
}