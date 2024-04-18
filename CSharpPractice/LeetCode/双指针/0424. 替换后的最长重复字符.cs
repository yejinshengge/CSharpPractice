namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个字符串 s 和一个整数 k 。你可以选择字符串中的任一字符，
 *  并将其更改为任何其他大写英文字符。该操作最多可执行 k 次。
    在执行上述操作后，返回 包含相同字母的最长子字符串的长度。
 */
public class LeetCode_0424
{
    public static void Test()
    {
        LeetCode_0424 obj = new LeetCode_0424();
        Console.WriteLine(obj.CharacterReplacement("ABAB",2));
        Console.WriteLine(obj.CharacterReplacement("AABABBA",1));
        Console.WriteLine(obj.CharacterReplacement("ABAA",0));
        Console.WriteLine(obj.CharacterReplacement("AAAA",0));
        Console.WriteLine(obj.CharacterReplacement("ABBB",2));
    }
    
    public int CharacterReplacement(string s, int k)
    {
        int[] freq = new int[26];
        int maxCount = 0,res = 0,left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            freq[s[right] - 'A']++;
            // 窗口中最多字母的数量
            maxCount = Math.Max(maxCount, freq[s[right] - 'A']);
            // 替换次数不足,缩小窗口
            if (maxCount + k < right - left + 1)
            {
                freq[s[left] - 'A']--;
                left++;
            }

            res = Math.Max(res, right - left + 1);
        }
        return res;
    }
}