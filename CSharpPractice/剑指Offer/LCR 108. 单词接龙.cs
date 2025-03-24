namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR108
{
    public static void Test()
    {
        LeetCode_LCR108 obj = new LeetCode_LCR108();
        Console.WriteLine(obj.LadderLength("hit","cog",new List<string>(){"hot","dot","dog","lot","log","cog"}));
        Console.WriteLine(obj.LadderLength("hit","cog",new List<string>(){"hot","dot","dog","lot","log"}));
        Console.WriteLine(obj.LadderLength("a","c",new List<string>(){"a","b","c"}));
    }
    
    public int LadderLength1(string beginWord, string endWord, IList<string> wordList)
    {
        // 构建图
        Dictionary<string, List<string>> dic = new();
        for (var i = 0; i < wordList.Count; i++)
        {
            var word1 = wordList[i];
            dic.Add(word1,new List<string>());
            for (int j = 0; j < wordList.Count; j++)
            {
                if (i == j) continue;
                var word2 = wordList[j];
                if (_checkCanTrans(word1, word2))
                    dic[word1].Add(word2);
            }
        }

        if (!dic.ContainsKey(endWord)) return 0;
        // beginWord可能不存在于字典中
        if (!dic.ContainsKey(beginWord))
        {
            dic.Add(beginWord,new List<string>());
            for (int i = 0; i < wordList.Count; i++)
            {
                if(_checkCanTrans(beginWord,wordList[i]))
                    dic[beginWord].Add(wordList[i]);
            }
        }

        // 广度优先搜索
        Queue<string> queue = new();
        HashSet<string> visited = new();
        int len = 0;
        queue.Enqueue(beginWord);
        while (queue.Count > 0)
        {
            len++;
            var count = queue.Count;
            for (int j = 0; j < count; j++)
            {
                var curWord = queue.Dequeue();
                visited.Add(curWord);
                var list = dic[curWord];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == endWord) return ++len;
                    if(visited.Contains(list[i])) continue;
                    queue.Enqueue(list[i]);
                }
            }
        }

        return 0;
    }

    private bool _checkCanTrans(string str1, string str2)
    {
        bool flag = false;
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] == str2[i]) continue;
            if (flag) return false;
            flag = true;
        }
        return true;
    }
    
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        Dictionary<string, List<string>> dic = new();
        for (var i = 0; i < wordList.Count; i++)
        {
            var word1 = wordList[i];
            dic.Add(word1,new List<string>());
            for (int j = 0; j < wordList.Count; j++)
            {
                if (i == j) continue;
                var word2 = wordList[j];
                if (_checkCanTrans(word1, word2))
                    dic[word1].Add(word2);
            }
        }

        if (!dic.ContainsKey(endWord)) return 0;
        if (!dic.ContainsKey(beginWord))
        {
            dic.Add(beginWord,new List<string>());
            for (int i = 0; i < wordList.Count; i++)
            {
                if(_checkCanTrans(beginWord,wordList[i]))
                    dic[beginWord].Add(wordList[i]);
            }
        }

        // 双向广度优先搜索
        HashSet<string> beginSet = new();
        HashSet<string> endSet = new();
        HashSet<string> visited = new();
        int len = 2;
        beginSet.Add(beginWord);
        endSet.Add(endWord);
        while (beginSet.Count > 0 && endSet.Count > 0)
        {
            // 始终查找最少的
            if (beginSet.Count > endSet.Count)
                (beginSet, endSet) = (endSet, beginSet);
            
            
            HashSet<string> tmp = new HashSet<string>();
            foreach (var str in beginSet)
            {
                var list = dic[str];
                visited.Add(str);
                foreach (var neighbor in list)
                {
                    // 相遇
                    if (endSet.Contains(neighbor)) return len;
                    // 已查询过
                    if(visited.Contains(neighbor)) continue;
                    tmp.Add(neighbor);
                }
            }

            beginSet = tmp;
            len++;
        }

        return 0;
    }
}