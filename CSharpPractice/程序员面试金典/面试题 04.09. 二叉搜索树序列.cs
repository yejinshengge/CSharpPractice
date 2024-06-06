using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_09
{
    public static void Test()
    {
        LeetCode_04_09 obj = new LeetCode_04_09();
    }
    
    public IList<IList<int>> BSTSequences(TreeNode root)
    {
        if (root == null)
        {
            _res.Add(new List<int>());
            return _res;
        }
        var queue = new LinkedList<TreeNode>();
        queue.AddLast(root);
        _bfs(root,queue);
        return _res;
    }

    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();
    private void _bfs(TreeNode root,LinkedList<TreeNode> queue)
    {
        if (queue.Count == 0)
        {
            _res.Add(new List<int>(_path));
            return;
        }

        int count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            TreeNode node = queue.ElementAt(i);
            queue.Remove(node);
            _path.Add(node.val);
            if(node.left != null)queue.AddLast(node.left);
            if(node.right != null) queue.AddLast(node.right);
            _bfs(node,queue);
            if(node.right != null)queue.RemoveLast();
            if(node.left != null)queue.RemoveLast();
            _path.RemoveAt(_path.Count-1);
            if (i == queue.Count) {
                queue.AddLast(node);
            } else {
                var cur = queue.First;
                for (int j = 0; j < i; j++) {
                    cur = cur.Next;
                }
                queue.AddBefore(cur, node);
            }
        }
    }
}