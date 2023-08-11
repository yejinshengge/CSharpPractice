namespace CSharpPractice.数据结构.练习;

public class SlidingWindow {

    public static void Test()
    {
        Console.WriteLine(LengthOfLongestSubstring("abcbdeb"));
    }

    public static int LengthOfLongestSubstring(string str)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        // 最大长度
        int max = 0;
        // 左指针
        int left = 0;
        for (int right = 0; right < str.Length; right++)
        {
            var c = str[right];
            if (dic.ContainsKey(c))
                left = Math.Max(left, dic[c] + 1);
            max = Math.Max(max, right - left + 1);
            dic[c] = right;
        }

        return max;
    }
    
}