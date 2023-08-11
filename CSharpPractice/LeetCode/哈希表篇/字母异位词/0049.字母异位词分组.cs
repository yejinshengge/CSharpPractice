namespace CSharpPractice.LeetCode.哈希表篇;
/**
给你一个字符串数组，请你将 字母异位词 组合在一起。可以按任意顺序返回结果列表。
字母异位词 是由重新排列源单词的所有字母得到的一个新单词。
 */
public class LeetCode_0049
{
    public static void Test()
    {
        LeetCode_0049 obj = new LeetCode_0049();
        var res1 = obj.GroupAnagrams(new []{"eat", "tea", "tan", "ate", "nat", "bat"});
        var res2 = obj.GroupAnagrams(new []{""});
        var res3 = obj.GroupAnagrams(new []{"a"});
    }
    
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        for (int i = 0; i < strs.Length; i++)
        {
            var strArr = strs[i].ToArray();
            Array.Sort(strArr);
            var key = new string(strArr);
            var list = dic.GetValueOrDefault(key, new List<string>());
            list.Add(strs[i]);
            dic[key] = list;
        }

        return new List<IList<string>>(dic.Values);
    }

}