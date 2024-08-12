namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR032
{
    public static void Test()
    {
        LeetCode_LCR032 obj = new LeetCode_LCR032();
        Console.WriteLine(obj.IsAnagram("anagram","nagaram"));
        Console.WriteLine(obj.IsAnagram("rat","car"));
        Console.WriteLine(obj.IsAnagram("a","a"));
    }
    
    public bool IsAnagram(string s, string t)
    {
        if (s == t) return false;
        Dictionary<char, int> dic = new();
        foreach (var c in s)
        {
            dic.TryAdd(c, 0);
            dic[c]++;
        }
        foreach (var c in t)
        {
            if (!dic.ContainsKey(c))
                return false;
            dic[c]--;
            if (dic[c] == 0)
                dic.Remove(c);
        }
        
        return dic.Count == 0;
    }
}