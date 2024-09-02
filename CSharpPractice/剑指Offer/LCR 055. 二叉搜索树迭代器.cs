using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR055
{
    public static void Test()
    {
        LeetCode_LCR055 obj = new LeetCode_LCR055();
    }
    
    public class BSTIterator1
    {
        private int[] _arr;
        private int _tail;
        
        public BSTIterator1(TreeNode root)
        {
            _arr = new int[100001];
            Stack<TreeNode> stack = new Stack<TreeNode>();
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
                    _heapInsert(cur.val);
                    cur = cur.right;
                }
            }

        }
    
        public int Next()
        {
            int top = _arr[0];
            _arr[0] = _arr[--_tail];
            _heapify();
            return top;
        }
    
        public bool HasNext()
        {
            return _tail > 0;
        }

        private void _heapInsert(int val)
        {
            _arr[_tail] = val;
            int index = _tail;
            int parent = (index - 1) / 2;
            while (_arr[index] < _arr[parent])
            {
                (_arr[index], _arr[parent]) = (_arr[parent], _arr[index]);
                index = parent;
                parent = (index - 1) / 2;
            }
            _tail++;
        }

        private void _heapify()
        {
            int index = 0;
            int left = 1;
            while (left < _tail)
            {
                int smallest = left + 1 < _tail && _arr[left] > _arr[left + 1] ? left+1 : left;
                smallest = _arr[index] < _arr[smallest] ? index : smallest;
                if(smallest == index)
                    break;
                (_arr[smallest], _arr[index]) = (_arr[index], _arr[smallest]);
                index = smallest;
                left = index * 2 + 1;
            }
        }
    }
    
    
    public class BSTIterator
    {
        private TreeNode _cur;
        private Stack<TreeNode> _stack;
        public BSTIterator(TreeNode root)
        {
            _cur = root;
            _stack = new Stack<TreeNode>();
        }
    
        public int Next() {
            while (_cur != null)
            {
                _stack.Push(_cur);
                _cur = _cur.left;
            }

            _cur = _stack.Pop();
            int val = _cur.val;
            _cur = _cur.right;
            return val;
        }
    
        public bool HasNext()
        {
            return _cur != null || _stack.Count > 0;
        }
    }
}

