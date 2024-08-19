using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR043
{
    public static void Test()
    {
        LeetCode_LCR043 obj = new LeetCode_LCR043();
        CBTInserter cbt = new CBTInserter(new TreeNode(1));
    }
    
    public class CBTInserter
    {
        private TreeNode _root;
        private Queue<TreeNode> _queue = new();
        public CBTInserter(TreeNode root)
        {
            _root = root;
            _queue.Enqueue(root);
            while (_queue.Count > 0)
            {
                var node = _queue.Peek();
                if (node.left != null && node.right != null)
                {
                    _queue.Enqueue(node.left);
                    _queue.Enqueue(node.right);
                    _queue.Dequeue();
                }
                else if (node.left != null)
                {
                    _queue.Enqueue(node.left);
                    break;
                }
                else
                    break;
            }
        }
    
        public int Insert(int v)
        {
            var treeNode = _queue.Peek();
            if (treeNode.left == null)
            {
                treeNode.left = new TreeNode(v);
                _queue.Enqueue(treeNode.left);
                return treeNode.val;
            }

            treeNode.right = new TreeNode(v);
            _queue.Enqueue(treeNode.right);
            _queue.Dequeue();
            return treeNode.val;
        }
    
        public TreeNode Get_root()
        {
            return _root;
        }
    }
}