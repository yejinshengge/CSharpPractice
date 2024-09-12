using System.Text;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR065
{
    public static void Test()
    {
        LeetCode_LCR065 obj = new LeetCode_LCR065();
        Console.WriteLine(obj.MinimumLengthEncoding(new []{"time", "me", "bell"}));
        Console.WriteLine(obj.MinimumLengthEncoding(new []{"t"}));
    }
    
    public int MinimumLengthEncoding(string[] words)
    {
        Trie trie = new Trie();
        foreach (var word in words)
        {
            trie.Insert(word);
        }

        return trie.GetTotalLen();
    }
    
    private class Trie
    {
        private class TreeNode
        {
            public TreeNode[] children = new TreeNode[26];
        }

        private TreeNode _head = new();
        
        public void Insert(string str)
        {
            TreeNode cur = _head;
            for (var i = str.Length-1; i >= 0; i--)
            {
                int index = str[i] - 'a';
                if (cur.children[index] == null)
                    cur.children[index] = new TreeNode();
                cur = cur.children[index];
            }
        }

        public int GetTotalLen()
        {
            int total = 0;
            _dfs(_head, 1, ref total);
            return total;
        }
        
        private void _dfs(TreeNode root,int length,ref int total)
        {
            if(root == null)
                return;
            bool flag = false;
            for (var i = 0; i < 26; i++)
            {
                if (root.children[i] != null)
                {
                    flag = true;
                    _dfs(root.children[i], length + 1,ref total);
                }
            }

            if (!flag)
                total += length;
        }
    }
}