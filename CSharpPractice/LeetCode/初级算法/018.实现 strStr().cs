namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你两个字符串haystack 和 needle ，请你在 haystack 字符串中找出 needle 字符串的第一个匹配项的下标（下标从 0 开始）。
 * 如果needle 不是 haystack 的一部分，则返回 -1 。
 */
public class LeetCode_018 {
    
    public static void Test()
    {
        LeetCode_018 obj = new LeetCode_018();
        Console.WriteLine(obj.StrStr("456465leetcode","leet"));
    }
    
    // 思路一:KMP匹配算法
    public int StrStr(string haystack, string needle)
    {
        if (needle.Length > haystack.Length) return -1;
        if (haystack.Length == 1) return haystack[0] == needle[0] ? 0 : -1;
        
        // 先求出前后缀相同的最长子串
        int[] next = new int[needle.Length];
        next[0] = -1;

        int left = 0;
        int right = 1;

        while (right < needle.Length-1)
        {
            // 值相同,进入combo,两指针都后移
            if (needle[left] == needle[right])
            {
                left++;
                next[right + 1] = left;
                right++;
            }
            // 不相同,left回溯
            else if(left > 0)
            {
                left = next[left];
            }
            else
            {
                next[right+1] = 0;
                right++;
            }
        }
        
        // 开始匹配
        left = right = 0;

        while (left < haystack.Length && right < needle.Length)
        {
            // 相等
            if (haystack[left] == needle[right])
            {
                left++;
                right++;
            }
            // 不相等,right回溯
            else if(right > 0)
            {
                right = next[right];
            }
            else
            {
                left++;
            }
        }

        return right == needle.Length ? left - right : -1;
    }
}