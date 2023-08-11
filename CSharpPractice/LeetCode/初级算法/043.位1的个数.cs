namespace CSharpPractice.LeetCode.初级算法;

// 编写一个函数，输入是一个无符号整数（以二进制串的形式），返回其二进制表达式中数字位数为 '1' 的个数（也被称为汉明重量）。
public class LeetCode_043
{
    public static void Test()
    {
        LeetCode_043 obj = new LeetCode_043();
        Console.WriteLine(obj.HammingWeight(00000000000000000000000000001011));
    }

    // 思路一:逐位遍历
    public int HammingWeight(uint n)
    {
        int num = 0;
        for (int i = 0; i < 32; i++)
        {
            if (((n >> i) & 1) == 1)
                num++;
        }

        return num;
    }
}