using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR033
{
    public static void Test()
    {
        LeetCode_LCR033 obj = new LeetCode_LCR033();
        Tools.PrintEnumerator(obj.GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" }));
        Tools.PrintEnumerator(obj.GroupAnagrams(new[] { ""}));
        Tools.PrintEnumerator(obj.GroupAnagrams(new[] { "a"}));
    }
    
    public IList<IList<string>> GroupAnagrams1(string[] strs)
    {
        Dictionary<string,int> dic = new ();
        IList<IList<string>> res = new List<IList<string>>();
        foreach (var str in strs)
        {
            // 排序
            var chars = str.ToCharArray();
            Array.Sort(chars);
            string key = new string(chars);
            // 没有该组
            if (!dic.ContainsKey(key))
            {
                IList<string> group = new List<string>();
                group.Add(str);
                res.Add(group);
                dic[key] = res.Count - 1;
            }
            // 有该组
            else
            {
                res[dic[key]].Add(str);
            }
        }

        return res;
    }

    // 将每个字符映射为一个质数
    private int[] charMap = new[] { 2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97,101 };
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<long, int> dic = new();
        IList<IList<string>> res = new List<IList<string>>();
        foreach (var str in strs)
        {
            // 计算key
            long key = 1;
            foreach (var c in str)
            {
                key *= charMap[c - 'a'];
            }
            // 没有该组
            if (!dic.ContainsKey(key))
            {
                IList<string> group = new List<string>();
                group.Add(str);
                res.Add(group);
                dic[key] = res.Count - 1;
            }
            // 有该组
            else
            {
                res[dic[key]].Add(str);
            }
        }

        return res;
    }
}