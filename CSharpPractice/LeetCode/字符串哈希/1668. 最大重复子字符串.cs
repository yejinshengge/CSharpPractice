namespace CSharpPractice.LeetCode.字符串哈希;

/**
 * 给你一个字符串 sequence ，如果字符串 word 连续重复 k 次形成的字符串是 sequence 的一个子字符串，那么单词 word 的 重复值为 k 。单词 word 的 最大重复值 是单词 word 在 sequence 中最大的重复值。如果 word 不是 sequence 的子串，那么重复值 k 为 0 。

给你一个字符串 sequence 和 word ，请你返回 最大重复值 k 。
 */
public class LeetCode_1668
{
    public static void Test()
    {
        LeetCode_1668 obj = new LeetCode_1668();
        Console.WriteLine(obj.MaxRepeating("ababc","ab"));
        Console.WriteLine(obj.MaxRepeating("ababc","ba"));
        Console.WriteLine(obj.MaxRepeating("ababc","ac"));
    }
    
    public int MaxRepeating(string sequence, string word)
    {
        int baseNum = 131;
        string totalStr = sequence + word;
        var sequenceLen = sequence.Length;
        var totalStrLen = totalStr.Length;
        var wordLen = word.Length;
        
        int[] dp = new int[sequenceLen + 1];
        int[] pre = new int[totalStrLen + 1];
        int[] power = new int[totalStrLen + 1];
        power[0] = 1;
        for (int i = 1; i <= totalStrLen; i++)
        {
            pre[i] = pre[i - 1] * baseNum + totalStr[i - 1];
            power[i] = power[i - 1] * baseNum;
        }

        int targetHash = pre[totalStrLen] - pre[totalStrLen - wordLen] * power[wordLen];
        int res = 0;
        for (int i = 1; i <= sequenceLen; i++)
        {
            if(i < wordLen) continue;
            int curHash = pre[i] - pre[i - wordLen] * power[wordLen];
            if (curHash == targetHash) dp[i] = dp[i - wordLen] + 1;
            res = Math.Max(res, dp[i]);
        }

        return res;
    }
}