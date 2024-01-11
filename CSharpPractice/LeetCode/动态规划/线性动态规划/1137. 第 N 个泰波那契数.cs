namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 泰波那契序列 Tn 定义如下： 
    
    T0 = 0, T1 = 1, T2 = 1, 且在 n &gt;= 0 的条件下 Tn+3 = Tn + Tn+1 + Tn+2
    
    给你整数 n，请返回第 n 个泰波那契数 Tn 的值。
 */
public class LeetCode_1137
{
    public static void Test()
    {
        LeetCode_1137 obj = new LeetCode_1137();
        Console.WriteLine(obj.Tribonacci(25));
    }
    
    public int Tribonacci(int n)
    {
        int t0 = 0, t1 = 1, t2 = 1;
        if (n == 0) return t0;
        if (n == 1) return t1;
        if (n == 2) return t2;
        for (int i = 3; i <= n; i++)
        {
            int sum = t0 + t1 + t2;
            t0 = t1;
            t1 = t2;
            t2 = sum;
        }
        return t2;
    }
}