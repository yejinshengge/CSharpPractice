namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR005
{
    public static void Test()
    {
        LeetCode_LCR005 obj = new LeetCode_LCR005();
        Console.WriteLine(obj.MaxProduct(new []{"abcw","baz","foo","bar","fxyz","abcdef"}));
        Console.WriteLine(obj.MaxProduct(new []{"a","ab","abc","d","cd","bcd","abcd"}));
        Console.WriteLine(obj.MaxProduct(new []{"a","aa","aaa","aaaa"}));
    }
    
    public int MaxProduct1(string[] words)
    {
        Dictionary<string, HashSet<char>> dic = new();
        foreach (var word in words)
        {
            if(dic.ContainsKey(word)) continue;
            dic.Add(word, new HashSet<char>());
            foreach (var c in word)
            {
                dic[word].Add(c);
            }
        }

        int maxLen = 0;
        for (int i = 0; i < words.Length; i++)
        {
            var hashSet = dic[words[i]];
            for (int j = i+1; j < words.Length; j++)
            {
                bool contains = false;
                foreach (var c in words[j])
                {
                    if (hashSet.Contains(c))
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                    maxLen = Math.Max(maxLen, words[i].Length * words[j].Length);
            }
        }
        return maxLen;
    }

    public int MaxProduct(string[] words)
    {
        int[] dic = new int[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            // 把存在的位设置成1
            foreach (var c in words[i])
            {
                dic[i] |= 1 << (c - 'a');
            }
        }

        int maxLen = 0;
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i+1; j < words.Length; j++)
            {
                // 如果两个单词没有相同的字母，则相与为0
                if ((dic[i] & dic[j]) == 0)
                    maxLen = Math.Max(maxLen, words[i].Length * words[j].Length);
            }
        }

        return maxLen;
    }
}