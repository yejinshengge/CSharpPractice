namespace CSharpPractice.LeetCode.初级算法;

/**
 * 假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
 * 每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
 */
public class LeetCode_034
{
    public static void Test()
    {
        LeetCode_034 obj = new LeetCode_034();
        
        Console.WriteLine(obj.ClimbStairs3(3));// 1134903170

    }

    // 斐波那契数列 f(n) = f(n-1)+f(n-2)
    // 暴力递归超出时间限制
    public int ClimbStairs(int n)
    {
        if (n <= 1) return 1;
        if (n < 3) return n;
        
        return ClimbStairs(n - 1) + ClimbStairs(n - 2);
    }

    // 尾递归
    public int ClimbStairs2(int n)
    {
        return Process(n, 1, 1);
    }

    private int Process(int n, int a, int b)
    {
        if (n <= 1) return b;
        return Process(n - 1, b, a + b);
    }
    
    // 非递归
    public int ClimbStairs3(int n)
    {
        int a =1,b = 1;

        while (n>1)
        {
            int temp = a + b;
            a = b;
            b = temp;
            n--;
        }

        return b;
    }
}