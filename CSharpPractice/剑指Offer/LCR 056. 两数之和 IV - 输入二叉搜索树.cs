using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR056
{
    public static void Test()
    {
        LeetCode_LCR056 obj = new LeetCode_LCR056();
        Console.WriteLine(obj.FindTarget(Tools.ConstructTree("8,6,10,5,7,9,11"),12));
        Console.WriteLine(obj.FindTarget(Tools.ConstructTree("8,6,10,5,7,9,11"),22));
        
    }
    
    public bool FindTarget1(TreeNode root, int k)
    {
        HashSet<int> dic = new();
        Stack<TreeNode> stack = new();
        TreeNode cur = root;

        while (cur != null || stack.Count > 0)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                cur = stack.Pop();
                if (dic.Contains(k - cur.val))
                    return true;
                dic.Add(cur.val);
                cur = cur.right;
            }
        }

        return false;
    }

    public bool FindTarget(TreeNode root, int k)
    {
        BSTIterator it = new BSTIterator(root, false);
        BSTIterator preIt = new BSTIterator(root, true);

        var next = it.Next();
        var pre = preIt.Next();
        while (pre != next)
        {
            if (pre + next == k) return true;
            if (pre + next > k)
            {
                pre = preIt.Next();
            }
            else
            {
                next = it.Next();
            }
        }

        return false;
    }
    
    class BSTIterator
    {
        private TreeNode _cur;
        private Stack<TreeNode> _stack;
        private bool _reverse;
        public BSTIterator(TreeNode root,bool reverse)
        {
            _cur = root;
            _stack = new Stack<TreeNode>();
            _reverse = reverse;
        }

        public int Next() {
            while (_cur != null)
            {
                _stack.Push(_cur);
                _cur = _reverse?_cur.right:_cur.left;
            }

            _cur = _stack.Pop();
            int val = _cur.val;
            _cur = _reverse?_cur.left:_cur.right;
            return val;
        }

        public bool HasNext()
        {
            return _cur != null || _stack.Count > 0;
        }
    }
}