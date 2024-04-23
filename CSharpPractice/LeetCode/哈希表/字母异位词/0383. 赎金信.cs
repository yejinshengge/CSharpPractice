namespace CSharpPractice.LeetCode.哈希表篇;

/**
给你两个字符串：ransomNote 和 magazine ，判断 ransomNote 能不能由 magazine 里面的字符构成。
如果可以，返回 true ；否则返回 false 。
magazine 中的每个字符只能在 ransomNote 中使用一次。
 */
public class LeetCode_0383
{
    public static void Test()
    {
        LeetCode_0383 obj = new LeetCode_0383();
        Console.WriteLine(obj.CanConstruct("a","b"));
        Console.WriteLine(obj.CanConstruct("aa","ab"));
        Console.WriteLine(obj.CanConstruct("aa","aab"));
    }

    public bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>(magazine.Length);
        for (int i = 0; i < magazine.Length; i++)
        {
            dic.TryAdd(magazine[i], 0);
            dic[magazine[i]]++;
        }

        for (int i = 0; i < ransomNote.Length; i++)
        {
            if (dic.ContainsKey(ransomNote[i]) && dic[ransomNote[i]] > 0)
                dic[ransomNote[i]]--;
            else
                return false;
        }

        return true;

    }
}