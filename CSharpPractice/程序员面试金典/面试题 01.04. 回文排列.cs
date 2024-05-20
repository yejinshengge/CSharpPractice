namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_04
{
    public static void Test()
    {
        LeetCode_01_04 obj = new LeetCode_01_04();
        Console.WriteLine(obj.CanPermutePalindrome("tactcoa"));
        Console.WriteLine(obj.CanPermutePalindrome("abc"));
        Console.WriteLine(obj.CanPermutePalindrome(""));
    }
    
    // 哈希表
    public bool CanPermutePalindrome1(string s)
    {
        HashSet<char> set = new HashSet<char>();
        foreach (var c in s)
        {
            if (!set.Add(c))
                set.Remove(c);
        }

        return set.Count <= 1;
    }

    // 字符范围在32以内时可以用这个解法
    public bool CanPermutePalindrome(string s)
    {
        int res = 0;
        foreach (var c in s)
        {   
            res ^= 1 << c;
        }
        // 校验res里是否至多有1个1
        int check = res & (res - 1);
        return check == 0;
    }
}