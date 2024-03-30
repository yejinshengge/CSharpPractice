namespace CSharpPractice.LeetCode.模拟;

/**
 * 给定一个整数 n，计算所有小于等于 n 的非负整数中数字 1 出现的个数。
 */
public class LeetCode_0233
{
    public static void Test()
    {
        LeetCode_0233 obj = new LeetCode_0233();
        Console.WriteLine(obj.CountDigitOne(13));
        Console.WriteLine(obj.CountDigitOne(0));
    }
    
    public int CountDigitOne(int n)
    {
        int total = 0;
        int curMulk = 1;

        while (n >= curMulk)
        {
            // 比当前高的位，影响当前位1的个数
            total += n / (curMulk * 10) * curMulk;
            // 去除高位后的余数
            int rest = n % (curMulk * 10);
            // 从这一位的最小值到最大值总共有几个数
            int num = rest - curMulk + 1;
            // 处理负数的情况
            int realNum = Math.Max(num, 0);
            // 这里面1的个数不可能超过curMulk
            total += Math.Min(realNum, curMulk);
            curMulk *= 10;
        }

        return total;
    }
}