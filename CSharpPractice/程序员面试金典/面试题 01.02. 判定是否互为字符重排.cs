namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_02
{
    public static void Test()
    {
        LeetCode_01_02 obj = new LeetCode_01_02();
        Console.WriteLine(obj.CheckPermutation("abc","bca"));
        Console.WriteLine(obj.CheckPermutation("abc","bad"));
    }
    
    // 哈希表
    public bool CheckPermutation1(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        int[] map = new int[26];
        foreach (var c in s1)
        {
            map[c - 'a']++;
        }

        foreach (var c in s2)
        {
            map[c - 'a']--;
            if (map[c - 'a'] < 0) return false;
        }

        return true;
    }
    
    // 位运算（错误解法）
    public bool CheckPermutation(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        int flag = 0;
        foreach (var c in s1)
        {
            flag ^= c;
        }

        foreach (var c in s2)
        {
            flag ^= c;
        }

        return flag == 0;
    }
}