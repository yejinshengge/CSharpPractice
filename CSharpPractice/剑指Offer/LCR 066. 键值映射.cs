namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR066
{
    public static void Test()
    {
        LeetCode_LCR066 obj = new LeetCode_LCR066();
        MapSum sum = new MapSum();
        sum.Insert("apple", 3);
        Console.WriteLine(sum.Sum("ap"));
        sum.Insert("app", 2);
        Console.WriteLine(sum.Sum("ap"));
    }
    
    public class MapSum {
        private class TreeNode
        {
            public TreeNode[] children = new TreeNode[26];
            public int val;
        }

        private TreeNode _head;
        public MapSum() {
            _head = new TreeNode();
        }
    
        public void Insert(string key, int val)
        {
            TreeNode cur = _head;
            for (var i = 0; i < key.Length; i++)
            {
                int index = key[i] - 'a';
                if (cur.children[index] == null)
                    cur.children[index] = new TreeNode();
                cur = cur.children[index];
            }

            cur.val = val;
        }
    
        public int Sum(string prefix) {
            TreeNode cur = _head;
            for (var i = 0; i < prefix.Length; i++)
            {
                int index = prefix[i] - 'a';
                if (cur.children[index] == null)
                    return 0;
                cur = cur.children[index];
            }

            return _bfs(cur);
        }

        private int _bfs(TreeNode root)
        {
            int total = 0;
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                total += node.val;
                foreach (var child in node.children)
                {
                    if(child != null)
                        queue.Enqueue(child);
                }
            }

            return total;
        }
    }

}