namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR062
{
    public static void Test()
    {
        LeetCode_LCR062 obj = new LeetCode_LCR062();
        Trie trie = new Trie();
        trie.Insert("apple");
        Console.WriteLine(trie.Search("apple"));
        Console.WriteLine(trie.Search("app"));
        Console.WriteLine(trie.StartsWith("app"));
        trie.Insert("app");
        Console.WriteLine(trie.Search("app"));
    }
    
    public class Trie {
        private class TreeNode
        {
            public char val;
            public Dictionary<char, TreeNode> children;
            public bool isEnd;

            public TreeNode(char val)
            {
                children = new Dictionary<char, TreeNode>();
                this.val = val;
            }
        }

        private TreeNode _head;
        /** Initialize your data structure here. */
        public Trie()
        {
            _head = new TreeNode('#');
        }
    
        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TreeNode cur = _head;
            for (var i = 0; i < word.Length; i++)
            {
                if (cur.children.ContainsKey(word[i]))
                    cur = cur.children[word[i]];
                else
                {
                    cur.children.Add(word[i],new TreeNode(word[i]));
                    cur = cur.children[word[i]];
                }

                if (i == word.Length - 1)
                    cur.isEnd = true;
            }
        }
    
        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TreeNode cur = _head;
            for (var i = 0; i < word.Length; i++)
            {
                if (!cur.children.ContainsKey(word[i]))
                    return false;
                cur = cur.children[word[i]];
            }

            return cur.isEnd;
        }
    
        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix) {
            TreeNode cur = _head;
            for (var i = 0; i < prefix.Length; i++)
            {
                if (!cur.children.ContainsKey(prefix[i]))
                    return false;
                cur = cur.children[prefix[i]];
            }

            return true;
        }
    }
}