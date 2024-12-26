namespace CSharpPractice.LeetCode.哈希表篇;

public class LeetCode_3083
{
    public static void Test()
    {
        LeetCode_3083 obj = new LeetCode_3083();
        Console.WriteLine(obj.IsSubstringPresent("leetcode"));
        Console.WriteLine(obj.IsSubstringPresent("abcba"));
        Console.WriteLine(obj.IsSubstringPresent("abcd"));
    }
    
    public bool IsSubstringPresent(string s)
    {
        if (s.Length == 1) return false;
        HashSet<string> set = new();
        for (int i = 1; i < s.Length; i++)
        {
            var pos = string.Concat(s[i - 1] , s[i]);
            var neg = string.Concat(s[i], s[i - 1]);
            set.Add(neg);
            if (set.Contains(pos)) return true;
        }

        return false;
    }
}