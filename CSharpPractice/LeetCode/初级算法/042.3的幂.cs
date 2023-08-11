namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给定一个整数，写一个函数来判断它是否是 3的幂次方。如果是，返回 true ；否则，返回 false 。
 * 整数 n 是 3 的幂次方需满足：存在整数 x 使得 n == 3^x
 */
public class LeetCode_042
{
    public static void Test()
    {
        LeetCode_042 obj = new LeetCode_042();
        Console.WriteLine(obj.IsPowerOfThree(243));
    }

    public bool IsPowerOfThree(int n)
    {
        if (n == 0) return false;
        // var res = Math.Log(n, 3); 精度问题
        var res = Math.Log10(n) / Math.Log10(3);
        return res%1 == 0;
    }
}