namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给定两个字符串 s 和 t ，编写一个函数来判断 t 是否是 s 的字母异位词。
 */
public class LeetCode_015
{
    public static void LeetCode_015Main()
    {
        LeetCode_015 obj = new LeetCode_015();

        Console.WriteLine(obj.IsAnagram2("rat","car"));
    }
    
    // 思路一:用两个数组分别记录字符出现的次数,再比较两个数组
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        int[] arr1 = new int[26];
        int[] arr2 = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            arr1[s[i] - 'a']++;
            arr2[t[i] - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (arr1[i] != arr2[i]) return false;
        }

        return true;
    }

    // 思路二:用一个计数器记录新元素的增减,只需要一轮遍历
    public bool IsAnagram2(string s, string t)
    {
        if (s.Length != t.Length) return false;
        char[] arr = new char[26];
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int index = s[i] - 'a';
            arr[index]++;
            if (arr[index] == 1) count++;

            index = t[i] - 'a';
            arr[index]--;
            if (arr[index] == 0) count--;
        }

        return count == 0;
    } 
}