namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给定一个字符串 s ，找到 它的第一个不重复的字符，并返回它的索引 。如果不存在，则返回 -1 。
 */
public class LeetCode_014 {

    public static void LeetCode_014Main()
    {
        LeetCode_014 obj = new LeetCode_014();
        Console.WriteLine(obj.FirstUniqChar2("loveleetcode"));
    }
    
    // 思路一:利用字典,最后需要遍历字典
    public int FirstUniqChar(string s)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (dic.ContainsKey(c))
                dic[c] = -1;
            else
                dic[c] = i;
        }

        int res = 1000000;
        foreach (var index in dic.Values)
        {
            if (index != -1)
                res = Math.Min(index, res);
        }

        if (res == 1000000) return -1;
        return res;
    }

    // 优化:字典记录出现次数,通过遍历字符串找到第一个出现次数为1的
    public int FirstUniqChar2(string s)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (dic.ContainsKey(c))
                dic[c]++;
            else
                dic[c] = 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (dic[c] == 1) return i;
        }

        return -1;
    }
}