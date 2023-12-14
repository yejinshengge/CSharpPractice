namespace CSharpPractice.LeetCode.字符串;

/**
 * 给你一个字符串 s，由若干单词组成，单词前后用一些空格字符隔开。返回字符串中 最后一个 单词的长度。
    
    单词 是指仅由字母组成、不包含任何空格字符的最大子字符串。
 */
public class LeetCode_0058
{
    public static void Test()
    {
        LeetCode_0058 obj = new LeetCode_0058();
        Console.WriteLine(obj.LengthOfLastWord("Hello World"));
        Console.WriteLine(obj.LengthOfLastWord("   fly me   to   the moon  "));
        Console.WriteLine(obj.LengthOfLastWord("luffy is still joyboy"));
    }
    
    public int LengthOfLastWord(string s)
    {
        s = s.Trim();
        int len = 0;
        for (int i = s.Length-1; i >= 0; i--)
        {
            if(s[i] == ' ')
                break;
            len++;
        }

        return len;
    }
}