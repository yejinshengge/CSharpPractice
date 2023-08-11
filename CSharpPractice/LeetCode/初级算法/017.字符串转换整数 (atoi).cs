namespace CSharpPractice.LeetCode.初级算法;

/**
请你来实现一个myAtoi(string s)函数，使其能将字符串转换成一个 32 位有符号整数（类似 C/C++ 中的 atoi 函数）。
函数myAtoi(string s) 的算法如下：
读入字符串并丢弃无用的前导空格
检查下一个字符（假设还未到字符末尾）为正还是负号，读取该字符（如果有）。 确定最终结果是负数还是正数。 如果两者都不存在，则假定结果为正。
读入下一个字符，直到到达下一个非数字字符或到达输入的结尾。字符串的其余部分将被忽略。
将前面步骤读入的这些数字转换为整数（即，"123" -> 123， "0032" -> 32）。如果没有读入数字，则整数为 0 。必要时更改符号（从步骤 2 开始）。
如果整数数超过 32 位有符号整数范围 [−2^31, 2^31− 1] ，需要截断这个整数，使其保持在这个范围内。
具体来说，小于 −2^31 的整数应该被固定为 −2^31 ，大于 2^31− 1 的整数应该被固定为 2^31− 1 。
返回整数作为最终结果。
 */
public class LeetCode_017
{
    public static void LeetCode_017Main()
    {
        LeetCode_017 obj = new LeetCode_017();
        
        Console.WriteLine(obj.MyAtoi("4193 with words"));
    }
    
    
    public int MyAtoi(string s)
    {
        s = s.TrimStart();
        if (s.Length == 0) return 0;
        // 是否为负数
        int flag = s[0] == '-'?-1:1;
        int index = (s[0] == '-' || s[0] == '+') ? 1 : 0;
        long res = 0;
        
        while (index < s.Length && IsNum(s[index]))
        {
            res = res * 10 + (s[index] - '0');
            if (res*flag > int.MaxValue) return int.MaxValue;
            if (res*flag < int.MinValue) return int.MinValue;
            index++;
        }

        return (int)res*flag;
    }

    private bool IsNum(char s)
    {
        return s is >= '0' and <= '9';
    }
}