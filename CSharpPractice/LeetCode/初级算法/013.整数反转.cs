namespace CSharpPractice.LeetCode.初级算法;

/**
给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。
如果反转后整数超过 32 位的有符号整数的范围[−2^31, 2^31− 1] ，就返回 0。
假设环境不允许存储 64 位整数（有符号或无符号）。
 */
public class LeetCode_013 {
    
    public static void LeetCode_013Main()
    {
        LeetCode_013 obj = new LeetCode_013();
        Console.WriteLine(int.MaxValue);
        Console.WriteLine(obj.Reverse(-12345));
        
    }
    
    public int Reverse(int x)
    {
        int res = 0;

        while (x != 0)
        {
            int num = x % 10;
            int newVal = res * 10 + num;
            if ((newVal - num) / 10 != res)
                return 0;
            res = newVal;
            x /= 10;
        }
        return res;
    }
}