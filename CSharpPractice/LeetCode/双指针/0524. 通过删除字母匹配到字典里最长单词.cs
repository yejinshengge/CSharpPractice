namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个字符串 s 和一个字符串数组 dictionary ，找出并返回 dictionary 中最长的字符串，该字符串可以通过删除 s 中的某些字符得到。

    如果答案不止一个，返回长度最长且字母序最小的字符串。如果答案不存在，则返回空字符串。
 */
public class LeetCode_0524
{
    public static void Test()
    {
        LeetCode_0524 obj = new LeetCode_0524();
        Console.WriteLine(obj.FindLongestWord("abpcplea",new List<string>(){"ale","apple","monkey","plea"}));
        Console.WriteLine(obj.FindLongestWord("abpcplea",new List<string>(){"a","b","c"}));
    }
    
    public string FindLongestWord(string s, IList<string> dictionary)
    {
        var newDic = dictionary.OrderBy(a => -a.Length).ThenBy(a => a);
        foreach (var str in newDic)
        {
            int index1 = 0, index2 = 0;
            while (index1 < s.Length && index2 < str.Length)
            {
                if (s[index1] == str[index2]) index2++;
                index1++;
            }

            if (index2 == str.Length) return str;
        }

        return "";
    }
}