using System.Text;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR063
{
    public static void Test()
    {
        LeetCode_LCR063 obj = new LeetCode_LCR063();
        Console.WriteLine(obj.ReplaceWords(new List<string>(){"cat","bat","rat"},"the cattle was rattled by the battery"));
    }
    
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        Trie trie = new Trie();
        foreach (var str in dictionary)
        {
            trie.Insert(str);
        }

        var arr = sentence.Split(' ');
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = trie.GetPrefix(arr[i]);
        }

        return string.Join(" ",arr);
    }

    private class Trie
    {
        private class TreeNode
        {
            public TreeNode[] children = new TreeNode[26];
            public bool isEnd;
        }

        private TreeNode _head = new TreeNode();

        public void Insert(string str)
        {
            TreeNode cur = _head;
            for (var i = 0; i < str.Length; i++)
            {
                var index = str[i]-'a';
                var child = cur.children[index];
                if (child == null)
                {
                    child = new TreeNode();
                    cur.children[index] = child;
                }
                cur = child;
            }
            cur.isEnd = true;
        }

        public string GetPrefix(string str)
        {
            TreeNode cur = _head;
            StringBuilder sb = new();
            for (var i = 0; i < str.Length; i++)
            {
                var index = str[i]-'a';
                var child = cur.children[index];
                if (child == null)
                    return str;
                sb.Append(str[i]);
                if (child.isEnd) return sb.ToString();
                cur = child;
            }
            return str;
        }
    }
}