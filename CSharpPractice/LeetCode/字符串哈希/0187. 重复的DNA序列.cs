using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.字符串哈希;

/**
 * DNA序列 由一系列核苷酸组成，缩写为 'A', 'C', 'G' 和 'T'.。

例如，"ACGAATTCCG" 是一个 DNA序列 。
在研究 DNA 时，识别 DNA 中的重复序列非常有用。

给定一个表示 DNA序列 的字符串 s ，返回所有在 DNA 分子中出现不止一次的 长度为 10 的序列(子字符串)。你可以按 任意顺序 返回答案。
 */
public class LeetCode_0187
{
    public static void Test()
    {
        LeetCode_0187 obj = new LeetCode_0187();
        Tools.PrintEnumerator(obj.FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"));
        Tools.PrintEnumerator(obj.FindRepeatedDnaSequences("AAAAAAAAAAAAA"));
    }
    
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        const int baseNum = 131313;
        int[] pre = new int[s.Length+1];
        int[] power = new int[s.Length+1];

        power[0] = 1;
        for (int i = 1; i <= s.Length; i++)
        {
            pre[i] = pre[i - 1] * baseNum + s[i-1];
            power[i] = power[i - 1] * baseNum;
        }

        List<string> res = new List<string>();
        Dictionary<int,int> dic = new Dictionary<int,int>();
        for (int i = 1; i + 10-1 <= s.Length; i++)
        {
            int hash = pre[i + 10 - 1] - pre[i-1] * power[i + 10 - 1 - i+1];
            dic.TryGetValue(hash, out var num);
            if(num == 1)
                res.Add(s.Substring(i-1,10));
            dic[hash] = num + 1;
        }

        return res;
    }
}