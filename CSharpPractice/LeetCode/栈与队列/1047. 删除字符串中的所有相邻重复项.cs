using System.Text;

namespace CSharpPractice.LeetCode.栈与队列;

/**
 * 给出由小写字母组成的字符串S，重复项删除操作会选择两个相邻且相同的字母，并删除它们。

在 S 上反复执行重复项删除操作，直到无法继续删除。

在完成所有重复项删除操作后返回最终的字符串。答案保证唯一。
 */
public class LeetCode_1047
{
    public static void Test()
    {
        LeetCode_1047 obj = new LeetCode_1047();
        Console.WriteLine(obj.RemoveDuplicates("abbaca"));
    }

    public string RemoveDuplicates(string s)
    {
        char[] arr = new char[s.Length];
        int index = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (index > 0 && s[i] == arr[index - 1])
            {
                index--;
                continue;
            }

            arr[index++] = s[i];
        }

        return new string(arr, 0, index);
    }
}