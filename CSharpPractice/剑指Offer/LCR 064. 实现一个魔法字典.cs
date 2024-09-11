namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR064
{
    public static void Test()
    {
        LeetCode_LCR064 obj = new LeetCode_LCR064();
        MagicDictionary dic = new MagicDictionary();
        dic.BuildDict(new []{"hello","hhllo", "leetcode"});
        Console.WriteLine(dic.Search("hello"));
        Console.WriteLine(dic.Search("hhllo"));
        Console.WriteLine(dic.Search("hell"));
        Console.WriteLine(dic.Search("leetcoded"));
    }
    
    public class MagicDictionary {
        private class TreeNode
        {
            public TreeNode[] children = new TreeNode[26];
            public bool isEnd;
        }

        private TreeNode _head;
        
        public MagicDictionary()
        {
            _head = new TreeNode();
        }
    
        public void BuildDict(string[] dictionary)
        {
            foreach (var str in dictionary)
            {
                _insert(str);
            }
        }
    
        public bool Search(string searchWord)
        {
            return _search(_head, searchWord, 0, 0);
        }

        private void _insert(string str)
        {
            TreeNode cur = _head;
            for (var i = 0; i < str.Length; i++)
            {
                int index = str[i] - 'a';
                if (cur.children[index] == null)
                {
                    cur.children[index] = new TreeNode();
                }
                cur = cur.children[index];
                
            }
            cur.isEnd = true;
        }

        private bool _search(TreeNode root, string str,int start,int isEdit)
        {
            if (root == null) return false;
            if (root.isEnd && isEdit == 1 && start == str.Length) return true;

            if (start < str.Length && isEdit <= 1)
            {
                bool found = false;
                int index = str[start] - 'a';
                for (int i = 0; i < 26 && !found; i++)
                {
                    int next = i == index ? isEdit : isEdit + 1;
                    found = _search(root.children[i], str, start + 1, next);
                }

                return found;
            }

            return false;
        }
    }
}