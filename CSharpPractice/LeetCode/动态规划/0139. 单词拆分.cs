namespace CSharpPractice.LeetCode.动态规划;
/**
给你一个字符串 s 和一个字符串列表 wordDict 作为字典。
请你判断是否可以利用字典中出现的单词拼接出 s 。
注意：不要求字典中出现的单词全部都使用，并且字典中的单词可以重复使用。
 */
public class LeetCode_NUM0139
{
    public static void Test()
    {
        LeetCode_NUM0139 obj = new LeetCode_NUM0139();
        Console.WriteLine(obj.WordBreak("catsandog",new List<string>()
        {
            "cats", "dog", "sand", "and", "cat"
        }));
    }
    
    public bool WordBreak(string s, IList<string> wordDict)
    {
        HashSet<string> set = new HashSet<string>(wordDict);
        bool[] dp = new bool[s.Length+1];

        dp[0] = true;
        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                string str = s.Substring(j, i - j);
                if (set.Contains(str) && dp[j])
                    dp[i] = true;
            }
        }
        return dp[s.Length];
    }
}