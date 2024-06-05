using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_03
{
    public static void Test()
    {
        LeetCode_04_03 obj = new LeetCode_04_03();
    }
    
    public ListNode[] ListOfDepth(TreeNode tree)
    {
        List<ListNode> res = new List<ListNode>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(tree);

        while (queue.Count > 0)
        {
            int count = queue.Count;
            ListNode vHead = new ListNode();
            ListNode cur = vHead;
            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
                cur.next = new ListNode(node.val);
                cur = cur.next;
            }
            res.Add(vHead.next);
        }

        return res.ToArray();
    }
}