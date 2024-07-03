namespace CSharpPractice.程序员面试金典;

public class LeetCode_16_02
{
    public static void Test()
    {
        LeetCode_16_02 obj = new LeetCode_16_02();
    }
    
    public class WordsFrequency
    {
        private Trie _trie = new();
        public WordsFrequency(string[] book)
        {
            foreach (var s in book)
            {
                _trie.Insert(s);
            }
        }
    
        public int Get(string word)
        {
            return _trie.Get(word);
        }
    }
    
    
    
    public class Trie
    {
        private class Node
        {
            public int num;
            public bool isEnd;
            public Dictionary<char, Node> children = new();
        }

        private Node root = new();
        
        public void Insert(string s)
        {
            Node cur = root;
            foreach (var c in s)
            {
                if (cur.children.ContainsKey(c))
                    cur = cur.children[c];
                else
                {
                    cur.children.Add(c,new Node());
                    cur = cur.children[c];
                }
            }

            cur.num++;
            cur.isEnd = true;
        }

        public int Get(string s)
        {
            Node cur = root;
            foreach (var c in s)
            {
                if (cur.children.ContainsKey(c))
                    cur = cur.children[c];
                else
                    return 0;
            }

            if (!cur.isEnd)
                return 0;
            return cur.num;
        }
    }
}