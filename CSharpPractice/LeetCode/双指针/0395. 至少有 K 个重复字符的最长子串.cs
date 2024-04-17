namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个字符串 s 和一个整数 k ，请你找出 s 中的最长子串，
 * 要求该子串中的每一字符出现次数都不少于 k 。返回这一子串的长度。如果不存在这样的子字符串，则返回 0。
 */
public class LeetCode_0395
{
    public static void Test()
    {
        LeetCode_0395 obj = new LeetCode_0395();
        Console.WriteLine(obj.LongestSubstring("aaabb",3));
        Console.WriteLine(obj.LongestSubstring("ababbc",2));
    }
    
    // 滑动窗口解法
    public int LongestSubstring(string s, int k)
    {
        int maxLen = 0;
        int[] dic = new int[26];

        // 枚举窗口内字符种类数
        for (int num = 1; num <= 26; num++)
        {
            Array.Fill(dic,0);
            int total = 0,sum = 0,left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                int index = s[right] - 'a';
                dic[index]++;
                // 新字符
                if (dic[index] == 1)
                    total++;
                // 符合条件的字符
                if (dic[index] == k)
                    sum++;
                // 如果窗口内的种类数超了，窗口左侧开始收缩
                while (total > num)
                {
                    index = s[left] - 'a';
                    dic[index]--;
                    if (dic[index] == 0) total--;
                    if (dic[index] == k - 1) sum--;
                    left++;
                }

                if (total == sum) maxLen = Math.Max(maxLen, right - left + 1);
            }
        }

        return maxLen;
    }
}