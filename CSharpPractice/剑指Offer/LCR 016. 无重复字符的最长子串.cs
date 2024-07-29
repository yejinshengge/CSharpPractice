namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR016
{
    public static void Test()
    {
        LeetCode_LCR016 obj = new LeetCode_LCR016();
        Console.WriteLine(obj.LengthOfLongestSubstring("abcabcbb"));
        Console.WriteLine(obj.LengthOfLongestSubstring("bbbbb"));
        Console.WriteLine(obj.LengthOfLongestSubstring("pwwkew"));
        Console.WriteLine(obj.LengthOfLongestSubstring(""));
    }
    
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> count = new();
        int maxLen = 0;
        int left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            count.TryAdd(s[right], 0);
            count[s[right]]++;
            while (count[s[right]] > 1)
            {
                count[s[left]]--;
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}