namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR067
{
    public static void Test()
    {
        LeetCode_LCR067 obj = new LeetCode_LCR067();
        Console.WriteLine(obj.FindMaximumXOR(new []{3,10,5,25,2,8}));
        Console.WriteLine(obj.FindMaximumXOR(new []{0}));
        Console.WriteLine(obj.FindMaximumXOR(new []{2,4}));
        Console.WriteLine(obj.FindMaximumXOR(new []{8,10,2}));
        Console.WriteLine(obj.FindMaximumXOR(new []{14,70,53,83,49,91,36,80,92,51,66,70}));
    }
    
    public int FindMaximumXOR(int[] nums)
    {
        Trie trie = new Trie();
        foreach (var num in nums)
        {
            trie.Insert(num);
        }

        int maxXor = 0;
        foreach (var num in nums)
        {
            maxXor = Math.Max(trie.GetMaxXOR(num),maxXor);
        }

        return maxXor;
    }

    private class Trie
    {
        private class TreeNode
        {
            public TreeNode[] children = new TreeNode[2];
            public int val;
        }

        private TreeNode _head = new();

        public void Insert(int val)
        {
            TreeNode cur = _head;
            for (int i = 31; i >= 0; i--)
            {
                var index = (val >>> i) & 1;
                if (cur.children[index] == null)
                {
                    cur.children[index] = new TreeNode();
                    cur.children[index].val = index;
                }
                
                cur = cur.children[index];
            }
        }

        public int GetMaxXOR(int num)
        {
            TreeNode cur = _head;
            int xor = 0;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >>> i) & 1;
                if (cur.children[1 - bit] != null)
                {
                    xor = (xor << 1) + 1;
                    cur = cur.children[1 - bit];
                }
                else
                {
                    xor <<= 1;
                    cur = cur.children[bit];
                }
            }

            return xor;
        }
    }
}