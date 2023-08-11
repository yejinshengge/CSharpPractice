using System.Text;

namespace CSharpPractice.LeetCode.初级算法;

/**
 * https://leetcode.cn/leetbook/read/top-interview-questions-easy/xnpvdm/
 */
public class LeetCode_019
{
    public static void Test()
    {
        LeetCode_019 obj = new LeetCode_019();
        Console.WriteLine(obj.CountAndSay(5));
    }
    
    // 思路一:递归
    public string CountAndSay(int n)
    {
        if (n == 1) return "1";
        string str = CountAndSay(n - 1);

        StringBuilder builder = new StringBuilder();
        int left = 0;
        int right = 0;
        while (right < str.Length)
        {
            if (str[left] != str[right])
            {
                builder.Append(right - left);
                builder.Append(str[left]);
                left = right;
            }
            right++;
        }
        builder.Append(right - left);
        builder.Append(str[left]);
        
        return builder.ToString();
    }
    
}