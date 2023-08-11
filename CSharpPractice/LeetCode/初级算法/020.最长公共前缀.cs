using System.Text;

namespace CSharpPractice.LeetCode.初级算法;

/**
 * 编写一个函数来查找字符串数组中的最长公共前缀。如果不存在公共前缀，返回空字符串 ""。
 */
public class LeetCode_020
{
    public static void Test()
    {
        LeetCode_020 obj = new LeetCode_020();
        
        Console.WriteLine(obj.LongestCommonPrefix(new []{""}));
    }
    
    // 思路一:暴力枚举
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1) return strs[0];
        int index = 0;
        StringBuilder builder = new StringBuilder();
        
        while (true)
        {
            for (int i = 1; i < strs.Length; i++)
            {
                if(index >= strs[i].Length || index >= strs[i-1].Length || strs[i][index] != strs[i - 1][index])
                    return builder.ToString();
            }
            builder.Append(strs[0][index]);
            index++;
        }
    }
}