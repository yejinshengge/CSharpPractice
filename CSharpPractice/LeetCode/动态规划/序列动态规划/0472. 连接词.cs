using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个 不含重复 单词的字符串数组 words ，请你找出并返回 words 中的所有 连接词 。

    连接词 定义为：一个完全由给定数组中的至少两个较短单词（不一定是不同的两个单词）组成的字符串。
 */
public class LeetCode_0472
{
    public static void Test()
    {
        LeetCode_0472 obj = new LeetCode_0472();
        Tools.PrintEnumerator(obj.FindAllConcatenatedWordsInADict(new []{"cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"}));
        Tools.PrintEnumerator(obj.FindAllConcatenatedWordsInADict(new []{"cat","dog","catdog"}));
    }
    
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        HashSet<string> set = new HashSet<string>();
        foreach (var word in words)
        {
            set.Add(word);
        }

        List<string> res = new List<string>();
        foreach (var word in words)
        {
            set.Remove(word);
            if (_check(set, word))
                res.Add(word);
            set.Add(word);
        }

        return res;
    }

    private bool _check(HashSet<string> set, string word)
    {
        bool[] dp = new bool[word.Length + 1];
        dp[0] = true;

        for (int i = 1; i <= word.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if(!dp[j]) continue;
                if (set.Contains(word.Substring(j, i-j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[word.Length];
    }
}