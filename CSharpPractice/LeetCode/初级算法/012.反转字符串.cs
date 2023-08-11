using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
编写一个函数，其作用是将输入的字符串反转过来。输入字符串以字符数组 s 的形式给出。
不要给另外的数组分配额外的空间，你必须原地修改输入数组、使用 O(1) 的额外空间解决这一问题。
 */
public class LeetCode_012 {

    public static void LeetCode_012Main()
    {
        LeetCode_012 obj = new LeetCode_012();
        char[] arr = new[] {'h','e','l','l','o'};
        obj.ReverseString(arr);
        Util.Tools.PrintArr(arr);
    }
    
    public void ReverseString(char[] s)
    {
        int length = s.Length;
        for (int i = 0; i < length/2; i++)
        {
            (s[i], s[length - i - 1]) = (s[length - i - 1], s[i]);
        }
    }
}